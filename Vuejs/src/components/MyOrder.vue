<template>
<div>
  <tab>
    <tab-item selected @on-item-click="chooseTab(0)">全部订单</tab-item>
    <tab-item @on-item-click="chooseTab(1)">待收货</tab-item>
    <tab-item @on-item-click="chooseTab(10)">已完成</tab-item>
    <tab-item @on-item-click="chooseTab(99)">已取消</tab-item>
  </tab>

  <div class="m-orderList">
    <scroller :on-refresh="refresh" :on-infinite="infinite" ref="myscroller" :no-data-text="noData">
      <div v-for="(item,index) in list" :key="index" @click="go(item.orderRecord.id)" class="m-orderItem">
        <div class="line">
          <span class="orderId">
              <span>订单编号：{{item.orderRecord.id}}</span>
          </span>
          <div @click.stop.prevent="cancelOrder(index)" v-if="item.orderRecord.status===1" class="order-cancel">取消订单</div>
        </div>
        <div class="goods-detail">
          <div v-if="item.orderRecordDetailList.length===1">
            <div class="goodImg">
              <div class="wraper">
                <img :src="item.orderRecordDetailList[0].img">
              </div>
            </div>
            <div class="goodInfo">
              <div class="goodName">{{item.orderRecordDetailList[0].name}}</div>
            </div>
            <div class="goodStatus">
              <div class="packageStatus">
                {{item.orderRecord.status|orderState}}
              </div>
            </div>
          </div>
          <div v-else>
            <div v-for="(good,index) in item.orderRecordDetailList" v-if="index<3" class="goodImg ">
              <div class="wraper">
                <img :src="good.img">
              </div>
            </div>
            <div class="goodStatus">
              <div class="packageStatus">
                {{item.orderRecord.status|orderState}}
              </div>
            </div>
          </div>
        </div>
      </div>
    </scroller>
  </div>
  <toolbar :selected="3"></toolbar>
</div>
</template>

<script>
  import Toolbar from '@/components/Toolbar.vue'
  import {Tab, TabItem} from 'vux'
  export default {
    components: {
      Toolbar, Tab, TabItem
    },
    data() {
      return {
        list: [],
        page: 0,
        noData: '',
        state:0,
      }
    },
    created() {

    },
    methods: {
      chooseTab(state){
        this.state = state;
        this.page = 0;
        this.noData = '';
        this.list = [];
        this.$refs.myscroller.finishInfinite(false);
      },
      refresh(done) {
        this.list = [];
        this.page = 0;
        this.noData = '';
        done();
      },
      async infinite(done) {
        if (this.noData) {
          done();
          return;
        }

        this.page += 1;
        let res = await this.$http.post('/api/Order', {page: this.page,status:this.state});

        if (res.code === 100) {
          if (res.data.length < 10) {
            this.noData = '没有更多了';
          }
          this.list = [...this.list, ...res.data];
        }
        else {
          if (this.list.length === 0) {
            this.noData = "暂无数据";
          }
        }
        done();
      },
      async cancelOrder(index) {
        let order = this.list[index].orderRecord;
        const _this = this;
        this.$vux.confirm.show({
          content: '是否取消此订单?',
          confirmText: "是",
          cancelText: "否",
          onCancel() {
          },
          async onConfirm() {
            let res = await _this.$http.post('/api/Order/CancelOrder', {id: order.id});
            if (res.code === 100) {
              order.status = 99;//订单取消
            }
          }
        })
      },
      go(oid) {
        this.$router.push({path: "/orderDetail", query: {oid: oid}});
      }
    }
  }
</script>

<style scoped>
  /*订单*/
  .m-orderList {
    position: absolute;
    top:0;
    left: 0;
    bottom: 0;
    width: 100%;
    margin-top: 44px;
  }

  .m-orderItem {
    margin-top: .56667rem;
    padding-left: .75rem;
    background-color: #fff;
    font-size: .87333rem;
  }

  .m-orderItem .orderId {
    display: inline-block;
    height: 3.06667rem;
    line-height: 3.06667rem;
    margin-right: .4rem;
  }

  .m-orderItem .order-cancel {
    float: right;
    height: 3.06667rem;
    line-height: 3.06667rem;
    margin-right: .875rem;
    font-size: .87333rem;
    color: #333;
  }

  .m-orderItem .goods-detail {
    position: relative;
    padding: .93333rem 0;
    border-top: 1px solid rgba(0, 0, 0, .09);
    overflow: hidden;
  }

  .m-orderItem .goodImg {
    float: left;
    background-color: #fff;
    display: flex;
  }

  .m-orderItem .goodImg .wraper {
    background-color: #f4f4f4;
    position: relative;
    width: 4.86667rem;
    height: 4.86667rem;
    margin-right: .56667rem;
  }

  .m-orderItem .goodImg img {
    width: 100%;
    height: 100%;
  }

  .m-orderItem .goodName {
    width: 12.33333rem;
    height: 1.56rem;
    text-overflow: ellipsis;
    overflow: hidden;
    white-space: nowrap
  }

  .m-orderItem .goodInfo {
    float: left;
    margin-left: .26667rem;
    margin-top: .4rem;
    width: 4rem;
  }

  .m-orderItem .goodStatus {
    float: right;
    margin-right: .875rem;
    margin-top: 1.63rem;
    min-width: 3rem;
    text-align: right;
  }

  .m-orderItem .packageStatus {
    color: #b4282d
  }

</style>
