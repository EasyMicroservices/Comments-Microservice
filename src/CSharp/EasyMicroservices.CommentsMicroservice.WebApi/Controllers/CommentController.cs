using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.CommentsMicroservice.Contracts.Common;
using EasyMicroservices.CommentsMicroservice.Database.Entities;
using EasyMicroservices.CommentsMicroservice.Contracts.Requests;

namespace EasyMicroservices.CommentsMicroservice.WebApi.Controllers
{
    public class CommentController : SimpleQueryServiceController<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long>
    {
        public CommentController(IContractLogic<CommentEntity, AddCommentContract, UpdateCommentContract, CommentContract, long> contractReadable) : base(contractReadable)
        {

        }
    }
}
