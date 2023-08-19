using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.CommentsMicroservice.Contracts.Requests
{
    public class UpdateCommentContract : AddCommentContract
    {
        public long Id { get; set; }
    }
}
