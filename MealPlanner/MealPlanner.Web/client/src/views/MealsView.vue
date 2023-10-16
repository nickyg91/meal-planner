<script lang="ts" setup>
import { useMealPlannerStore } from '@/stores/meal-planner.store';
import { onMounted, ref } from 'vue';
import MultiSelect from 'primevue/multiselect';
import Card from 'primevue/card';
import Button from 'primevue/button';
import Dialog from 'primevue/dialog';
import AddMealForm from '@/components/AddMealForm.vue';
const store = useMealPlannerStore();
const showAddDialog = ref(false);

onMounted(async () => {
  await store.getAllMeals();
});

function addMealClicked(): void {
  showAddDialog.value = true;
}
</script>
<template>
  <div>
    <Card class="flex flex-auto p-3 align-content-between">
      <template #content>
        <div class="flex flex-grow-1">
          <div class="flex mr-2">
            <MultiSelect :options="store.meals" option-label="name" option-value="id"></MultiSelect>
          </div>
          <div class="flex">
            <Button @click="addMealClicked">Add</Button>
          </div>
        </div>
      </template>
    </Card>
    <Dialog :closable="true" v-model:visible="showAddDialog">
      <AddMealForm></AddMealForm>
    </Dialog>
  </div>
</template>
<style scoped></style>
