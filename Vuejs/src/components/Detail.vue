<template>
  <div class="m-goodDetail" v-if="model">
    <div class="m-goodImg">
      <swiper :list="imgList" v-model="imgIndex" height="300px"></swiper>
    </div>
    <div class="m-content">
      <div class="m-info">
        <div class="name">{{model.goods.goodsName}}</div>
        <div class="price">¥ {{model.price|money}}</div>
      </div>
    </div>
    <div class="m-detail">
      <div class="line vux-1px-b">编码：{{model.goods.goodsCode}}</div>
      <div class="line vux-1px-b">品牌：{{model.goods.brand.name}}</div>
      <div class="line vux-1px-b">规格：{{model.goods.goodsSepc}}</div>
      <div class="line">单位：{{model.goods.goodsUnit}}</div>
    </div>
    <div class="m-btnGroup">
      <div class="m-btnInner">
        <div class="m-btnEmpty"></div>
        <button @click="addToCart(model.goods.id)" class="btn w-button">加入购物车</button>
      </div>
    </div>
  </div>
</template>

<script>
  import {Swiper} from 'vux'

  export default {
    components: {
      Swiper
    },
    data() {
      return {
        model: null,
        imgList:[],
        imgIndex:0,
        id: 0
      }
    },
    created() {
      this.id = this.$route.query.id;
      this.getData();
    },
    methods: {
      async getData() {
        let res = await this.$http.post('/api/sell/details', {id: this.id});
        this.model = res.data;
        this.imgList.push({url:'javascript:;',img:this.model.goods.goodsImg});
      },
      async addToCart(goodsId) {
        let sid = this.$cookies.get("cx_sid");
        if(!sid){
          this.$router.push({path: "/login",  query: {redirect: this.$route.fullPath}});
          return;
        }

        let res = await this.$http.post('/api/shoppingCart/AddCart', {goodsId: goodsId});
        if (res.code === 100) {
          this.$vux.toast.show({
            text: res.message
          });
        }
      },
    }
  }
</script>

<style scoped>
  .m-content{
    position: relative;
    padding: .83333rem 0 .83333rem .8rem;
    border-bottom: .26667rem solid #f4f4f4;
    display: flex;
    background-color: #fff;
    margin-bottom: .875rem;
  }

  .m-info{
    flex: 1;
  }
  .name{font-size: 1.2rem;}

  .price{
    font-size: 1.2rem;
    color: #f23030;
    font-weight: 700;
  }

  .m-detail{
    padding: .83333rem 0 .83333rem .8rem;
    background-color: #fff;
    font-size: .875rem;
  }
  .line{
    min-height: 2.4rem;
    line-height: 2.4rem;
  }

  .m-btnGroup{
    position: relative;
    z-index: 4;
  }

  .m-btnInner{
    display: flex;
    position: fixed;
    bottom: 0;
    left: 50%;
    width: 100%;
    background-color: #fff;
    flex-flow: row nowrap;
    transform: translateX(-50%);
  }

  .m-btnEmpty{
    width: 16rem;
  }
  .m-btnGroup .btn{
    flex-grow: 1;
    align-items: center;
    justify-content: center;
    height: 3.38667rem;
    border-radius: 0;
  }
</style>
