<template>
  <div class="login-wrap">
    <div class="m-logo">
      <div class="m-logoIcon"><i class="icon icon-fahuo"></i></div>
      <div class="m-logoTxt">订单系统</div>
    </div>

    <div class="m-login">
      <div class="inputbox vux-1px-b">
        <div class="u-input">
          <input v-model="username" type="text" placeholder="请输入手机号">
        </div>
      </div>

      <div class="inputbox vux-1px-b">
        <div class="u-input">
          <input v-model="password" type="password" placeholder="密码">
        </div>
      </div>

      <div class="loginbox">
        <button @click="login" :class="['loginBtn',isSubmit ? '': 'disabled']">登录</button>
      </div>
    </div>
  </div>
</template>

<script>
  import {setStore} from '../utils'
  export default {
    data() {
      return {
        username:'',
        password:''
      }
    },
    computed:{
      isSubmit:function () {
        return !!(this.username && this.password);
      }
    },
    methods:{
      async login(){
        if(!this.isSubmit) return false;
        let data = {
          UserName:this.username,
          Password:this.password
        };
        let res = await this.$http.post('/api/Account/Login', data);
        if(res.code === 100){
          this.$cookies.set("ox_sid",res.data.id, -1);
          this.$cookies.set("ox_username",res.data.name, -1);
          this.$router.push({path:"/list"});
        }
        else{
          this.$vux.toast.text(res.message);
        }
      }
    }
  }
</script>

<style scoped>

  .login-wrap {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    bottom: 0;
    background-color: #fff;
    overflow: hidden;
  }

  .m-logo {
    min-height: 8rem;
    padding-top: 1rem;
    padding-bottom: 1rem;
    text-align: center;
  }
  .m-logoIcon{
    margin: 1rem 0;
  }
  .m-logoIcon .icon{
    font-size: 4rem;
    line-height: 4rem;
  }

  .m-logoTxt{
    font-size: 1.2rem;
  }

  .m-login {
    padding: 0 .875rem;
  }

  .m-login .inputbox {
    height: 3.28rem;
    line-height: 3.28rem;
  }

  .m-login .u-input {
    width: 100%;
    padding-left: 1rem;
  }

  .m-login .u-input input {
    width: 19.27rem;
    height: 1.6rem;
    font-size: 0.875rem;
    line-height: 1.6rem;
    margin: 0.833rem 0;
    padding-left: 0;
    -webkit-tap-highlight-color: transparent;
    letter-spacing: normal;
    color: #333;
    border: 0;
    outline: 0;
  }

  .loginbox {
    width: 100%;
    padding: 3rem 0;
  }

  .loginbox .loginBtn {
    display: block;
    width: 100%;
    height: 3rem;
    line-height: 3rem;
    font-size: .875rem;
    background-color: #b4282d;
    border: 0;
    border-radius: 3px;
    color: #fff;
  }

  .loginbox .loginBtn.disabled {
    color: #ccc;
  }

</style>
