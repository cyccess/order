<template>
    <div>
      <div class="m-shipAddress" v-if="shop">
        <h4 class="m-title">收货人信息</h4>
        <div class="m-address-item">
          <span class="item-label">店铺名称：</span>
          <div class="item-value">{{shop.name}}</div>
        </div>

        <div class="m-address-item">
          <span class="item-label">收货人：</span>
          <div class="item-value">{{shop.linkman}}</div>
        </div>

        <div class="m-address-item">
          <span class="item-label">地址：</span>
          <div class="item-value">{{shop.address}}</div>
        </div>

        <div class="m-address-item">
          <span class="item-label">手机号码：</span>
          <div class="item-value">{{shop.phone}}</div>
        </div>
      </div>

    <ul class="m-list">
      <li @click="onDetailClick(item.goodsId)" v-for="item in goodList" class="item">
        <div class="m-listItem vux-1px-b">
          <div class="m-colGood">
            <img :src="item.img" alt="">
          </div>
          <div class="m-info">
            <div class="line">
              <div class="name">{{item.name}}</div>
              <div class="count">x{{item.num}}</div>
            </div>
            <div class="line">
              <div class="price">¥ {{item.price | money}}</div>
            </div>
          </div>
        </div>
      </li>
    </ul>

    <div class="m-mainViewFt" v-if="orderInfo">
      <div class="main">
        <div class="actualPrice">
          <span>应付总额：</span>
          <span class="count">¥ {{orderInfo.totalAmount | money}}</span>
        </div>
        <a @click="submitOrder" class="btn w-button" href="javascript:;">提交订单</a>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        goodList:[],
        orderInfo: null,
        shop: null,
        oid:0,
      }
    },
    created() {
      this.oid = this.$route.query.oid;
      this.getData()
    },
    methods: {
      async getData() {
        let res = await this.$http.post('/api/Order/OrderConfirm',{oid: this.oid});
        this.goodList = res.orderRecordDetails;
        this.shop = res.shop;
        this.orderInfo = res.orderRecord;
      },
      async submitOrder(){
        let res = await this.$http.post('/api/Order/SubmitOrder',{oid: this.oid});

        if(res.code === 100){
          this.$router.push({path:"/submitOrderSuccess",query:{oid:res.data}});
        }
      },
      onDetailClick(id){
        this.$router.push({path:"/detail",query:{id:id}});
      }
    }
  }
</script>
<style scoped>
  .m-shipAddress{
    background-color: #fff;
    padding-left: 1rem;
    padding-top: .875rem;
    padding-bottom: .875rem;
    margin-bottom: .875rem;
  }
  .m-title{
    color:#555;
    margin-bottom: .4rem;
  }
  .m-address-item{
    font-size: .875rem;
    overflow: hidden;
  }
  .item-label{
    float: left;
    margin-right: 1em;
    min-width: 5em;
    color: #666;
    text-align: justify;
    text-align-last: justify;
  }
  .item-value{
    display: block;
    overflow: hidden;
    word-break: normal;
    word-wrap: break-word;
  }

  .m-list {
    display: block;
    padding-left: .938rem;
    background-color: #fff
  }
  .m-list>.item{position: relative; list-style: none;}

  .m-listItem{
    display: flex;
    flex-flow: row nowrap;
    align-items: center;
    padding: .875rem .875rem;
  }
  .m-list .m-listItem{
    padding-left: 0;
  }
  .m-colGood{
    flex-shrink: 0;
    position: relative;
    float: left;
    margin-right: .56667rem;
    overflow: hidden;
    border-radius: 4px;
    background-color: #f4f4f4
  }

  .m-colGood img{
    width: 4.86667rem;
    height: 4.86667rem;
    display: block;
  }
  .m-info{
    flex: 1;
  }

  .m-info .line{
    line-height: 1.55333rem;
    font-size: .87333rem;
    margin-bottom: .09333rem;
    overflow: hidden;
  }

  .m-info .line .name {
    text-overflow: ellipsis;
    white-space: nowrap;
    overflow: hidden;
    float: left;
    max-width: 16em
  }
  .m-info .line .count {
    float: right;

  }

  .m-mainViewFt{
    position: fixed;
    left: 0;
    bottom: 0;
    z-index: 1;
    display: block;
    width: 100%;
  }

  .m-mainViewFt .main {
    zoom:1;
    height: 3.28rem;
    padding-left: .4rem;
    background-color: #fff;
    border-top: 1px solid rgba(0,0,0,.2)
  }

  .m-mainViewFt .main .actualPrice {
    float: left;
    line-height: 3.28rem;
    font-size: .8753rem;
  }

  .m-mainViewFt .main .actualPrice .count {
    color:#e4393c;
    font-weight: 700;
  }

  .m-mainViewFt .main .btn {
    float: right;
    width: 7.01333rem;
    height: 3.28rem;
    line-height: 3.28rem;
    border-radius: 0;
  }
</style>
