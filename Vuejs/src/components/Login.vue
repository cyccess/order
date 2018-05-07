<template>
  <div class="login-wrap">
    <div class="m-logo">
      发货系统
    </div>

    <div class="m-login">
      <div class="inputbox vux-1px-b">
        <div class="u-input">
          <input type="text" placeholder="请输入手机号">
        </div>
      </div>

      <div class="inputbox vux-1px-b">
        <div class="u-input">
          <input type="password" placeholder="密码">
        </div>
      </div>

      <div class="loginbox">
        <button class="loginBtn">登录</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {

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
    text-align: center;
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
    margin: 0.39rem 0;
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
    background-color: #b4282d;
    border: 0;
    border-radius: 3px;
    color: #fff;
  }

  .loginbox .loginBtn.disabled {
    color: #fff;
  }

</style>
