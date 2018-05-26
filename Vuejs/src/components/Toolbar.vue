<template>
  <div>
    <div class="weui-tabbar" style="position: fixed">
      <a :href="'/#'+item.link" v-for="item in  list" class="weui-tabbar__item"
         :class="[item.selected?'weui-bar__item_on':'']">
        <div style="display: inline-block;position: relative;">
          <i class="icon iconfont weui-tabbar__icon" :class="[item.icon]"></i>
        </div>
        <p class="weui-tabbar__label">{{item.title}}</p>
      </a>
    </div>
  </div>
</template>

<script>
  export default {
    props: {
      selected: 0
    },
    data() {
      return {
        list: [
          {icon: 'icon-home', title: '首页', link: '/', selected: false, badge: 0},
          {icon: 'icon-cate', title: '分类', link: '/category', selected: false, badge: 0},
          {icon: 'icon-cart', title: '购物车', link: '/shoppingCart', selected: false, badge: 0},
          {icon: 'icon-my', title: '我的', link: '/my', selected: false, badge: 0},
        ],
        userType: 0,
      }
    },
    created() {
      let usertype = this.$cookies.get("cx_usertype");
      if (usertype) {
        usertype = Number(usertype);
        if (usertype === 1) {
          // this.list[3].link = '/order/list';
        }
      }
    },
    methods: {
      init() {
        this.list[this.selected].selected = true;
      }
    },
    mounted() {
      this.init();
    },
    activated() {
      this.init();
    },
    deactivated() {
      this.init();
    }
  }
</script>

<style scoped>
  .weui-tabbar{
    display:-webkit-box;
    display:-webkit-flex;
    display:flex;
    position:absolute;
    z-index:500;
    bottom:0;
    width:100%;
    background-color:#F7F7FA;
  }
  .weui-tabbar:before{
    content:" ";
    position:absolute;
    left:0;
    top:0;
    right:0;
    height:1px;
    border-top:1px solid #C0BFC4;
    color:#C0BFC4;
    -webkit-transform-origin:0 0;
    transform-origin:0 0;
    -webkit-transform:scaleY(0.5);
    transform:scaleY(0.5);
  }
  .weui-tabbar__item{
    display:block;
    -webkit-box-flex:1;
    -webkit-flex:1;
    flex:1;
    padding:5px 0 0;
    font-size:0;
    color:#808080;
    text-align:center;
    -webkit-tap-highlight-color:rgba(0, 0, 0, 0);
  }
  .weui-tabbar__item.weui-bar__item_on .weui-tabbar__icon,
  .weui-tabbar__item.weui-bar__item_on .weui-tabbar__icon > i,
  .weui-tabbar__item.weui-bar__item_on .weui-tabbar__label{
    color:#e4393c;
  }
  .weui-tabbar__icon{
    display:inline-block;
    width:2.33rem;
    height:1.75rem;
    line-height: 1.75rem;
  }
  i.weui-tabbar__icon,
  .weui-tabbar__icon > i{
    font-size:1.5rem;
    color:#808080;
  }
  .weui-tabbar__icon img{
    width:100%;
    height:100%;
  }
  .weui-tabbar__label{
    text-align:center;
    color:#808080;
    font-size:.675rem;
    line-height:1.8;
  }
</style>
