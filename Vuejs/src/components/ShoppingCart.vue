<template>
  <div class="cart-content">
    <div class="cart-list">
      <swipeout>
        <swipeout-item transition-mode="follow" v-for="(item,index) in carts" :key="index" class="item">
          <div slot="right-menu">
            <swipeout-button @click.native="remove(index)" type="warn">删除</swipeout-button>
          </div>
          <div slot="content" class="goods">
            <check-icon  @click.native="chooseItem(index)" :value.sync="item.checked"></check-icon>
            <div class="content vux-1px-b">
              <div class="image">
                <img :src="item.goodsImg" alt=""/>
              </div>

              <div class="info">
                <div class="name">
                  <router-link :to="{path:'/detail',query:{id:item.goodsId}}">
                    {{item.goodsName}}
                  </router-link>
                  <a></a>
                </div>
                <p class="sku disabled">规格:{{item.goodsSepc}}</p>
                <div class="goods_line">
                  <p class="price">
                    <span>¥{{item.price | money}}</span>
                  </p>
                  <div class="num_and_more">
                    <x-number @on-change="replaceUpdate(index)" :min="1" :max="99" width="40px" v-model="item.num"></x-number>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </swipeout-item>
      </swipeout>
    </div>

    <div class="m-billing">
      <div class="m-billingCon">
        <div class="checkAll">
          <check-icon @click.native="chooseAll" :value.sync="checkAll">已选({{totalCount}})</check-icon>
        </div>

        <div class="total">
          <span>¥{{priceSum | money}}</span>
        </div>
      </div>
      <div @click="preOrder" class="btn w-button" :class="{disabled: !isSubmit}">下单</div>
    </div>

    <div class="m-defaultPage" v-if="isShowCartEmpty">
      <div class="cart-empty">
        <div class="img"></div>
        <p class="txt">购物车是空的~</p>
      </div>
    </div>

    <toolbar :selected="2"></toolbar>
  </div>
</template>

<script>
  import {CheckIcon, XNumber, Swipeout, SwipeoutItem, SwipeoutButton} from 'vux'
  import Toolbar from '@/components/Toolbar.vue'

  export default {
    components: {
      CheckIcon, XNumber, Swipeout, SwipeoutItem, SwipeoutButton,Toolbar
    },
    computed: {
      totalCount:function () {
        let count = 0;
        let sum = 0;
        this.carts.forEach(item => {
          if(item.checked){
            count += 1;
            sum += item.price * item.num;
          }
        });
        this.priceSum = sum;
        return count;
      },
      isSubmit:function () {
        return this.totalCount > 0
      }
    },
    data() {
      return {
        data: {},
        carts:[],
        isShowCartEmpty:false,
        checkAll:false,
        priceSum:0
      }
    },
    created() {
      this.getData();
    },
    methods: {
      async getData() {
        let res = await this.$http.get('/api/ShoppingCart');
        this.data = res.data;
        this.carts = res.data.shoppingCartGoodsModels;
        this.checkAll = res.data.checkedAll;
        if(this.carts.length === 0){
          this.isShowCartEmpty = true;
        }
      },
      async remove(index){
        let cartGoods = this.carts[index];
        let res = await this.$http.post('/api/ShoppingCart/Remove',{id: cartGoods.id});
        if (res.code === 100) {
          this.carts.splice(index, 1);
        }
        if (this.carts.length === 0) {
          this.isShowCartEmpty = true;
        }
      },
      async replaceUpdate(index) {
        let cart = this.carts[index];
        cart.checked = true;
        await this.$http.post('/api/ShoppingCart/Quantity',{id: cart.id,num:cart.num});
      },
      async chooseItem(index) {
        this.checkAll = this.carts.length === this.totalCount;
        let item = this.carts[index];
        await this.$http.post('/api/ShoppingCart/CartGoodsSelected',{id: item.id});
      },
      async chooseAll() {
        this.carts.forEach(item=>{
          item.checked = this.checkAll;
        });
        await this.$http.post('/api/ShoppingCart/CartGoodsSelected',{checkedAll:this.checkAll});
      },
      async preOrder(){
        if(!this.isSubmit) return;

        let cartIds = [];
        this.carts.forEach(item=>{
          if(item.checked){
            cartIds.push(item.id);
          }
        });
        let res = await this.$http.post('/api/ShoppingCart/PreOrder',{cartIds:cartIds},{
          headers:{
            "Content-Type":"application/json"
          }
        });

        if(res.code===100){
          this.$router.push({path:"/orderConfirm",query:{oid:res.data.oid}});
        }
      }
    },
    watch: {

    }
  }
</script>

<style scoped>
  .cart-content {
    position: relative;
    padding-bottom: 52px;
  }

  .cart-list .item {
    position: relative;
    font-size: .87333rem;
  }

  .cart-list .item .goods {
    min-height: 75px;
    padding: 12px 10px 0 45px;
    background-color: #fff;
  }

  .cart-list .item .vux-check-icon {
    position: absolute;
    left:0;
    top: 0;
    bottom: 0;
    padding-top: 35px;
    padding-left: 10px;
  }

  .cart-list .item .image {
    width: 75px;
    height: 75px;
    margin-right: 10px;
  }

  .cart-list .item .image img {
    width: 100%;
    height: 100%;
  }

  .cart-list .goods .content {
    min-height: 75px;
    display: flex;
  }

  .cart-list .goods .content .info {
    flex: 1;
  }

  .cart-list .goods .name {
    margin-bottom: .25rem;
  }

  .goods .name a {
    color: #333;
  }

  .vux-cell-primary .vux-number-input {
    font-size: .875rem;;
  }

  .weui-cell{padding: 5px 0;}

  .goods .sku {
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    position: relative;
    background-color: #fff;
    font-size: .82rem;
    color: #666;
    margin: 8px 0 10px;
    padding: 5px 25px 4px 5px;
    border: 1px solid #e5e5e5;
    border-radius: 2px
  }

  .goods .sku.disabled {
    padding: 0;
    border: none;
    margin: 0
  }

  .goods .goods_line {
    position: relative;
    display: -webkit-box;
    display: -webkit-flex;
    display: flex;
    -webkit-box-align: center;
    -webkit-align-items: center;
    align-items: center;
    margin: 0 0 2px;
  }

  .goods .goods_line .price {
    -webkit-box-flex: 1;
    -webkit-flex: 1;
    flex: 1;
    line-height: 16px;
    color: #e4393c;
    font-size: 16px;
    font-family: Arial;
  }

  .vux-1px-b:after {
    border-bottom-color: #d9d9d9;
  }

  .m-defaultPage{
    position: fixed;
    top: 0;
    left: 0;
    bottom: 0;
    z-index: 0;
    width: 100%;
    background-color: #f4f4f4;
    text-align: center;
  }
  .cart-empty{
    position: absolute;
    top:0;
    left: 0;
    right: 0;
    bottom: 0;
    height: 140px;
    margin: auto;
  }
  .cart-empty .img{
    display: inline-block;
    width: 100px;
    height: 100px;
    background: url("../assets/empty-cart.png") no-repeat;
    background-size: 100px 100px;
  }
  .cart-empty .txt{color:#666;}

  .m-billing{
    position: fixed;
    z-index: 3;
    bottom: 53px;
    left: 0;
    width: 100%;
    background-color: #fff;
  }

  .m-billing .total{
    flex: 1;
    text-align: right;
    padding-right: 140px;
    color:#f23030;
  }

  .m-billingCon{
    display: flex;
    height: 45px;
    line-height: 45px;
    padding-left: 10px;
  }

  .m-billingCon .checkAll{

  }

  .btn{
    position: absolute;
    right: 0;
    top:0;
    height: 45px;
    width: 130px;
    line-height: 45px;
    border-radius: 0;
  }

  .btn.disabled{
    background-color: #ccc;
    border-color:#ccc;
  }

</style>
