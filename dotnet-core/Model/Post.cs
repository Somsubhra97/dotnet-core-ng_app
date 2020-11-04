using System.ComponentModel.DataAnnotations;

namespace dotnet_core.Models
{
    public class Post
    {
        
        public int id { get; set; }

        [Required]
        public string content { get; set; }
        
        [Required]
        public string title { get; set; }       
       
        
    }
}