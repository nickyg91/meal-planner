<script lang="ts" setup>
import SideDrawer from '@/components/SideDrawer.vue';
import { useMealPlannerStore } from '@/stores/meal-planner.store';
import { onMounted, ref } from 'vue';
import MultiSelect from 'primevue/multiselect';
import Dialog from 'primevue/dialog';
import AddMealForm from '@/components/AddMealForm.vue';
import Button from 'primevue/button';

const store = useMealPlannerStore();
const showAddDialog = ref(false);
function addMealClicked(): void {
  showAddDialog.value = true;
}
onMounted(async () => {
  await store.getAllMeals();
});
</script>
<template>
  <div>
    <SideDrawer :meals="store.meals">
      <template #title> Meal Planner </template>
      <template #content>
        <div class="flex flex-column p-1">
          <div class="flex mb-2">
            <MultiSelect
              class="w-full"
              :options="store.meals"
              option-label="name"
              option-value="id"
            ></MultiSelect>
          </div>
          <div class="flex">
            <Button
              styleClass="text-center"
              class="w-full"
              @click="addMealClicked"
              label="Add"
            ></Button>
          </div>
        </div>
      </template>
    </SideDrawer>
    <Dialog :draggable="false" :modal="true" :closable="true" v-model:visible="showAddDialog">
      <AddMealForm></AddMealForm>
    </Dialog>
  </div>
</template>
<style scoped></style>
