import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useLoadingStore = defineStore('loadingStore', () => {
  const isLoading = ref(false);

  function setIsLoading(loading: boolean): void {
    isLoading.value = loading;
  }

  function getIsLoading(): boolean {
    return isLoading.value;
  }

  return {
    setIsLoading,
    getIsLoading,
    isLoading
  };
});
