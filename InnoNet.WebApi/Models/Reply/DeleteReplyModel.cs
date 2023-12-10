namespace InnoNet.WebApi.Models.Reply
{
    public class DeleteReplyModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public string PostTitle { get; set; }
    }
}
