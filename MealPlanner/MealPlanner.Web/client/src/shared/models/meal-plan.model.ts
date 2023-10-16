import type { DateTime } from 'luxon';
import type { Meal } from './meal.model';

export class MealPlan {
  meal!: Meal;
  date!: DateTime;
}
