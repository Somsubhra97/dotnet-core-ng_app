using System.Collections.Generic;

namespace dotnet_core.Dtos.Post
{
    public class GetPostDto
    {
        public int id { get; set; }

        public string content { get; set; }
        
        public string title { get; set; }        
       
    }
}