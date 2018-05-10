<template>
  <div id="app">
    <keep-alive include="list">
      <router-view />
    </keep-alive>
  </div>
</template>

<script>
  export default {
    name: 'App'
  }
</script>
<style lang="less">
  @import '~vux/src/styles/reset.less';
  @import '~vux/src/styles/1px.less';
</style>

