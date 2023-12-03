﻿using InnoNet.Data;
using InnoNet.Data.Models;
using IT_ELEC1C_3ITE__GRP6.Models.ForumModels;
using IT_ELEC1C_3ITE__GRP6.Models.PostModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IT_ELEC1C_3ITE__GRP6.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll().Select(forum => new ForumListingModel  {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
            });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetPostsByForum(id);

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
