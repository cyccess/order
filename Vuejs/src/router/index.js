import Login from '@/components/Login'
import Register from '@/components/Register'
import MyOrder from '@/components/MyOrder'
import OrderDetail from '@/components/OrderDetails'
import Home from '@/components/Home'
import Category from '@/components/Category'
import My from '@/components/My'
import Info from '@/components/Info'
import List from '@/components/List'
import Detail from '@/components/Detail'
import ShoppingCart from '@/components/ShoppingCart'
import OrderConfirm from '@/components/OrderConfirm'
import SubmitOrderSuccess from '@/components/SubmitOrderSuccess'

export default [
  {
    path: '/login',
    name: 'login',
    component: Login,
    meta: {title: '用户登录'}
  },
  {
    path: '/register',
    name: 'register',
    component: Register,
    meta: {title: '手机号注册'}
  },
  {
    path: '/',
    name: 'home',
    component: Home,
    meta: {title: '首页', keepAlive: true}
  },
  {
    path: '/category',
    name: 'category',
    component: Category,
    meta: {title: '分类', keepAlive: true}
  },
  {
    path: '/my',
    name: 'my',
    component: My,
    meta: {title: '个人中心', requiresAuth: true}
  },
  {
    path: '/info',
    name: 'info',
    component: Info,
    meta: {title: '基本信息', requiresAuth: true}
  },
  {
    path: '/myOrder',
    name: 'myOrder',
    component: MyOrder,
    meta: {title: '我的订单', requiresAuth: true}
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
    meta: {title: '购物车', requiresAuth: true}
  },
  {
    path: '/orderConfirm',
    name: 'orderConfirm',
    component: OrderConfirm,
    meta: {title: '订单结算', requiresAuth: true}
  },
  {
    path: '/submitOrderSuccess',
    name: 'submitOrderSuccess',
    component: SubmitOrderSuccess,
    meta: {title: '订单提交', requiresAuth: true}
  },
  {
    path: '/orderDetail',
    name: 'orderDetail',
    component: OrderDetail,
    meta: {title: '订单详情', requiresAuth: true}
  },
  {
    path: '/order',
    name: 'order',
    component: resolve => require(['@/components/trade/Index.vue'], resolve),
    children: [
      {
        path: 'list',
        component: resolve => require(['@/components/trade/List.vue'], resolve),
        meta: {title: '我的订单', requiresAuth: true}
      },
      {
        path: 'detail',
        component: resolve => require(['@/components/trade/Detail.vue'], resolve),
        meta: {title: '订单详情', requiresAuth: true}
      }
    ]
  }
]
