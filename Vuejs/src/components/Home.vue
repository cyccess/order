<template>
  <div>
    <swiper auto loop :aspect-ratio="300/800" :list="imgList"></swiper>
    <toolbar :selected="0"></toolbar>
  </div>
</template>

<script>
  import Toolbar from '@/components/Toolbar.vue'
  import {Swiper} from 'vux'

  export default {
    components: {
      Swiper, Toolbar
    },
    data() {
      return {
        imgList: [{
          url: 'javascript:',
          img: '/static/img/swiper_01.3b5d76b.jpg',
          title: '送你一朵fua',
          fallbackImg: 'https://ww1.sinaimg.cn/large/663d3650gy1fq66vvsr72j20p00gogo2.jpg'
        }, {
          url: 'javascript:',
          img: 'https://ww1.sinaimg.cn/large/663d3650gy1fq66vw1k2wj20p00goq7n.jpg',
          title: '送你一辆车'
        }, {
          url: 'javascript:',
          title: '送你一次旅行',
          fallbackImg: 'https://ww1.sinaimg.cn/large/663d3650gy1fq66vw50iwj20ff0aaaci.jpg'
        }]
      }
    },
  }
</script>

<style scoped>

</style>
