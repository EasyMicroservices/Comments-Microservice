using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.CommentsMicroservice.Contracts.Common;
using EasyMicroservices.CommentsMicroservice.Database.Entities;
using EasyMicroservices.CommentsMicroservice.Contracts.Requests;
using EasyMicroservices.ServiceContracts;
using EasyMicroservices.Cores.Contracts.Requests;
using System.Collections.Immutable;

namespace EasyMicroservices.CommentsMicroservice.WebApi.Controllers
{
    public class CommentController : SimpleQueryServiceController<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long>
    {
        private readonly IContractLogic<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long> _contractlogic;
        public CommentController(IContractLogic<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long> contractLogic) : base(contractLogic)
        {
            _contractlogic = contractLogic;
        }
        public override async Task<MessageContract> SoftDeleteById(SoftDeleteRequestContract<long> request, CancellationToken cancellationToken = default)
        {
            var childComments = await _contractlogic.GetAll(query => query.Where(x => x.ParentId == request.Id));
            var commentId = childComments.Result.Select(x => x.Id).ToList();
            var deleteParentComment = await _contractlogic.SoftDeleteById(new SoftDeleteRequestContract<long>
            {
                Id = request.Id,
                IsDelete = true
            }, cancellationToken);
            if (deleteParentComment.IsSuccess)
            {
                await _contractlogic.SoftDeleteBulkByIds(new SoftDeleteBulkRequestContract<long>
                {
                    Ids = commentId,
                    IsDelete = true
                });
            return deleteParentComment;
            }
            return (FailedReasonType.Incorrect, "An error has occurred");
        }
    }
}
