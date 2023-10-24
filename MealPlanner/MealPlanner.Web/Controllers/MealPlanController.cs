using MealPlanner.Data.Contexts.MealPlanner.Repositories;
using MealPlanner.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers
{
    [Route("api/plans")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {
        private readonly IMealPlanRepository _mealPlanRepository;

        public MealPlanController(IMealPlanRepository mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        [HttpPost("save")]
        public async Task<IActionResult> AddPlan(List<MealPlan> plans)
        {
            await _mealPlanRepository.InsertMealPlan(plans);
            return Ok(plans);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetPlans(DateTime date)
        {
            var plans = await _mealPlanRepository.GetMealPlansForWeek(date);
            return Ok(plans);
        }
    }
}
