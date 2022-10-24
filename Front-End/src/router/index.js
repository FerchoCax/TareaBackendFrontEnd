import Vue from 'vue'
import VueRouter from 'vue-router'
import inicio from '../views/inicio.vue';

import Editar from '../views/Editar.vue';
import Nuevo from '../views/Nuevo.vue';
 

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Dashboard',
    component: inicio
  },
  {
    path: '/editar/:id',
    name: 'Editar',
    component: Editar
  },
  {
    path: '/nuevo',
    name: 'Nuevo',
    component: Nuevo
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
