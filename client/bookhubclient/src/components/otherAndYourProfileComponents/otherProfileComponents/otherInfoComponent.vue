<script setup>
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import axios from 'axios';
const route = useRoute();
const userID = ref()
import { testURL } from '@/Tools/testTool';
import router from "@/router/index.js";
userID.value = route.query.sellerID

const username = ref('');
const value = ref();
const squareUrl = ref('');

const url = 'http://'+testURL+':5062/api/SellerPage/SellerInfo?sellerID=' + userID.value
axios.post(url)
  .then(function (response) {
    username.value=response.data.userName
    value.value=response.data.star
    squareUrl.value=response.data.avatarImg
    console.log(response.data);
  })
  .catch(function (error) {
    console.log(error);
  });

const createChatObject = () => {
  axios.post('http://'+testURL+':5062/api/chat/ChatCreate', {
    "cookieStr": document.cookie.split('=')[1],
    "userBID": userID.value
  })
    .then(function (response) {
      console.log(response.data);
      router.push({ path: '/chatRoom'})
    })
    .catch(function (error) {
      console.log(error);
      router.push({ path: '/chatRoom'})
    });
}


</script>

<template>
  <div class="common-layout">
    <el-container>

      <el-aside id="asideContainer">
        <div>
          <el-avatar style="margin-top: 8px;cursor: pointer;" shape="square" :size="135" :fit="fill" :src="squareUrl" />
        </div>
      </el-aside>

      <el-main id="mainContainer">
        <div style="display: flex">
          <el-container id="nameContainer">{{ username }}</el-container>
        </div>

        <div style="display: flex">
          <el-container id="starsContainer">
            <el-rate v-model="value" disabled  text-color="#ff9900" size="large"/>
          </el-container>

          <el-button round :size="'large'" id="sendMessageBtn" @click="createChatObject">发消息</el-button>
        </div>


      </el-main>
    </el-container>
  </div>
</template>

<style scoped>
#asideContainer {
  width: 180px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
}

#mainContainer {
  width: 1276px;
  height: 150px;
  background-color: #f6f8fa;
}

#nameContainer {
  height: 40px;
  width: 150px;
  font-size: 22px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
}

#starsContainer {
  height: 80px;
  width: 80px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
  padding-top: 35px;
}

#sendMessageBtn {
  margin-top: 30px;
}
</style>