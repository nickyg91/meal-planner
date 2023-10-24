import { ref, inject } from 'vue';
import { defineStore } from 'pinia';
import type { Meal } from '@/shared/models/meal.model';
import { mealService } from '@/shared/injection-keys';
import type { MealPlannerService } from '@/shared/services/meal-planner.service';
import { useToast } from 'primevue/usetoast';
import { DateTime, Duration } from 'luxon';
import type { MealPlan } from '@/shared/models/meal-plan.model';

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

  function planMeals() {
    const ids = meals.value.map((x) => x.id);
    const chosenMealIds = new Array<number>();
    const hasAtLeastSevenDaysOfMeals = ids.length >= 7;
    while (chosenMealIds.length < 7) {
      let id = getRandomId(ids);
      if (chosenMealIds.indexOf(id) > -1 && hasAtLeastSevenDaysOfMeals) {
        while (chosenMealIds.indexOf(id) > -1) {
          id = getRandomId(ids);
        }
        chosenMealIds.push(id);
      } else {
        chosenMealIds.push(id);
      }
    }

    const today = DateTime.now();
    const lastMonday = getLastMonday(today);
    let currentDateIteration = lastMonday;
    const mealPlans: MealPlan[] = [];
    chosenMealIds.forEach((val) => {
      mealPlans.push({
        date: currentDateIteration,
        meal: meals.value.find((x) => x.id === val)!
      });
      currentDateIteration = currentDateIteration.plus({ days: 1 });
      console.log(currentDateIteration.day);
    });
    console.log(mealPlans);
  }

  function getLastMonday(today: DateTime): DateTime {
    const dayOfTheWeek = today.weekday;
    //7 represents sunday
    const monday = 1 - dayOfTheWeek;
    return today.minus({
      days: monday * -1
    });
  }

  function getRandomId(ids: number[]) {
    return ids[Math.floor(Math.random() * ids.length)];
  }

  return {
    meals,
    getAllMeals,
    saveMeal,
    planMeals
  };
});
