using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.CommentsMicroservice.Contracts.Common;
using EasyMicroservices.CommentsMicroservice.Database.Entities;
using EasyMicroservices.CommentsMicroservice.Contracts.Requests;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.Cores.Contracts.Requests;
using System.Collections.Immutable;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;

namespace EasyMicroservices.CommentsMicroservice.WebApi.Controllers
{
    public class CommentController : SimpleQueryServiceController<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long>
    {
        public IUnitOfWork _uow;

        public CommentController(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override async Task<MessageContract> SoftDeleteById(SoftDeleteRequestContract<long> request, CancellationToken cancellationToken = default)
        {
            var logic = _uow.GetContractLogic<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long>();

            var childComments = await logic.GetAll(query => query.Where(x => x.ParentId == request.Id), cancellationToken);
            var commentIds = childComments.Result.Select(x => x.Id).ToList();

            var deleteParentComment = await logic.SoftDeleteById(new SoftDeleteRequestContract<long>
            {
                Id = request.Id,
                IsDelete = true
            }, cancellationToken);

            await logic.SoftDeleteBulkByIds(new SoftDeleteBulkRequestContract<long>
            {
                Ids = commentIds,
                IsDelete = true
            }, cancellationToken);

            return deleteParentComment;
        }
    }
}
