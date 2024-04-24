import { createRouter, createWebHistory } from 'vue-router'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('@/views/homeView.vue')
    },
    {
      path: '/userProfile',
      name: 'userProfile',
        component: () => import('@/views/otherAndYourProfile/yourProfileView.vue')
    },
    {
      path: '/userProfile/soldGoods',
      name: 'soldGoodsView',
      component: () => import('@/views/otherAndYourProfile/child3Views/yourProfileSoldGoodsView.vue')
    }

  ]
})

export default router
