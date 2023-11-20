using Microsoft.Identity.Client;

namespace IT_ELEC1C_3ITE__GRP6.Models
{
    public class Post
    {
        public int postId { get; set; }
        public string postUid { get; set; }
        public string postTitle { get; set; }
        public string postContent { get; set; }
        public DateTime postDate { get; set; }
    }
}
