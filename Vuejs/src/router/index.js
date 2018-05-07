import MyOrder from '@/components/MyOrder'
import OrderDetail from '@/components/OrderDetails'
import Home from '@/components/Home'
import List from '@/components/List'
import Detail from '@/components/Detail'
import ShoppingCart from '@/components/ShoppingCart'
import OrderConfirm from '@/components/OrderConfirm'
import SubmitOrderSuccess from '@/components/SubmitOrderSuccess'


export default [
  {
    path: '/',
    name: 'home',
    component: Home,
    meta: {title: '首页'}
  },
  {
    path: '/myOrder',
    name: 'myOrder',
    component: MyOrder,
    meta: {title: '我的订单'}
  },
  {
    path: '/list',
    name: 'list',
    component: List,
    meta: {title: '商品列表'}
  },
  {
    path: '/detail',
    name: 'detail',
    component: Detail,
    meta: {title: '商品详情'}
  },
  {
    path: '/shoppingCart',
    name: 'shoppingCart',
    component: ShoppingCart,
    meta: {title: '购物车'}
  },
  {
    path: '/orderConfirm',
    name: 'orderConfirm',
    component: OrderConfirm,
    meta: {title: '订单结算'}
  },
  {
    path: '/submitOrderSuccess',
    name: 'submitOrderSuccess',
    component: SubmitOrderSuccess,
    meta: {title: '订单提交'}
  },
  {
    path: '/orderDetail',
    name: 'orderDetail',
    component: OrderDetail,
    meta: {title: '订单详情'}
  },
  {
    path: '/order',
    name: 'order',
    component: resolve => require(['@/components/trade/Index.vue'], resolve),
    children: [
      {
        path: 'list',
        component: resolve => require(['@/components/trade/List.vue'], resolve),
        meta: {title: '订单列表'}
      },
      {
        path: 'detail',
        component: resolve => require(['@/components/trade/Detail.vue'], resolve),
        meta: {title: '订单详情'}
      }
    ]
  }
]
