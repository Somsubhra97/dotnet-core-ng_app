using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

using dotnet_core.Data;
using dotnet_core.Models;

namespace dotnet_core.Controllers
{

    [Route("api/posts")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
      
        private readonly IPost _repository;
        
        public CommandsController(IPost repository)
        {
            _repository = repository;
           
        }

        [HttpGet]          
        public async Task<IActionResult> GetAll (){
           var ob=await _repository.Getter();
                    
             return Ok(ob);
        } 
       
        
              
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            ServiceResponse<Post> x=await _repository.GetPostById(id);
                     
            if(x.Success)
                return Ok(x);  
            return NotFound();                
   
        }  
       
 
   
    [HttpPost]
    public async Task<IActionResult> Add(Post cmd){

           if (ModelState.IsValid){
            var ret=await _repository.AddPost(cmd);                                
            return Ok(ret);      
           }
          return BadRequest();
                  
        }
        

   
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Post cmd,int id){       
            var ret=await _repository.UpdatePost(cmd,id);   
                 
            if(!ret.Success){
                return NotFound(ret);
             }      
            return Ok(ret);            
        } 

    [HttpDelete("{id}")]    
    public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<Post>> response = await _repository.Delete(id);               
            return Ok(response);
        }         
    
  }
}