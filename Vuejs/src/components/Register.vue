<template>
  <div class="reg-wrapper">
    <div class="title">手机号注册</div>
    <div class="m-form">
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

      <div class="btn-box">
        <button @click="register" :class="['loginBtn',isSubmit ? '': 'disabled']">注册</button>
      </div>

    </div>
  </div>
</template>

<script>
    export default {
      data(){
          return{
            username: '',
            password: '',
          }
      },
      computed: {
        isSubmit: function () {
          return !!(this.username && this.password);
        }
      },
      methods:{
        async register(){
          if (!this.isSubmit) return false;
          let data = {
            UserName: this.username,
            Password: this.password
          };
          let res = await this.$http.post('/api/Account/Register', data);
          if (res.code === 100) {
            this.$cookies.set("cx_sid", res.data.id, -1);
            this.$cookies.set("cx_username", res.data.username, -1);
            this.$cookies.set('cx_usertype', res.data.userType, -1);

            this.$router.push({path: "/category"});
          }
          else {
            this.$vux.toast.text(res.message);
          }
        }
      }
    }
</script>

<style scoped lang="less">
  .reg-wrapper {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    bottom: 0;
    background-color: #fff;
    overflow: hidden;
  }

  .reg-wrapper .title{
    padding-top: 1.53333rem;
    text-align: center;
  }

  .m-form {
    padding: 1.5333rem .875rem 0;
  }

  .m-form .inputbox {
    height: 3.28rem;
    line-height: 3.28rem;
  }

  .m-form .u-input {
    width: 100%;
    padding-left: 1rem;
  }

  .m-form .u-input input {
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

  .btn-box {
    width: 100%;
    padding: 3rem 0;
  }

  .btn-box .loginBtn {
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

  .btn-box .loginBtn.disabled {
    color: #ccc;
  }

</style>
