import type { MealPlan } from '../models/meal-plan.model';
import type { KyInstance } from 'node_modules/ky/distribution/types/ky';
import type { Meal } from '../models/meal.model';

export class MealPlannerService {
  private _httpClient?: KyInstance;
  constructor(httpClient: KyInstance) {
    this._httpClient = httpClient;
  }
  public async getMealPlanForWeek(): Promise<MealPlan[] | undefined> {
    return await this._httpClient?.get('meal-plans/this-week').json<MealPlan[]>();
  }

  public async getAllMeals(): Promise<Meal[] | undefined> {
    return await this._httpClient?.get('meals').json<Meal[]>();
  }

  public async saveMeal(meal: Meal): Promise<Meal | undefined> {
    return await this._httpClient
      ?.post('meals/save', {
        json: meal
      })
      .json<Meal>();
  }
}
