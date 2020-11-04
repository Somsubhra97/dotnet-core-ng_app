usig System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;

namespace dotnet_core.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string content { get; set; }
        
        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string title { get; set; }        
       
        
    }
}