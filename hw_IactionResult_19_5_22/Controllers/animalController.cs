using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace hw_IactionResult_19_5_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class animalController : ControllerBase
    {
        [BindProperty]
        public List<AnimalModel> AnimalList { get; set; } = new List<AnimalModel>()
        {
            new AnimalModel() { name = "cat" , age = 5}
            ,
            new AnimalModel() { name = "dog" , age = 6}
            ,
            new AnimalModel() { name = "owl" , age = 7}
            ,
            new AnimalModel() { name = "crow" ,age = 8}
            ,
            new AnimalModel() { name = "lion" ,age = 9}
        };
        public string smile1 { get; set; } = "Give me a smile";

        [Route("smile")]
        public IActionResult smile()
        {
            return Accepted(new AnimalModel() { name = "giraffe", age = 10 });
        }

        [Route("{name}")]
        public IActionResult GetByID(string name)
        {
            foreach (var animal in AnimalList)
            {
                if (name == animal.name)
                {
                    return Ok(animal);
                }
                else if (name == "giraffe")
                {
                    return Accepted("~/api/animal/smile");
                }
            }
            return NotFound();
        }
        [Route("special/{name}")]
        public ActionResult<AnimalModel> GetByID1(string name)
        {
            foreach (var animal in AnimalList)
            {
                if (name == animal.name)
                {
                    return animal;
                }
                else if (name == "giraffe")
                {
                    return Accepted("~/api/animal/smile");
                }
            }
            return NotFound();
        }

        
      
    }
}
