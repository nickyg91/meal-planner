<script setup lang="ts">
import ProgressSpinner from 'primevue/progressspinner';
const props = defineProps<{ show: boolean }>();
</script>
<template>
  <div v-if="props.show" class="loading-spinner flex justify-content-center align-items-center">
    <ProgressSpinner></ProgressSpinner>
  </div>
</template>

<style scoped>
.loading-spinner {
  top: 0;
  background: rgba(255, 255, 255, 0.3);
  height: 100%;
  width: 100%;
  position: absolute;
  z-index: 1101;
}
</style>
