﻿using InnoNet.Data;
using InnoNet.Data.Entities;
using InnoNet.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace InnoNet.Service;

public class PostReplyService : IPostReply
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public PostReplyService(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task Delete(int id)
    {
        var reply = await GetById(id);
        if (reply == null) return;
        _context.Remove(reply);
        await _unitOfWork.Commit();
    }

    public async Task Edit(PostReply existingReply)
    {
        _context.Update(existingReply);
        await _unitOfWork.Commit();
    }

    public async Task<PostReply?> GetById(int id)
    {
        return await _context.PostReplies
            .Include(r => r.Post)
            .ThenInclude(post => post.Forum)
            .Include(r => r.Post)
            .ThenInclude(post => post.User).FirstOrDefaultAsync(r => r.Id == id);
    }
}