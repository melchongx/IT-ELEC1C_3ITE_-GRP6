﻿namespace IT_ELEC1C_3ITE__GRP6.Models.ReplyModels
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Created {  get; set; }
        public string ReplyContent {  get; set; }


        public int PostId { get; set; }

    }
}
