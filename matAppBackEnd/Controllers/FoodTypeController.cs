using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTypesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypesController : ControllerBase
    {
        private readonly FoodTypeService _foodtypeService;

        public FoodTypesController(FoodTypeService foodtypeService)
        {
            _foodtypeService = foodtypeService;
        }

        [HttpGet]
        public async Task <ActionResult<List<FoodType>>> Get() =>
            await _foodtypeService.Get();

          

         [HttpGet("{name}", Name = "GetFoodType")]
        public async Task <ActionResult<FoodType>> Get(string name)
        {   
            var foodtype = await _foodtypeService.Get(name);

            if (foodtype == null)
            {
                return NotFound();
            }

            return foodtype;
        }
        


        [HttpPost]
        public async Task <ActionResult<FoodType>> Create(FoodType foodtype)
        {
            await _foodtypeService.Create(foodtype);

            return CreatedAtRoute("GetFoodType", new { name = foodtype.Name.ToString() }, foodtype);
        }

        [HttpPut("{name}")]
        public async Task <ActionResult<FoodType>> Update(string name, [FromBody] FoodType foodtypeIn)
        {
            var foodtype = await _foodtypeService.Get(name);

            if (foodtype == null)
            {
                return NotFound();
            }

            var updated = await _foodtypeService.UpdateFoodType(name, foodtypeIn);

            return updated;
        }

        [HttpDelete("{name}")]
        public async Task <ActionResult<FoodType>> Delete(string name)
        {
            var foodtype = await _foodtypeService.Get(name);

            if (foodtype == null)
            {
                return NotFound();
            }

            var deleted = await _foodtypeService.Delete(foodtype.Name);

            return deleted;

        }
        
        
    }

}