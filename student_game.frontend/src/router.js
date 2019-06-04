import Vue from 'vue'
import Router from 'vue-router'
import Main from './views/Main.vue'
import Dashboard from './views/Dashboard.vue'
import Home from './views/Home.vue'
import Fightboard from './views/Fightboard.vue'
import Shopboard from './views/Shopboard.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Main',
      component: Main
    },
    {
      path: '/dashboard',
      name: 'Dashboard',
      component: Dashboard,
      children: [
        {
          path: '/home',
          name: 'Home',
          component: Home
        },
        {
          path: '/fightboard',
          name: 'Fight',
          component: Fightboard
        },
        {
          path: '/shopboard',
          name: 'Shopboard',
          component: Shopboard
        }
      ]
    }
  ]
})
