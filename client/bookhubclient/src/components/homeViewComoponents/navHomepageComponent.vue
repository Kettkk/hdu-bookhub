<!--中间导航栏首页内容-->
<script lang="ts" setup>
import { ref } from 'vue'
import { testURL } from '@/Tools/testTool';
import axios from "axios";
import router from '@/router';

const goldUserList = ref([])

//获取金牌用户列表
axios.get('http://'+testURL+':5062/api/HomePage/GoldUser').then(response => {
    console.log(response.data)
    goldUserList.value = response.data;
}).catch(error => {
    console.log(error)
});


const go2otherProfileView = (goldUser) => {
  console.log('go2otherProfileView');
  router.push({
      path:'/userProfile/otherProfile',
      query:{
        sellerID:goldUser.userId
      }
  });
}
</script>

<template>
    <div class="left-column">
        <div class="list-bulletinBoard">
            <div class="bulletinBoard-titleBox">
                <div class="bulletinBoard-text">
                    <strong>公告栏</strong>
                </div>
            </div>
            <!--公告栏内容开始-->
            <div class="bulletinBoard-content">该网站仍处于测试阶段...<br><br>若发现网站有任何问题，请通过意见反馈栏内的邮箱和电话来联系我们。<br><br>十分感谢！</div>
            <!--公告栏内容结束-->
        </div>
        <div class="list-bestUsers">
            <div class="bestUsers-titleBox">
                <div class="bestUsers-text">
                    <strong>金牌用户</strong>
                </div>
            </div>
            <!--金牌用户内容开始-->
            <div class="bestUsers-content" v-if="goldUserList && goldUserList.length > 0" >
                <div class="block" v-for="goldUser in goldUserList" :key="goldUser.userId" @click="go2otherProfileView(goldUser)" >
                    <div class="block-picture">
                        <el-avatar :src="goldUser.avatarImg" />
                    </div>

                    <div class="block-text">{{ goldUser.userName }}</div>

                    <div class="block-score">
                        <el-rate v-model="goldUser.star" disabled text-color="#ff9900" />
                    </div>
                </div>
            </div>
            <!--金牌用户内容结束-->
        </div>
        <div class="list-feedback">
            <div class="feedback-titleBox">
                <div class="feedback-text">
                    <strong>意见反馈</strong>
                </div>
            </div>
            <!--意见反馈内容开始-->
            <div class="feedback-content">客服邮箱：<br>HDUBookHub@outlook.com<br>客服电话：<br>18868272792</div>
            <!--意见反馈内容结束-->
        </div>
    </div>
</template>

<style scoped>
.list-bulletinBoard {
    width: 200px;
}

.bulletinBoard-titleBox {
    height: 36px;
    line-height: 36px;
    background-color: #8c222c;
}

.bulletinBoard-text {
    color: white;
    width: 50px;
    margin: 0 auto;
}

.bulletinBoard-content {
    height: 400px;
    border: 2px solid #ddd;
    display: flex;
    justify-content: center;
}

.list-bestUsers {
    width: 200px;
}

.bestUsers-titleBox {
    height: 36px;
    line-height: 36px;
    background-color: #8c222c;
}

.bestUsers-text {
    color: white;
    width: 64px;
    margin: 0 auto;
}

.bestUsers-content {
    height: 285px;
    border: 2px solid #ddd;
}

.list-feedback {
    width: 200px;
}

.feedback-titleBox {
    height: 36px;
    line-height: 36px;
    background-color: #8c222c;
}

.feedback-text {
    color: white;
    width: 64px;
    margin: 0 auto;
}

.feedback-content {
    height: 400px;
    border: 2px solid #ddd;
    font-size: 13px;
}

.block {
    margin-top: 5px;
    height: 50px;
    cursor: pointer;
}

.block-picture {
    margin: 6px 8px 6px 8px;
    height: 40px;
    width: 40px;
    line-height: 40px;
    float: left;
}

.block-text {
    margin-top: 3px;
    height: 20px;
    line-height: 22px;
    float: left;
}

</style>