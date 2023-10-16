<script setup lang="ts">
import ky from 'ky';
import { provide } from 'vue';
import { RouterView } from 'vue-router';
import { mealService } from './shared/injection-keys';
import { MealPlannerService } from './shared/services/meal-planner.service';
const kyInstance = ky.create({
  prefixUrl: '/api'
});

provide(mealService, new MealPlannerService(kyInstance));
</script>

<template>
  <Suspense>
    <RouterView></RouterView>
  </Suspense>
</template>

<style scoped></style>
