<template>
  <div>
    <tabbar style="position: fixed">
      <tabbar-item v-for="(item,index) in list" :key="index" :link="item.link" :selected="item.selected">
        <span slot="icon" :class="['icon',item.icon]"></span>
        <span slot="label">{{item.title}}</span>
      </tabbar-item>
    </tabbar>
  </div>
</template>

<script>
  import {Tabbar, TabbarItem} from 'vux'

  export default {
    components: {
      Tabbar,
      TabbarItem
    },
    props: {
      selected: 0
    },
    data() {
      return {
        list: [
          {icon: 'icon-home', title: '首页', link: '/Home', selected: false, badge: 0},
          {icon: 'icon-goods', title: '商品', link: '/list', selected: false, badge: 0},
          {icon: 'icon-cart', title: '购物车', link: '/shoppingCart', selected: false, badge: 0},
          {icon: 'icon-my', title: '我的订单', link: '/myOrder', selected: false, badge: 0},
        ],
        userType:0,
      }
    },
    mounted(){
      if (this.selected >= 0 && this.selected < this.list.length) {
        this.list[this.selected].selected = true;
      }
    },
    created(){
      let usertype =  this.$cookies.get("cx_usertype");
      if(usertype){
        this.userType = Number(usertype);
        if(this.userType === 1){
          this.list[3].link = '/order/list';
        }
      }
    }
  }
</script>

<style scoped>
  .weui-tabbar__icon .icon {
    font-size: 24px;
    line-height: 24px;
  }
</style>
