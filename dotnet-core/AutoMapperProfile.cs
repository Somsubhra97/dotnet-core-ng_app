using System.Linq;
using AutoMapper;
using dotnet_core.Dtos.Post;
using dotnet_core.Models;

namespace dotnet_core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostDto>();                
            CreateMap<AddPostDto, Post>();
            
        }
    }
}