using System.Collections.Generic;
using dotnet_core.Models;
using System.Threading.Tasks;


namespace dotnet_core.Data
{
    public interface IPost
    {                 
      Task<ServiceResponse<List<Post>>> Getter();
      Task<ServiceResponse<Post>> GetPostById(int id);
      Task<ServiceResponse<List<Post>>> AddPost(Post data);
      Task<ServiceResponse<List<Post>>> UpdatePost( Post model, int id);
      Task<ServiceResponse<List<Post>>> Delete(int id);
     
    }
}