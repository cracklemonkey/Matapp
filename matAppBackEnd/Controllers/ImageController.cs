using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            return File(data, "image/jpg");
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _imageService.ListBlobAsync());
        }


        [HttpPost("{uploade}")]

        public async Task<IActionResult> UploadeFileBlobAsync([FromForm] FileModel model)
        {
            if (model.MyFile != null)
            {
               await _imageService.UploadeFileBlobAsync(model);
            }
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