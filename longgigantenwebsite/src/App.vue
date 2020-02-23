<template>
  <div id="app">

    <img alt="Vue logo" src="./assets/logo.png" style="width: 5rem ;height:  auto;">
    <ul class="nav nav-tabs">

    <li class="nav-item">
      <router-link class="btn" to="/">Home</router-link>
      <router-link class="btn" to="/products">Products</router-link>
      <router-link class="btn" to="/products">Cart</router-link>
      <router-link class="btn" to="/products">Profile</router-link>
      <router-link class="btn" to="/login">Login</router-link>

    </li>

  </ul>

    <div id="currentPage">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
  /*<ProductList v-bind:is="currentTabComponent" class="tab"></ProductList>
      <HelloWorld v-bind:is="currentTabComponent" msg='Welcome to Your Vue.js App'/>

   */
import Home from './components/HelloWorld.vue';
import Products from "@/components/ProductList";
import Login from "@/components/Login";
import Vue from 'vue';
import  VueRouter from 'vue-router';
Vue.use(VueRouter)

  const router = new VueRouter({
    mode: 'history',
    routes: [
      {path: '/', component : Home},
      {path: '/products', component : Products, meta: {
          requiresAuth: true,
          roles: ['User','Admin']
        }},
      {path: '/login', component : Login,meta: {
          requiresAuth: true,
          roles: ['User','Admin']
        }}
    ]
  });

export default {
  name: 'App',
  router : router
}

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  }


 .tab-button {
   padding: 6px 10px;
   border-top-left-radius: 3px;
   border-top-right-radius: 3px;
   border: 1px solid #ccc;
   cursor: pointer;
   background: #f0f0f0;
   margin-bottom: -1px;
   margin-right: -1px;
 }
.tab-button:hover {
  background: #e0e0e0;
}
.tab-button.active {
  background: #e0e0e0;
}
.tab {
  border: 1px solid #ccc;
  padding: 10px;
}

</style>
