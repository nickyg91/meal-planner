<script lang="ts" setup>
import { useEventListener } from '@vueuse/core';
import { computed, onMounted, ref } from 'vue';
import Button from 'primevue/button';
const showContent = ref(false);
const drawer = ref<HTMLDivElement>();
const pinned = ref(false);
onMounted(() => {
  useEventListener(drawer, 'mouseenter', () => {
    if (!pinned.value) {
      drawer.value?.classList.add('side-drawer-show');
      showContent.value = true;
    }
  });
  useEventListener(drawer, 'mouseleave', () => {
    if (!pinned.value) {
      drawer.value?.classList.remove('side-drawer-show');
      showContent.value = false;
    }
  });
});

const icon = computed(() => {
  return pinned.value ? 'pi pi-lock' : 'pi pi-lock-open';
});

defineSlots<{
  content(props: {}): any;
  title(props: {}): any;
}>();

function lockMenuClicked(): void {
  pinned.value = !pinned.value;
  showContent.value = true;
  if (pinned.value) {
    drawer.value?.classList.add('side-drawer-show');
  } else {
    drawer.value?.classList.remove('side-drawer-show');
  }
}
</script>
<template>
  <div ref="drawer" class="side-drawer">
    <div class="flex justify-content-between mb-5">
      <div class="flex align-self-center align-content-start text-3xl">
        <slot name="title"> </slot>
      </div>
      <div class="flex justify-content-end p-1">
        <Button @click="lockMenuClicked" rounded severity="secondary" :icon="icon"> </Button>
      </div>
    </div>
    <Transition name="fade">
      <div v-if="showContent" class="content">
        <slot name="content"></slot>
      </div>
    </Transition>
  </div>
</template>
<style scoped>
.side-drawer {
  width: 260px;
  left: -195px;
  height: 100%;
  position: fixed;
  background-color: var(--bluegray-900);
  padding: 0.5em;
  z-index: 100;
}

.side-drawer-show {
  -webkit-animation: slide-in 0.15s forwards;
  -webkit-animation-delay: 0.15s;
  animation: slide-in 0.15s forwards;
  animation-delay: 0.15s;
}

.content {
  height: 100%;
}

@-webkit-keyframes slide-in {
  100% {
    left: 0;
  }
}

@keyframes slide-in {
  100% {
    left: 0;
  }
}

@-webkit-keyframes fade-in {
  100% {
    opacity: 1;
  }
}

@keyframes fade-in {
  100% {
    opacity: 1;
  }
}

@-webkit-keyframes fade-out {
  100% {
    opacity: 0;
  }
}

@keyframes fade-out {
  100% {
    opacity: 0;
  }
}

.fade-enter-active,
.fade-leave-active {
  -webkit-animation: fade-in 0.5s forwards;
  -webkit-animation-delay: 0.45s;
  animation: fade-in 0.5s forwards;
  animation-delay: 0.45s;
}

.fade-enter-from,
.fade-leave-to {
  -webkit-animation: fade-out 0.05s forwards;
  -webkit-animation-delay: 0.05s;
  animation: fade-out 0.15s forwards;
  animation-delay: 0.05s;
}
</style>
