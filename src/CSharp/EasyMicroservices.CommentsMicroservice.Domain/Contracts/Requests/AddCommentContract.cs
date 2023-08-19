using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.CommentsMicroservice.Contracts.Requests
{
    public class AddCommentContract
    {
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
