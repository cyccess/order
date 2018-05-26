<template>
    <div>
      <div class="m-profile">
        <div class="m-profile-info">
          <i class="icon icon-touxiang"></i>

          <div class="info">
            <div class="s-name">你好，{{name}}</div>
            <div class="s-phone">手机帐号：{{phone}}</div>
          </div>
        </div>
      </div>

      <div class="m-menu">
        <router-link to="/myOrder" class="m-menu-item vux-1px-b">
          <div class="m-icon">
            <i class="icon icon-order"></i>
          </div>
          <div class="m-text">我的订单</div>
        </router-link>

        <router-link to="/info" class="m-menu-item vux-1px-b">
          <div class="m-icon">
            <i class="icon icon-geren"></i>
          </div>
          <div class="m-text">基本信息</div>
        </router-link>

        <router-link to="" class="m-menu-item">
          <div class="m-icon">
            <i class="icon icon-dizhi"></i>
          </div>
          <div class="m-text">收货地址</div>
        </router-link>
      </div>

      <div class="m-menu m-logout">
        <a @click="logout" href="javascript:;" class="m-menu-item">
          <div class="m-icon">
            <i class="icon icon-tuichu"></i>
          </div>
          <div class="m-text">退出登录</div>
        </a>
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
      data(){
        return {
          name:'',
          phone:''
        }

      },
      created(){
        this.phone= this.$cookies.get("cx_username");
        this.name= this.$cookies.get("cx_info");
      },
      methods:{
        logout(){
          this.$cookies.remove("cx_sid");
          this.$cookies.remove("cx_username");
          this.$cookies.remove('cx_usertype');
          this.$cookies.remove('cx_info');

          this.$router.push({path:"/"});
        }
      }
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
    padding-left: .875rem;
  }

  .m-menu-item{
    padding: .6rem 0;
    position: relative;
    display: flex;
    align-items: center;
  }

  .m-icon{
    color:#666;
  }

  .m-text{
    margin-left: .3rem;
    color: #333;
  }
  .m-logout{
    margin-top: .5rem;
  }
</style>
