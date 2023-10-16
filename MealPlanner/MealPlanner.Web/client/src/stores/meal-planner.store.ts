import { ref, inject } from 'vue';
import { defineStore } from 'pinia';
import type { Meal } from '@/shared/models/meal.model';
import { mealService } from '@/shared/injection-keys';
import type { MealPlannerService } from '@/shared/services/meal-planner.service';

export const useMealPlannerStore = defineStore('mealPlanner', () => {
  const meals = ref<Meal[]>([]);
  const mealPlannerService = inject<MealPlannerService>(mealService)!;
  async function getAllMeals() {
    meals.value = (await mealPlannerService.getAllMeals()) ?? [];
  }
  async function saveMeal(meal: Meal) {
    const resp = await mealPlannerService.saveMeal(meal);
    meals.value.push(resp!);
  }

  return {
    meals,
    getAllMeals,
    saveMeal
  };
});
