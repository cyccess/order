<template>
  <div id="app">
    <view-box ref="viewBox">
      <router-view/>
      <tabbar>
        <tabbar-item link="/list">
          <span slot="icon" class="icon icon-goods"></span>
          <span slot="label">首页</span>
        </tabbar-item>
        <tabbar-item link="/list">
          <span slot="icon" class="icon icon-goods"></span>
          <span slot="label">商品</span>
        </tabbar-item>
        <tabbar-item badge="2" link="/shoppingCart">
          <span slot="icon" class="icon icon-cart"></span>
          <span slot="label">购物车</span>
        </tabbar-item>
        <tabbar-item selected link="/myOrder">
          <span slot="icon" class="icon icon-my"></span>
          <span slot="label">我的订单</span>
        </tabbar-item>
      </tabbar>
    </view-box>
  </div>
</template>

<script>
  import {ViewBox, Tabbar, TabbarItem} from 'vux'

  export default {
    components: {
      ViewBox,
      Tabbar,
      TabbarItem
    },
    name: 'App'
  }
</script>
<style lang="less">
  @import '~vux/src/styles/reset.less';
  @import '~vux/src/styles/1px.less';

  .weui-tabbar__icon .icon {
    font-size: 24px;
    line-height: 24px;
  }
</style>

