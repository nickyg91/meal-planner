import MealsView from '@/views/MealsView.vue';
import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/meals',
      component: MealsView
    },
    {
      path: '/',
      redirect: '/meals'
    }
  ]
});

export default router;
