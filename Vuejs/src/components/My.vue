<template>
    <div>
      <div class="m-profile">
        <div class="m-profile-info">
          <i class="icon icon-touxiang"></i>

          <div class="info">
            <div class="s-name">京东直营店</div>
            <div class="s-phone">手机帐号：18580760058</div>
          </div>
        </div>
      </div>

      <div class="m-menu">
        <router-link to="" class="m-menu-item">
          <div class="m-icon">
            <i class="icon icon-order"></i>
          </div>
          <div class="m-text">我的订单</div>
        </router-link>
      </div>

      <toolbar :selected="3"></toolbar>

    </div>
</template>

<script>
  import Toolbar from '@/components/Toolbar.vue'
    export default {
      components: {
        Toolbar
      },
    }
</script>

<style scoped>
.m-profile{
  height: 6.25rem;
  padding-left: .875rem;
  overflow: hidden;
  background-color: #fff;
  margin: .5rem 0;
}
.m-profile-info{
  display: flex;
  align-items: center;
  justify-content: flex-start;
  padding: .875rem 0;
}
.m-profile-info .info{
  flex: 1;
  margin-left: .6rem;
  line-height: 1;
  overflow: hidden;
}
.s-name{
  font-size: .875rem;
  line-height: 1.6rem;
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
  margin-bottom: .5rem;
}
.s-phone{
  font-size: .65rem;
  color:#999;
}
.m-profile-info .icon{
    color:#dcdfe6;
    font-size: 4.5rem;
    height: 4.5rem;
    line-height: 4.5rem;
  }

  .m-menu{
    position: relative;
    background-color: #fff;
    overflow: hidden;
    font-size: .875rem;
  }

  .m-menu-item{
    padding: .6rem .875rem;
    position: relative;
    display: flex;
    align-items: center;
  }

  .m-icon{
    color:#ff9900;
  }

  .m-text{
    margin-left: .3rem;
    color: #333;
  }
</style>
