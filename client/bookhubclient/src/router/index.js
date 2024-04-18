import { createRouter, createWebHistory } from 'vue-router'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('@/views/HomeView.vue')
    },
    {
      path: '/userProfile',
      name: 'userProfile',
        component: () => import('@/views/otherAndYourProfile/YourProfileView.vue')
    },
    {
      path: '/userProfile/soldGoods',
      name: 'soldGoodsView',
      component: () => import('@/views/otherAndYourProfile/YourProfileSoldGoodsView.vue')
    }

  ]
})

export default router
