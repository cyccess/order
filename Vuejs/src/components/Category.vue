<template>
  <div class="cate-inner">

    <div class="cate-list">
      <div class="cate-item vux-1px-tb vux-1px-r" >
asdfs
      </div>

      <div class="cate-item">

      </div>
    </div>

    <toolbar :selected="1"></toolbar>
  </div>
</template>

<script>
  import Toolbar from '@/components/Toolbar.vue'
  export default {
    components: {
      Toolbar
    },
    name: "category",

  }
</script>

<style scoped>
.cate-inner{
  position: absolute;
  top:0;
  left: 0;
  bottom: 0;
  width: 100%;
  background-color: #fff;
}

.cate-list{
  position: relative;
  overflow: hidden;
}
.cate-item{
  position: relative;
  float: left;
  padding: 20px 10px;
  width: 50%;
  box-sizing: border-box;
}
  img{
    width: 8rem;
  }
</style>
