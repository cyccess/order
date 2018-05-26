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
  </div>
</template>

<script>
  export default {

    data() {
      return {
        list: [],
        brandId: 0,
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
        this.brandId = this.$route.query.brandId || 0;
        this.page += 1;
        let res = await this.$http.post('/api/Sell/List', {page: this.page, brandId: this.brandId});

        if (res.code === 100) {
          if (res.data.length < 10) {
            this.noData = '没有更多了';
          }

          this.list = [...this.list, ...res.data];
          done()
        }
        else {
          if (this.list.length === 0) {
            this.noData = "暂无数据";
          }
          done(true);
        }
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
      onDetailClick(id) {
        this.$router.push({path: "/detail", query: {id: id}});
      }
    }
  }
</script>

<style scoped>
  .sell-goods-list {
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    width: 100%;
    background-color: #fff;
  }

  .searchlist-normal {
    list-style: none;
  }

  .normal-list {
    font-size: .87333rem;
    background-color: #fff;
  }

  .searchlist-normal .normal-list .list-body {
    display: flex;
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
    flex: 1;
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
    border: 0 solid transparent;
    border-radius: 0;
    -webkit-border-radius: 0;
    transform: scale(0.5);
    -webkit-transform: scale(0.5);
    transform-origin: top left;
    -webkit-transform-origin: top left;
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
    margin: 0;
    overflow: hidden;
    line-height: 29px
  }

  .searchlist-normal .normal-list .list-body .product-info-box .product-price-m {
    flex: 1;
    font-size: 0;
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
    display: flex;
    height: 100%;
    font-size: 0;
  }

  .product-buy .icon-gouwuche {
    font-size: 40px;
    line-height: 40px;
    color: #e4393c;
    width: 40px;
    height: 40px;
  }

</style>
