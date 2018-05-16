// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import qs from 'qs';
import Vue from 'vue'
import App from './App'
import Router from 'vue-router'
import routes from './router'
import FastClick from 'fastclick'
import VueScroller from 'vue-scroller'
import VueCookies from 'vue-cookies'

import {AjaxPlugin, ConfirmPlugin, ToastPlugin} from 'vux'

import './assets/fonts/iconfont.css'
import './assets/m.css'

Vue.use(Router);
Vue.use(AjaxPlugin);
Vue.use(VueScroller);
Vue.use(ConfirmPlugin);
Vue.use(ToastPlugin);
Vue.use(VueCookies);

Vue.config.productionTip = false

FastClick.attach(document.body);

// 请求时的拦截
AjaxPlugin.$http.interceptors.request.use((request) => {
  // 发送请求之前做一些处理
  // console.log(request)
  if (request.data) {
    let contentType = request.headers["Content-Type"]
    // contentType参数不是application/json，转换参数格式
    if (!(contentType && contentType.indexOf("application/json") > -1))
      request.data = qs.stringify(request.data);
  }

  return request;
}, error => {
  // 当请求异常时做一些处理
  return Promise.reject(error);
});

// 响应时拦截
AjaxPlugin.$http.interceptors.response.use(response => {
  if (response.status === 200) {
    console.log(response.data)
    return response.data;
  } else {
    return Promise.reject(response);
  }
}, error => {
  // 当响应异常时做一些处理
  return Promise.reject(error);
});

// globally (in your main .js file)
const router = new Router({
  routes,
  //,mode: 'history'
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      if (from.meta.keepAlive) {
        from.meta.savedPosition = document.body.scrollTop;
      }
      return {x: 0, y: to.meta.savedPosition || 0}
    }
  }
});

router.beforeEach((to, from, next) => {
  let sid = VueCookies.get("cx_sid");
  if (to.meta.requiresAuth && !sid) {
    next({
      path: '/login',
      query: {redirect: to.fullPath}
    });
  }
  else {
    window.document.title = to.meta.title;
    next();
  }
});

Vue.filter('money', function (value) {
  if (!value) return '0.00';
  value = parseFloat(value);
  return value.toFixed(2)
});


Vue.filter("orderState", function (value) {
  value = parseInt(value);
  if (value === 1)
    return "待发货";
  if (value === 10)
    return "已完成";
  if (value === 99)
    return "已取消";
});

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
