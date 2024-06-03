import { createRouter, createWebHistory } from 'vue-router'
import loginView from "@/views/loginView.vue";
import signUpView from "@/views/signUpView.vue";
import consoleView from "@/views/consoleView.vue";
import userListView from "@/views/userListView.vue";
import adminView from "@/views/adminView.vue";
import orderManagementView from "@/views/orderManagementView.vue";
import goodsManagementView from "@/views/goodsManagementView.vue";

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
    },
    {
      path: '/admin',
      name: 'admin',
      component: adminView,
      children: [
        {
          path: 'console',
          name: 'console',
          component: consoleView
        },
        {
          path: 'userList',
          name: 'userList',
          component: userListView
        },
        {
          path: 'orderManagement',
          name: 'orderManagement',
          component: orderManagementView
        },
        {
          path: 'goodsManagement',
          name: 'goodsManagement',
          component: goodsManagementView
        }
      ]
    }
  ]
})

export default router
