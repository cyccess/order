<template>
  <div class="sell-goods-list">
    <scroller :on-refresh="refresh" :on-infinite="infinite" ref="myscroller" :no-data-text="noData">
      <ul class="searchlist-normal">
        <li @click="onDetailClick(item.goods.id)" v-for="(item,index) in list" :key="index" class="normal-list">
          <div class="list-body">
            <div class="pro-img">
              <img :src="item.goods.goodsImg" alt=""/>
            </div>

            <div class="product-info-box">
              <div class="product-name">
                <span>{{item.goods.goodsName}}</span>
              </div>

              <div class="product-buy">
                <div class="product-price-m">
                  <em>¥<span class="big-price">{{item.goodsPrice.price|money}}</span></em>
                </div>

                <div @click.stop="addToCart(item.goods.id)" class="product-btn add-cart">
                  <i class="icon icon-gouwuche"></i>
                </div>

              </div>
            </div>
          </div>
        </li>
      </ul>
    </scroller>

    <toolbar :selected="1"></toolbar>
  </div>
</template>

<script>
  import Toolbar from '@/components/Toolbar.vue'
  export default {
    components: {
      Toolbar,
    },
    data() {
      return {
        list: [],
        page: 0,
        noData: ''
      }
    },
    created() {

    },
    methods: {
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
        let res = await this.$http.post('/api/Sell/List', {page: this.page});

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
      async addToCart(goodsId) {
        let res = await this.$http.post('/api/shoppingCart/AddCart', {goodsId: goodsId});
        if (res.code === 100) {
          this.$vux.toast.show({
            text: res.message
          });
        }
      },
      onDetailClick(id){
        this.$router.push({path:"/detail",query:{id:id}});
      }
    }
  }
</script>

<style scoped>
  .sell-goods-list {

  }

  .searchlist-normal {
    list-style: none;
  }

  .normal-list {
    font-size: .87333rem;
    background-color: #fff;
  }

  .searchlist-normal .normal-list .list-body {
    display: -webkit-box;
    padding-bottom: 1rem;
  }

  .searchlist-normal .normal-list .list-body .pro-img {
    position: relative;
    width: 100px;
    height: 100px;
    overflow: hidden;
    text-align: center;
  }

  .searchlist-normal .normal-list .list-body img {
    display: inline-block;
    width: 100%;
    height: 100%;
  }

  .searchlist-normal .normal-list .list-body .product-info-box {
    -webkit-box-flex: 1;
    box-flex: 1;
    margin-left: 10px;
    position: relative;
    height: 100%;
    margin-top: -2px;
    padding-right: 10px;
    padding-top: 11px;
    padding-bottom: 10px
  }

  .searchlist-normal .normal-list .list-body .product-info-box:after {
    content: '';
    height: 1px;
    width: 200%;
    position: absolute;
    left: 0;
    top: auto;
    right: auto;
    bottom: -4px;
    background-color: #e3e5e9;
    border: 0px solid transparent;
    border-radius: 0px;
    -webkit-border-radius: 0px;
    transform: scale(0.5);
    -webkit-transform: scale(0.5);
    transform-origin: top left;
    -webkit-transform-origin: top left
  }

  .searchlist-normal .normal-list .list-body .product-info-box .product-name {
    color: #232326;
    line-height: 20px;
    height: 40px;
    overflow: hidden;
    text-overflow: ellipsis;
    display: -webkit-box;
    -webkit-line-clamp: 2;
    -webkit-box-orient: vertical;
    word-break: break-word
  }

  .searchlist-normal .normal-list .list-body .product-info-box .product-name span {
    display: inline;
    word-break: break-all
  }

  .searchlist-normal .normal-list .list-body .product-info-box .gray-icon {
    height: 29px;
    margin: 0px;
    overflow: hidden;
    line-height: 29px
  }

  .searchlist-normal .normal-list .list-body .product-info-box .product-price-m {
    -webkit-box-flex: 1;
    box-flex: 1;
    font-size: 0px;
    line-height: 40px;
    overflow: hidden;
    margin-right: 10px
  }

  .searchlist-normal .normal-list .list-body .product-info-box .product-price-m em {
    font-size: .875rem;
    color: #f23030;
    margin-right: 3px;
    display: block;
    overflow: hidden;
    float: left;
    text-decoration: none;
    font-style: normal;
  }

  .searchlist-normal .normal-list .list-body .product-info-box .product-price-m .big-price {
    font-size: .875rem;
  }

  .product-buy {
    display: -webkit-box;
    height: 100%;
    font-size: 0px;
  }

  .product-buy .icon-gouwuche {
    font-size: 40px;
    line-height: 40px;
    color: #e4393c;
    width: 40px;
    height: 40px;
  }

</style>
