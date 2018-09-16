<template>
  <div class="cate-inner">
    <div class="weui-grids">
      <router-link :to="{path:'/list',query:{brandId:item.id}}" class="weui-grid" v-for="(item,index) in list" :key="index">
        <div class="weui-grid__icon">
          <img :src="item.logo" alt="">
        </div>
        <p class="weui-grid__label">{{item.name}}</p>
      </router-link>
    </div>

    <toolbar :selected="0"></toolbar>
  </div>
</template>

<script>
  import Toolbar from '@/components/Toolbar.vue'

  export default {
    components: {Toolbar},
    data() {
      return {
        list: []
      }
    },
    created() {
      this.getData();
    },
    methods: {
      async getData() {
        let res = await this.$http.post('/api/GetCategory');
        this.list = res.data;

        this.list.forEach(item => {
          item.logo = 'http://www.cqsnps.vip'+item.logo
        });

        this.list.push({
          id:0,
          name:'所有品牌',
          logo:'http://www.cqsnps.vip/images/brand/cate_00.png'
        })
      },
    }
  }
</script>

<style scoped>
  .cate-inner {
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    width: 100%;
    background-color: #fff;
  }

  .weui-grids {
    position: relative;
    overflow: hidden;
  }

  .weui-grids:before {
    content: " ";
    position: absolute;
    left: 0;
    top: 0;
    right: 0;
    height: 1px;
    border-top: 1px solid #D9D9D9;
    color: #D9D9D9;
    -webkit-transform-origin: 0 0;
    transform-origin: 0 0;
    -webkit-transform: scaleY(0.5);
    transform: scaleY(0.5);
  }

  .weui-grids:after {
    content: " ";
    position: absolute;
    left: 0;
    top: 0;
    width: 1px;
    bottom: 0;
    border-left: 1px solid #D9D9D9;
    color: #D9D9D9;
    -webkit-transform-origin: 0 0;
    transform-origin: 0 0;
    -webkit-transform: scaleX(0.5);
    transform: scaleX(0.5);
  }

  .weui-grid {
    position: relative;
    float: left;
    padding: 20px 10px;
    width: 50%;
    box-sizing: border-box;
  }

  .weui-grid:before {
    content: " ";
    position: absolute;
    right: 0;
    top: 0;
    width: 1px;
    bottom: 0;
    border-right: 1px solid #D9D9D9;
    color: #D9D9D9;
    -webkit-transform-origin: 100% 0;
    transform-origin: 100% 0;
    -webkit-transform: scaleX(0.5);
    transform: scaleX(0.5);
  }

  .weui-grid:after {
    content: " ";
    position: absolute;
    left: 0;
    bottom: 0;
    right: 0;
    height: 1px;
    border-bottom: 1px solid #D9D9D9;
    color: #D9D9D9;
    -webkit-transform-origin: 0 100%;
    transform-origin: 0 100%;
    -webkit-transform: scaleY(0.5);
    transform: scaleY(0.5);
  }

  .weui-grid:active {
    background-color: #ECECEC;
  }

  .weui-grid__icon {
    width: 5.5rem;
    margin: 0 auto;
  }

  .weui-grid__icon img {
    display: block;
    width: 100%;
    height: 100%;
  }

  .weui-grid__icon + .weui-grid__label {
    margin-top: 5px;
  }

  .weui-grid__label {
    display: block;
    text-align: center;
    color: #000000;
    font-size: .875rem;
    white-space: nowrap;
    text-overflow: ellipsis;
    overflow: hidden;
  }
</style>
