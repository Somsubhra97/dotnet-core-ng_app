using System.Collections.Generic;
using dotnet_core.Models;
using System.Threading.Tasks;
using dotnet_core.Dtos.Post;


namespace dotnet_core.Data
{
    public interface IPost
    {                 
      Task<ServiceResponse<List<GetPostDto>>> Getter();
      Task<ServiceResponse<GetPostDto>> GetPostById(int id);
      Task<ServiceResponse<List<GetPostDto>>> AddPost(CreatePostDto model);
      Task<ServiceResponse<List<GetPostDto>>> UpdatePost( UpdatePostDto model, int id);
      Task<ServiceResponse<List<GetPostDto>>> Delete(int id);
     
    }
}