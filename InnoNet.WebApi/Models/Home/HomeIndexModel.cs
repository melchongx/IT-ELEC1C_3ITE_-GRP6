using InnoNet.WebApi.Models.Forum;
using InnoNet.WebApi.Models.Post;

namespace InnoNet.WebApi.Models.Home;

public class HomeIndexModel
{
    public string SearchQuery { get; set; }
    public IEnumerable<PostListingModel> LatestPosts { get; set; }
    public IEnumerable<ForumListingModel> PopularForums { get; set; }
}