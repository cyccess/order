<template>
<div class="m-order">
  <div class="m-iconSuccess">
    <icon type="success-circle" is-msg></icon>
  </div>
  <div class="m-orderInfo">
    <p>订单提交成功，请等待配送！</p>
    <p>订单号：{{oid}}</p>
    <p>如需帮助，请拨打电话：<span class="phone">18580760059</span></p>
  </div>

  <router-link class="m-orderDetail" :to="{name:'orderDetail',query:{oid:oid}}">
    订单详情
  </router-link>

  <div style="height: 50px;"></div>
</div>
</template>

<script>
  import { Icon } from 'vux'
    export default {
      components: {
        Icon
      },
      data() {
        return {
          oid:0,
        }
      },
      created(){
        this.oid=this.$route.query.oid;
      }
    }
</script>

<style scoped>
  .m-order{
    height: 100%;
    background-color: #fff;
    text-align: center;
  }
  .m-iconSuccess{
    padding-top: 2rem;
  }
  .m-orderInfo{
    margin-bottom: 2rem;
  }
  .m-orderInfo .phone{
    font-weight: 700;
  }
  .m-orderDetail{
    display: inline-block;
    height: 2.3333rem;
    line-height: 2.3333rem;
    width: 7rem;
    background-color: #e4393c;
    color:#fff;
    border-radius: 4px;
  }
</style>
