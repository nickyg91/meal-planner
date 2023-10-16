using MealPlanner.Data.Contexts.MealPlanner.Repositories;
using MealPlanner.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers
{
    [Route("api/meals")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository _mealRepository;

        public MealController(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(Meal meal)
        {
            await _mealRepository.InsertMeal(meal);
            return Ok(meal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var meals = await _mealRepository.GetAllMeals();
            return Ok(meals);
        }
    }
}
