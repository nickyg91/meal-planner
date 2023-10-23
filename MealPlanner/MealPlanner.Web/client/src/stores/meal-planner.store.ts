import { ref, inject } from 'vue';
import { defineStore } from 'pinia';
import type { Meal } from '@/shared/models/meal.model';
import { mealService } from '@/shared/injection-keys';
import type { MealPlannerService } from '@/shared/services/meal-planner.service';
import { useToast } from 'primevue/usetoast';

export const useMealPlannerStore = defineStore('mealPlanner', () => {
  const toastService = useToast();
  const meals = ref<Meal[]>([]);
  const mealPlannerService = inject<MealPlannerService>(mealService)!;
  async function getAllMeals() {
    meals.value = (await mealPlannerService.getAllMeals()) ?? [];
  }
  async function saveMeal(meal: Meal) {
    try {
      const resp = await mealPlannerService.saveMeal(meal);
      meals.value.push(resp!);
      toastService.add({
        closable: true,
        detail: 'Meal added!',
        group: 'appwideToast',
        life: 2000,
        severity: 'success',
        summary: 'Success!'
      });
    } catch (err) {
      toastService.add({
        closable: true,
        detail: 'An error occurred while submitting your meal!',
        group: 'appwideToast',
        life: 2000,
        severity: 'error',
        summary: 'Error'
      });
    }
  }

  return {
    meals,
    getAllMeals,
    saveMeal
  };
});
