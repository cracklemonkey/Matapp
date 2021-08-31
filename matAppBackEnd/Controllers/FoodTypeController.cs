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

          

         [HttpGet("{foodTypeid}", Name = "GetFoodType")]
        public ActionResult<FoodType> Get(int foodTypeid)
        {   
            var foodType = _foodTypeService.Get(foodTypeid);

            if (foodType == null)
            {
                return NotFound();
            }

            return foodType;
        }
        


        [HttpPost]
        public ActionResult<FoodType> Create(FoodType foodType)
        {
            _foodTypeService.Create(foodType);

            return CreatedAtRoute("GetFoodType", new { foodTypeid = foodType.FoodTypeId.ToString() }, foodType);
        }

        [HttpPut("{foodTypeid}")]
        public IActionResult Update(int foodTypeid, [FromBody] FoodType foodTypeIn)
        {
            var foodType = _foodTypeService.Get(foodTypeid);

            if (foodType == null)
            {
                return NotFound();
            }

            _foodTypeService.UpdateFoodType(foodTypeid, foodTypeIn);

            return NoContent();
        }

        [HttpDelete("{foodTypeid}")]
        public IActionResult Delete(int foodTypeid)
        {
            var foodType = _foodTypeService.Get(foodTypeid);

            if (foodType == null)
            {
                return NotFound();
            }

            _foodTypeService.Delete(foodType.FoodTypeId);

            return NoContent();

        }
        
        
    }

}