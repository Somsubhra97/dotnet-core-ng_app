using System.Collections.Generic;
using dotnet_core.Models;
using dotnet_core.Dtos.Post;
using System.Threading.Tasks;
using System;

namespace dotnet_core.Data
{
public class MockPost : IPost
    {
    private static List<Post> posts= new List<Post>
    {
        new Post{id=0, title="Post#1", content="My Post"},
        new Post{id=1, title="Post#2", content="Second Post"},
        new Post{id=2, title="Post#3", content="Thrid Post"}
    };
 
    public async Task<ServiceResponse<List<Post>>> Getter(){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        List<Post> op=new List<Post>();
        
        ob.Data=posts;
        return ob;
    }

    public async Task<ServiceResponse<Post>> GetPostById(int id){
     ServiceResponse<Post> x=new ServiceResponse<Post>();     
       try{
        foreach (Post cmd in posts) 
        {
            if(cmd.id==id)
             x.Data=cmd;
        } 
        if(x==null) throw new Exception("NOT FOUND"); 
       }
       catch(Exception ){
        x.Success=false;
       }        
        return x;  
    }

    public async Task<ServiceResponse<List<Post>>> AddPost(Post model){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        posts.Add(model);
        ob.Data=posts;

        return ob;
    }

    public async Task<ServiceResponse<List<Post>>> UpdatePost( Post model, int id){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        foreach (Post cmd in posts){
            if(cmd.id==id){
                cmd.content=model.content;
                cmd.title=model.title;
            }
        }
        ob.Data=posts;
        return ob;
    }

    public async Task<ServiceResponse<List<Post>>> Delete(int id){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        List<Post> l=new List<Post>();
        foreach (Post cmd in posts){
            if(cmd.id!=id)
               l.Add(cmd);            
        }
        posts=l;
        ob.Data=posts;
        return ob;
    }
   }
 } 
    