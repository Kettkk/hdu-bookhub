<!--顶部通栏开始-->
<script setup>
import router from "@/router/index.js";

const go2YourProfile = () => {
  router.push({name: 'userProfile'});
}

</script>
<template>
    <div id="navHeader" class="nav-header-box">
        <div class="header-wrap">
            <div class="slogan-box">
                <span class="text">网罗天下图书</span>
                <span>传承中华文明</span>
            </div>
            <div class="user-info-box clearfix">

              <el-button color="#e2c8ca" :dark="true" plain link>登录</el-button>
              <el-button color="#e2c8ca" :dark="true" plain link>注册</el-button>
              <el-button color="#e2c8ca" :dark="true" plain link>我的消息</el-button>
              <el-button @click="go2YourProfile" color="#e2c8ca" :dark="true" plain link >个人中心</el-button>
              <el-button color="#e2c8ca" :dark="true" plain link>AI客服</el-button>
              <el-button color="#e2c8ca" :dark="true" plain link>退出登录</el-button>

            </div>
        </div>
    </div>
</template>
<style>
  .nav-header-box {
        height: 36px;
        background-color: #8c222c;
    }
    .header-wrap {
        position: relative;
        width: 1000px;
        height: 100%;
        margin: 0 auto;
    }
    .slogan-box {
        position: absolute;
        top: 0;
        left: 0;
        padding-left: 6px;
        height: 36px;
        line-height: 36px;
        font-size: 14px;
        color: #e2c8ca;
    }
    .text {
        margin-right: 4px;
    }
    .user-info-box {
        position: absolute;
        top: 0;
        right: 0;
        height: 36px;
        font-size: 0;
    }
    .user-info-box {
        position: absolute;
        top: 0;
        right: 0;
        height: 36px;
        font-size: 0;
        line-height: 36px;
    }
  .headerBtn{

  }
</style>