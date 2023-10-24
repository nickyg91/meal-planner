<script lang="ts" setup>
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import { Meal } from '@/shared/models/meal.model';
import { useMealPlannerStore } from '@/stores/meal-planner.store';
import * as zod from 'zod';
import { useForm } from 'vee-validate';
import { toTypedSchema } from '@vee-validate/zod';
import { ref } from 'vue';
const store = useMealPlannerStore();
const isLoading = ref(false);
const zodSchema = zod.object({
  name: zod
    .string()
    .min(1, {
      message: 'Meal Name is required.'
    })
    .max(256, {
      message: 'Meal Name must be less than 256 characters.'
    })
    .default('')
});

const typedSchema = toTypedSchema(zodSchema);

const { errors, defineComponentBinds, handleSubmit, resetForm, meta } = useForm({
  validationSchema: typedSchema
});

const mealSubmitted = handleSubmit(async (values) => {
  if (meta.value.valid) {
    isLoading.value = true;
    await store.saveMeal(values as Meal);
    isLoading.value = false;
    resetForm();
  }
});
const mealName = defineComponentBinds('name');
</script>

<template>
  <div class="p-5">
    <div class="flex flex-column mb-3">
      <span class="p-float-label">
        <InputText
          :class="{ 'p-invalid': errors.name }"
          name="name"
          id="name"
          v-bind="mealName"
        ></InputText>
        <label for="name">Meal Name</label>
      </span>
      <div v-if="errors.name" class="mt-2 text-red-200">
        {{ errors.name }}
      </div>
    </div>
    <div class="flex flex-auto justify-content-end">
      <Button
        type="button"
        :disabled="!meta.valid"
        label="Add"
        :loading="isLoading"
        @click="mealSubmitted"
      ></Button>
    </div>
  </div>
</template>
<style lang="scss" scoped></style>
