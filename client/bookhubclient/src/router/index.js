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
    },
    {
      path: '/userProfile/publishedGoods',
      name: 'publishedGoodsView',
      component: () => import('@/views/otherAndYourProfile/child3Views/yourProfilePublishedGoodsView.vue')
    },
    {
      path: '/userProfile/BroughtGoods',
      name: 'broughtGoodsView',
      component: () => import('@/views/otherAndYourProfile/child3Views/yourProfileBroughtGoodsView.vue')
    },
    {
      path:'/userProfile/otherProfile',
      name:'otherProfile',
      component:()=>import('@/views/otherAndYourProfile/otherProfileView.vue')
    }

  ]
})

export default router
