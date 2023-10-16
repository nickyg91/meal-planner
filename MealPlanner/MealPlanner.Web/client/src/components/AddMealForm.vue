<script lang="ts" setup>
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import { ref } from 'vue';
import { Meal } from '@/shared/models/meal.model';
import { useMealPlannerStore } from '@/stores/meal-planner.store';
const store = useMealPlannerStore();
const meal = ref<Meal>(new Meal());
async function mealSubmitted(): Promise<void> {
  await store.saveMeal(meal.value);
}
</script>

<template>
  <div class="p-5">
    <div class="flex flex-auto mb-3">
      <span class="p-float-label">
        <InputText id="name" v-model="meal.name"></InputText>
        <label for="name">Meal Name</label>
      </span>
    </div>
    <div class="flex flex-auto justify-content-end">
      <Button @click="mealSubmitted"> Add </Button>
    </div>
  </div>
</template>

<style lang="scss" scoped></style>
