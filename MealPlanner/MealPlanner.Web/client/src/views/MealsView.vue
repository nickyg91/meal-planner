<script lang="ts" setup>
import { useMealPlannerStore } from '@/stores/meal-planner.store';
import { computed, onMounted, ref } from 'vue';
import MultiSelect from 'primevue/multiselect';
import Dialog from 'primevue/dialog';
import AddMealForm from '@/components/AddMealForm.vue';
import Button from 'primevue/button';
import FullCalendar from '@fullcalendar/vue3';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import type { CalendarOptions, EventSourceInput } from '@fullcalendar/core/index.js';

const store = useMealPlannerStore();
const showAddDialog = ref(false);
function addMealClicked(): void {
  showAddDialog.value = true;
}
onMounted(async () => {
  await store.getAllMeals();
});

const calendarEvents = computed(() => {
  return store.pendingMealPlans.map((x) => {
    return {
      title: x.meal.name,
      date: x.date.toString(),
      displayEventTime: false
    } as EventSourceInput;
  });
});

const calendarOptions = ref({
  plugins: [dayGridPlugin, interactionPlugin],
  initialView: 'dayGridMonth',
  events: [...calendarEvents.value]
} as CalendarOptions);
</script>
<template>
  <div>
    <div class="flex p-3 mt-3">
      <div class="flex mr-2">
        <span class="p-float-label w-full">
          <MultiSelect
            id="ms-meals"
            class="w-full"
            :options="store.meals"
            option-label="name"
            option-value="id"
          ></MultiSelect>
          <label for="ms-meals">Meals</label>
        </span>
      </div>
      <div class="flex mr-2">
        <Button
          styleClass="text-center"
          class="w-full"
          @click="addMealClicked"
          label="Add Meal"
        ></Button>
      </div>
      <div class="flex">
        <Button
          @click="store.planMeals"
          styleClass="text-center"
          severity="help"
          class="w-full"
          label="Create Meal Plan"
        ></Button>
      </div>
    </div>

    <div class="p-3">
      <FullCalendar :options="calendarOptions"></FullCalendar>
    </div>
    <Dialog :draggable="false" :modal="true" :closable="true" v-model:visible="showAddDialog">
      <AddMealForm></AddMealForm>
    </Dialog>
  </div>
</template>
<style scoped></style>
