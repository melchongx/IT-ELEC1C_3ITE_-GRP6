using InnoNet.Data.Entities;
using InnoNet.Data.Services;
using InnoNet.WebApi.Models.Reply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InnoNet.WebApi.Controllers;

[Authorize]
public class ReplyController : Controller
{
    private readonly IPost _postService;
    private readonly IPostReply _replyService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IApplicationUser _userService;

    public ReplyController(IPost postService, IApplicationUser userService, IPostReply replyService,
        UserManager<ApplicationUser> userManager)
    {
        _replyService = replyService;
        _postService = postService;
        _userService = userService;
        _userManager = userManager;
    }

    public async Task<ActionResult> Create(int id)
    {
        var post = await _postService.GetById(id);
        if (post == null) return RedirectToAction("Error", "Home");
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        var model = new PostReplyModel
        {
            PostId = post.Id,
            PostContent = post.Content,
            PostTitle = post.Title,
            AuthorId = user.Id,
            AuthorName = User.Identity.Name,
            AuthorImageUrl = user.ProfileImageUrl,
            IsAuthorAdmin = User.IsInRole("Admin"),
            ForumId = post.Forum.Id,
            ForumName = post.Forum.Title,
            ForumImageUrl = post.Forum.ImageUrl,
            Created = DateTime.Now
        };
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CreateReply(PostReplyModel model)
    {
        var userId = _userManager.GetUserId(User);
        var user = await _userManager.FindByIdAsync(userId);
        var reply = await BuildReply(model, user);
        await _postService.AddReply(reply);
        await _userService.UpdateUserRating(userId, typeof(PostReply));
        return RedirectToAction("Index", "Post", new { id = model.PostId });
    }

    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        var reply = await _replyService.GetById(id);
        if (reply == null) return RedirectToAction("Error", "Home");
        var model = new EditPostReplyModel
        {
            PostId = reply.Post.Id,
            ReplyId = reply.Id,
            AuthorName = reply.User.UserName,
            Content = reply.Content,
            PostTitle = reply.Post.Title
        };
        return View(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditReply(EditPostReplyModel model)
    {
        var existingReply = await _replyService.GetById(model.ReplyId);

        if (existingReply == null)
        {
            // Handle the case where the reply is not found
            return RedirectToAction("Error", "Home");
        }

        // Check if the current user has the right permissions to edit the reply
        if (!User.IsInRole("Admin") && existingReply.User.UserName != User.Identity.Name)
        {
            // Handle unauthorized access
            return RedirectToAction("Error", "Home");
        }

        // Update the reply content
        existingReply.Content = model.Content;

        // Save the changes
        await _replyService.Edit(existingReply);

        return RedirectToAction("Index", "Post", new { id = model.PostId });
    }

    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var reply = await _replyService.GetById(id);
        if (reply == null)
            return RedirectToAction("Error", "Home");

        var model = new DeleteReplyModel
        {
            Id = reply.Id,
            AuthorName = reply.User?.UserName ?? "ForumAdmin",
            Content = reply.Content,
            PostId = reply.Post?.Id ?? 0,
            PostTitle = reply.Post.Title
        };

        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        var reply = await _replyService.GetById(id);

        if (reply == null)
            return RedirectToAction("Error", "Home"); // or handle the error in another way

        var postId = reply.Post.Id;

        await _replyService.Delete(id);

        return RedirectToAction("Index", "Post", new { id = postId });
    }



    private async Task<PostReply> BuildReply(PostReplyModel model, ApplicationUser user)
    {
        var post = await _postService.GetById(model.PostId);

        return new PostReply
        {
            Post = post,
            Content = model.ReplyContent,
            Created = DateTime.Now,
            User = user
        };
    }
}