<template>
  <div>
    <div class="m-orderDetail" v-if="data">

      <div class="m-shipAddress">
        <h4 class="m-title">收货人信息</h4>
        <div class="m-address-item">
          <span class="item-label">店铺名称：</span>
          <div class="item-value">{{data.orderRecord.consignee}}</div>
        </div>

        <div class="m-address-item">
          <span class="item-label">地址：</span>
          <div class="item-value">{{data.orderRecord.address}}</div>
        </div>

        <div class="m-address-item">
          <span class="item-label">手机号码：</span>
          <div class="item-value">{{data.orderRecord.mobilePhone}}</div>
        </div>
      </div>


      <div class="order-state">
        <div class="state-top">
          <p>下单时间：{{data.orderRecord.orderDate}}</p>
          <p>订单编号：{{data.orderRecord.id}}</p>
        </div>

        <div class="m-orderInfo vux-1px-t">
        <span class="cost">
            <span>应付：</span>
            <span class="f-colorRed">¥ {{data.orderRecord.totalAmount|money}}</span>
        </span>

          <div v-if="data.orderRecord.status===1" class="btnGroup">
            <button @click="confirmedDeliver" class="btn w-button"><i class="icon icon-clock"></i> 确认发货</button>
            <a @click="cancelOrder" class="btn-cancel" href="javascript:;">取消订单</a>
          </div>
        </div>
      </div>

      <div class="m-package">
        <div class="packageInfo vux-1px-b">
            <span class="packageName">
                配货清单
            </span>
          <div class="packageStatus">
            <span>{{data.orderRecord.status|orderState}}</span>
          </div>
        </div>

        <ul class="m-list">
          <li @click="onDetailClick(item.goodsId)" v-for="(item,index) in data.orderRecordDetails" :key="index" class="item vux-1px-b">
            <div class="m-listItem">
              <div class="m-img">
                <img :src="item.img" alt=""/>
              </div>
              <div class="m-detail">
                <div class="line">
                  <div class="name">
                    <span>{{item.name}}</span>
                  </div>
                  <div class="count">
                    <span>x{{item.num}}</span>
                  </div>
                </div>
                <div class="line">
                  <span class="price">¥ {{item.price|money}}</span>
                </div>
              </div>
            </div>

          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        data: null,
        oid: 0,
      }
    },
    created() {
      this.oid = this.$route.query.oid;
      this.getData()
    },
    methods: {
      async getData() {
        let res = await this.$http.post('/api/Order/Detail', {orderId: this.oid});
        this.data = res.data;
      },
      async cancelOrder() {
        const _this = this;
        this.$vux.confirm.show({
          content: '是否取消此订单?',
          confirmText: "是",
          cancelText: "否",
          onCancel() {
          },
          async onConfirm() {
            let res = await _this.$http.post('/api/Trade/CancelOrder', {id: _this.oid});
            if (res.code === 100) {
              _this.data.orderRecord.status = 99;//订单取消
            }
          }
        })
      },
      async confirmedDeliver() {
        const _this = this;
        this.$vux.confirm.show({
          content: '是否已发货?',
          confirmText: "是",
          cancelText: "否",
          onCancel() {
          },
          async onConfirm() {
            let res = await _this.$http.post('/api/Trade/Delivery', {id: _this.oid});
            if (res.code === 100) {
              _this.data.orderRecord.status = 10;//订单已发货
              _this.$vux.toast.show({
                text: res.message
              });
            }
          }
        })
      },
      onDetailClick(id){
        this.$router.push({path:"/detail",query:{id:id}});
      }
    }
  }
</script>

<style scoped>
  .order-state {
    padding: .875rem 0 0 .875rem;
    background-color: #fff;
    overflow: hidden;
    position: relative;
    font-size: .875rem;
    line-height: 1;
  }

  .state-top {
    line-height: 2;
    margin-bottom: .18667rem;
    color: #666;
  }

  .state-txt span {
    font-size: .37333rem;
    color: #b4282d;
  }

  .m-shipAddress {
    background-color: #fff;
    padding-left: 1rem;
    padding-top: .875rem;
    padding-bottom: .875rem;
    margin-bottom: .375rem;
  }

  .m-title {
    color: #555;
    margin-bottom: .4rem;
  }

  .m-address-item {
    font-size: .875rem;
    overflow: hidden;
  }

  .item-label {
    float: left;
    margin-right: 1em;
    min-width: 5em;
    color: #666;
    text-align: justify;
    text-align-last: justify;
  }

  .item-value {
    display: block;
    overflow: hidden;
    word-break: normal;
    word-wrap: break-word;
  }

  .m-orderInfo {
    overflow: hidden;
    height: 3rem;
  }

  .m-orderInfo .cost {
    font-size: .87333rem;
    display: inline-block;
    height: 3rem;
    line-height: 3rem;
  }

  .btnGroup {
    float: right;
    margin-top: .31333rem;
    margin-right: .875rem;
  }

  .m-orderInfo .btn-cancel {
    float: right;
    height: 2.2rem;
    line-height: 2.2rem;
    font-size: .87333rem;
    color: #333;
    margin-right: .875rem;
  }

  .f-colorRed {
    color: #b4282d
  }

  .m-package {
    background-color: #fff;
    margin-top: .36667rem;
  }

  .m-package .packageInfo {
    height: 3rem;
    line-height: 3rem;
    margin-left: .875rem;
  }

  .m-package .packageName {
    font-size: .875rem;
  }

  .m-package .packageStatus {
    float: right;
    margin-right: .875rem;
    font-size: .87333rem;
    color: #b4282d
  }

  .m-list {
    display: block;
    padding-left: .875rem;
    background-color: #fff
  }

  .m-list > .item {
    position: relative
  }

  .m-listItem {
    display: flex;
    position: relative;
    min-height: 4.38667rem;
    padding: .875rem .875rem .875rem 0;
    overflow: hidden;
  }

  .m-listItem .m-img {
    position: relative;
    float: left;
    margin-right: .86667rem;
    overflow: hidden;
    border-radius: 4px;
    background-color: #f4f4f4;
  }

  .m-listItem .m-img img {
    width: 4.86667rem;
    height: 4.86667rem;
    display: block;
  }

  .m-detail {
    flex: 1;
  }

  .m-detail .line {
    line-height: 1.45333rem;
    font-size: .87333rem;
    margin-bottom: .09333rem;
    overflow: hidden;
  }

  .m-detail .name {
    text-overflow: ellipsis;
    white-space: nowrap;
    overflow: hidden;
    float: left;
    max-width: 14em;
  }

  .m-detail .line .count {
    float: right;
  }

  .btn{
    float: right;
    width: 5.666rem;
    line-height: 2rem;
  }

</style>
