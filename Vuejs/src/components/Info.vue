<template>
    <div class="m-info">
      <div class="m-info-form">
        <div class="section">
          <div class="row vux-1px-b">
            <popup-picker :data="list" v-model="areaId" :columns="1" show-name value-text-align="left" placeholder="所属区域"></popup-picker>
          </div>

          <div class="row vux-1px-b">
            <input type="text" placeholder="店铺名称" v-model="name">
          </div>
          <div class="row vux-1px-b">
            <input type="text" placeholder="姓名" v-model="linkman">
          </div>
          <div class="row">
            <input type="text" placeholder="详细地址，如街道、楼盘号等" v-model="address">
          </div>
        </div>
      </div>

      <div class="m-info-btn">
        <div class="btn">
          <a class="info-btn info-btn-1" href="javascript:;" @click="$router.go(-1)">取消</a>
        </div>
        <div class="btn">
          <a @click="save" class="info-btn" href="javascript:;">保存</a>
        </div>
      </div>
    </div>
</template>

<script>
  import { PopupPicker } from 'vux'
    export default {
      components: {
        PopupPicker
      },
      data(){
        return{
          list:[],
          areaId:[],
          regionId:0,
          name:"",
          linkman:"",
          address:''
        }
      },
      created(){
        this.getInfo();
      },
      methods:{
        async getInfo(){
          let res = await this.$http.post('/api/user/info');
          if(res.code===100){
            this.regionId = res.data.regionId;
            this.name = res.data.name;
            this.linkman = res.data.linkman;
            this.address = res.data.address;
            this.areaId = [this.regionId.toString()];

            this.list = res.data.regions.map(item=>{
              return {name:item.name,value:item.id.toString()};
            })
          }
        },
        async save(){
          if(this.areaId.length>0){
            this.regionId = Number(this.areaId[0]) ;
          }

          if(!this.validate()){
            return false;
          }

          let data = {
            regionId : this.regionId,
            name :this.name,
            linkman: this.linkman,
            address :this.address
          };
          let res = await this.$http.post('/api/user/save',data);

          if(res.code === 100){
            let vm = this;
            this.$vux.toast.show({
              text:res.message,
              type:'text',
              onHide(){
                vm.$router.go(-1);
              }
            });
          }
        },
        validate(){
          if(this.regionId === 0){
            this.$vux.toast.text('请选择所属区域');
            return false;
          }
          if(!this.name){
            this.$vux.toast.text('请输入店铺名称');
            return false;
          }
          if(!this.linkman){
            this.$vux.toast.text('请输联系人名称');
            return false;
          }
          if(!this.address){
            this.$vux.toast.text('请输入详细地址');
            return false;
          }
          return true;
        }
      }

    }
</script>

<style scoped lang="less">
  .m-info {

    .section{
      background-color: #fff;
      padding-left: .875rem;
      .row{
        position: relative;
        color: #333;
        font-size: .87333rem;
      }
    }
  }

  .m-info .row input{
    border: none;
    display: block;
    position: relative;
    white-space: nowrap;
    text-overflow: ellipsis;
    width: 100%;
    height: 3.555rem;
    line-height: 3.555rem;
    overflow: hidden;
    padding-right: .88rem;
    font-size: 100%;
    outline: none;
  }
  .vux-cell-box{
    height: 3rem;
    line-height: 3rem;
  }

  .weui-cell{
    padding: 0;
  }

  .m-info-btn{
    position: absolute;
    left: 0;
    bottom: 0;
    width: 100%;
    display: flex;
    .btn{
      flex: 1;
      .info-btn{
        width: 100%;
        height: 3.555rem;
        line-height: 3.555rem;
        display: block;
        background: #b4282d;
        text-align: center;
        color:#fff;
      }
      .info-btn-1{
        background: #fff;
        color:#333;
      }
    }
  }

</style>
