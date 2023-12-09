using InnoNet.WebApi.Models.Post;

namespace InnoNet.WebApi.Models.Search;

public class SearchResultModel
{
    public IEnumerable<PostListingModel> Posts { get; set; }
    public string SearchQuery { get; set; }
    public bool EmptySearchResults { get; set; }
}