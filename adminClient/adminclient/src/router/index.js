import { createRouter, createWebHistory } from 'vue-router'
import loginView from "@/components/loginView.vue";
import signUpView from "@/components/signUpView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'login',
      component: loginView
    },
    {
      path: '/signUp',
      name: 'signUp',
      component: signUpView
    }
  ]
})

export default router
