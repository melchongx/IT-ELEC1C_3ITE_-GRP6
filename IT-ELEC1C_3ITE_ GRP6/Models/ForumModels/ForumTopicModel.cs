using IT_ELEC1C_3ITE__GRP6.Models.PostModels;

namespace IT_ELEC1C_3ITE__GRP6.Models.ForumModels
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum {  get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
