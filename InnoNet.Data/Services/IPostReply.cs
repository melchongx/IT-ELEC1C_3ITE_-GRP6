using InnoNet.Data.Entities;

namespace InnoNet.Data.Services;

public interface IPostReply
{
    Task Delete(int id);
    Task Edit(PostReply existingReply);
    Task<PostReply?> GetById(int id);
}