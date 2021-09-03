using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FoodTypesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypesController : ControllerBase
    {
        private readonly FoodTypeService _foodTypeService;

        public FoodTypesController(FoodTypeService foodTypeService)
        {
            _foodTypeService = foodTypeService;
        }

        [HttpGet]
        public ActionResult<List<FoodType>> Get() =>
            _foodTypeService.Get();

          

         [HttpGet("{name}", Name = "GetFoodType")]
        public ActionResult<FoodType> Get(string name)
        {   
            var foodType = _foodTypeService.Get(name);

            if (foodType == null)
            {
                return NotFound();
            }

            return foodType;
        }
        


        [HttpPost]
        public ActionResult<FoodType> Create(FoodType foodtype)
        {
            _foodTypeService.Create(foodtype);

            return CreatedAtRoute("GetFoodType", new { name = foodtype.Name.ToString() }, foodtype);
        }

        [HttpPut("{name}")]
        public IActionResult Update(string name, [FromBody] FoodType foodTypeIn)
        {
            var foodType = _foodTypeService.Get(name);

            if (foodType == null)
            {
                return NotFound();
            }

            _foodTypeService.UpdateFoodType(name, foodTypeIn);

            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var foodType = _foodTypeService.Get(name);

            if (foodType == null)
            {
                return NotFound();
            }

            _foodTypeService.Delete(foodType.Name);

            return NoContent();

        }
        
        
    }

}