using InnoNet.WebApi.Models.Post;

namespace InnoNet.WebApi.Models.Forum;

public class ForumTopicModel
{
    public ForumListingModel Forum { get; set; }
    public IEnumerable<PostListingModel> Posts { get; set; }
    public string SearchQuery { get; set; }
    public bool EmptySearchResults { get; set; }
}