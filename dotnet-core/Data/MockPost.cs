using System.Collections.Generic;
using dotnet_core.Models;
using System.Threading.Tasks;
using System;

namespace dotnet_core.Data
{
public class MockPost : IPost
    {
    /*private static List<Post> posts= new List<Post>
    {
        new Post{id=0, title="Boil an egg", content="Boil water"},
        new Post{id=1, title="Cut bread", content="Get a knife"},
        new Post{id=2, title="Make cup of tea", content="blah blah"}
    };*/


    private readonly DataContext _context;
    public MockPost(DataContext dbcontext)
    {  
         _context=dbcontext;

    }
 
    /*public async Task<ServiceResponse<List<Post>>> Getter(){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        List<Post> op=new List<Post>();
        
        ob.Data=posts;
        return ob;
    }*/
    public async Task<ServiceResponse<List<Post>>> GetterDB(){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        List<Post> db=new List<Post>();
        db=await _context.Posts.ToListAsync();
        ob.Data=db;
        return ob;
    } 



   /* public async Task<ServiceResponse<Post>> GetPostById(int id){
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
    }*/
    public async Task<ServiceResponse<Post>> GetPostByIdDB(int id){
        ServiceResponse<Post> ob=new ServiceResponse<Post>();        
        Post x=await _context.Posts.FirstOrDefaultAsync(i=>i.id==id);
        ob.Data= x;
        return ob;
    }




   /* public async Task<ServiceResponse<List<Post>>> AddPost(Post model){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        posts.Add(model);
        ob.Data=posts;

        return ob;
    }*/
    public async Task<ServiceResponse<List<Post>>> CreatePostDB(Post data){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        
        await _context.Commands.AddAsync(cmd);
        await _context.SaveChanges();

        ob.Data =await _context.Posts.ToListAsync();
        return ob;

    }




    /*public async Task<ServiceResponse<List<Post>>> UpdatePost( Post model, int id){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        foreach (Post cmd in posts){
            if(cmd.id==id){
                cmd.content=model.content;
                cmd.title=model.title;
            }
        }
        ob.Data=posts;
        return ob;
    }*/
    public async Task<ServiceResponse<Post>> UpdatePostDB(Post data,int id){
       ServiceResponse<Post> ob=new ServiceResponse<Post>();

       try{
        Command obj=await _context.Posts.FirstOrDefaultAsync(i=>i.id==id);
        obj.title=data.title;
        obj.content=data.content;
        _context.Posts.Update(obj);
        await _context.SaveChanges();

        ob.Data = obj;
       }
       catch(Exception e){
        ob.Message=e.Message;
        ob.Success=false;
       }
       return ob;
   }




   /* public async Task<ServiceResponse<List<Post>>> Delete(int id){
        ServiceResponse<List<Post>> ob=new ServiceResponse<List<Post>>();
        List<Post> l=new List<Post>();
        foreach (Post cmd in posts){
            if(cmd.id!=id)
               l.Add(cmd);            
        }
        posts=l;
        ob.Data=posts;
        return ob;
    } */
    public async Task<ServiceResponse<List<Post>>> DeleteDB(int id){
        ServiceResponse<Post> ob=new ServiceResponse<Post>();
        try{
            Command x=await _context.Commands.FirstAsync(i=>i.id==id);
            _context.Posts.Remove(x);

            ob.Data =await _context.Posts.ToListAsync();
        }
        catch(Exception e){
            ob.Message=e.Message;
            ob.Success=false;
        }
        return ob;
    }

   }
}
  
    