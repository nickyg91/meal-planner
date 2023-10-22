<script lang="ts" setup>
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import { Meal } from '@/shared/models/meal.model';
import { useMealPlannerStore } from '@/stores/meal-planner.store';
import { toTypedSchema } from '@vee-validate/zod';
import * as zod from 'zod';
import { useForm } from 'vee-validate';
const store = useMealPlannerStore();

const zodSchema = zod.object({
  name: zod.string().min(1, {
    message: 'Meal Name is required.'
  })
});

const mealNameFieldSchema = toTypedSchema(zodSchema);

const { errors, values } = useForm({
  validationSchema: mealNameFieldSchema
});

async function mealSubmitted(): Promise<void> {
  await store.saveMeal(values as Meal);
}
</script>

<template>
  <div class="p-5">
    <div class="flex flex-column mb-3">
      <span class="p-float-label">
        <InputText
          :class="{ 'p-invalid': errors.name }"
          name="name"
          id="name"
          v-model="values.name"
        ></InputText>
        <label for="name">Meal Name</label>
      </span>
      <div v-if="errors.name" class="mt-2 text-red-200">
        {{ errors.name }}
      </div>
    </div>
    <div class="flex flex-auto justify-content-end">
      <Button @click="mealSubmitted"> Add </Button>
    </div>
  </div>
</template>
<style lang="scss" scoped></style>
