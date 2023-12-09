using InnoNet.Data.Entities;

namespace InnoNet.Data.Services;

public interface IPostReply
{
    Task Delete(int id);
    Task Edit(int id, string content);
    Task<PostReply?> GetById(int id);
}