using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace matAppBackEnd.Models
{   
    
    public class FileModel
    {
        
        public IFormFile MyFile {get; set;}
    }
}