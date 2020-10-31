using System.Collections.Generic;
using dotnet_core.Models;
using dotnet_core.Dtos.Post;
using System.Threading.Tasks;
using System;
using AutoMapper;
using System.Linq;

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

    private readonly IMapper _mapper;     
    public MockPost(IMapper mapper)
    {  
        _mapper = mapper;        

    }
 
    public async Task<ServiceResponse<List<GetPostDto>>> Getter(){
        ServiceResponse<List<GetPostDto>> ob=new ServiceResponse<List<GetPostDto>>();
        List<GetPostDto> op=new List<GetPostDto>();
        foreach (Post i in posts) 
        {
            op.Add(_mapper.Map<GetPostDto>(i));
        }
        ob.Data=op;
        return ob;
    }

    public async Task<ServiceResponse<GetPostDto>> GetPostById(int id){
     ServiceResponse<GetPostDto> ob=new ServiceResponse<GetPostDto>();  
       try{
         ob.Data= _mapper.Map<GetPostDto>(posts.FirstOrDefault(c=>c.id==id));     
         if(ob.Data==null) throw new Exception("NOT FOUND"); 
       }
       catch(Exception ){
        ob.Success=false;
       }        
        return ob;  
    }

    public async Task<ServiceResponse<List<GetPostDto>>> AddPost(CreatePostDto model){
        ServiceResponse<List<GetPostDto>> ob=new ServiceResponse<List<GetPostDto>>();
        List<GetPostDto> op=new List<GetPostDto>();

         Post p = _mapper.Map<Post>(model);
         Random r = new Random();         
         p.id=r.Next(10,50);
         posts.Add(p);        
        foreach (Post i in posts) 
        {
            op.Add(_mapper.Map<GetPostDto>(i));
        }
        ob.Data=op;

        return ob;
    }

    public async Task<ServiceResponse<List<GetPostDto>>> UpdatePost( UpdatePostDto model, int id){
        List<GetPostDto> op=new List<GetPostDto>();
        ServiceResponse<List<GetPostDto>> ob=new ServiceResponse<List<GetPostDto>>();
        
        foreach (Post cmd in posts){
            if(cmd.id==id){
                cmd.content=model.content;
                cmd.title=model.title;
            }
        }
        foreach (Post i in posts) 
        {
            op.Add(_mapper.Map<GetPostDto>(i));
        }
        ob.Data=op;        
        return ob;
    }

    public async Task<ServiceResponse<List<GetPostDto>>> Delete(int id){
        ServiceResponse<List<GetPostDto>> ob=new ServiceResponse<List<GetPostDto>>();
        
        List<GetPostDto> l=new List<GetPostDto>();
        List<Post> list=new List<Post>();
        
        foreach (Post i in posts){
            if(i.id!=id){
               l.Add(_mapper.Map<GetPostDto>(i));    
               list.Add(i);
               }        
            }
        
        posts=list;
        ob.Data=l;
        return ob;
     }
    }
   }
 
    