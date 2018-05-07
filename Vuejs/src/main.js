// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import Router from 'vue-router'
import routes from './router'
import FastClick from 'fastclick'
import VueScroller from 'vue-scroller'
import qs from 'qs';
import {AjaxPlugin, ConfirmPlugin, ToastPlugin} from 'vux'

import './assets/fonts/iconfont.css'
import './assets/m.css'

Vue.use(Router);
Vue.use(AjaxPlugin);
Vue.use(VueScroller);
Vue.use(ConfirmPlugin);
Vue.use(ToastPlugin);

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

  request.headers["UID"] = "111111111111";

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
  window.document.title = to.meta.title;

  let notLoginPage = ['list', 'home', 'detail', 'login', 'register', 'clear'];
  if (notLoginPage.indexOf(to.name) < 0) {
    // var user = getUser();
    // if (user == null) {
    //   window.location = '/api/login'
    // }
  }
  next();
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
    return "已发货";
  if (value === 99)
    return "已取消";
});

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  render: h => h(App)
})
