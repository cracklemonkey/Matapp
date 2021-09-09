using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;

namespace ImageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly ImageService _imageService;

        public ImageController(ImageService imageService){
            _imageService = imageService;
        }

        [HttpGet("{imageName}")]

        public async Task<IActionResult> GetImage(string imageName)
        {
            var data = await _imageService.GetBlobAsync(imageName);
            return File(data, "image/jpeg");
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _imageService.ListBlobAsync());
        }


        
       
        
        
        [HttpPost]

 
        public async Task<IActionResult> CreateAsync([FromForm] IFormFile file)

        {

        if (!ModelState.IsValid) return BadRequest("Invalid model state");

        var blobName = await _imageService.CreateBlobAsync(file);

      

        return Ok();

 
        }

        [HttpDelete("{imageName}")]

         public async Task<IActionResult> DeleteFile(string imageName)
         {
             await _imageService.DeleteBlobAsync(imageName);
             return Ok();
         }

    }

}