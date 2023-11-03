<script setup lang="ts">
import ky from 'ky';
import { provide } from 'vue';
import { RouterView } from 'vue-router';
import { mealService } from './shared/injection-keys';
import { MealPlannerService } from './shared/services/meal-planner.service';
import { useLoadingStore } from './stores/loading-spinner.store';
import LoadingSpinnerModal from './components/LoadingSpinnerModal.vue';
import Toast from 'primevue/toast';
const loadingStore = useLoadingStore();
const kyInstance = ky.create({
  prefixUrl: '/api'
});

provide(mealService, new MealPlannerService(kyInstance));
</script>

<template>
  <Toast position="top-center" group="appwideToast" />
  <Suspense>
    <RouterView class="main"> </RouterView>
  </Suspense>
  <LoadingSpinnerModal :show="loadingStore.getIsLoading()"></LoadingSpinnerModal>
</template>

<style scoped></style>
