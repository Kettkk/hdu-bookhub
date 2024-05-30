<script setup>
import router from "@/router/index.js";
import axios from "axios";
import { reactive, ref } from 'vue';
import { useRoute } from 'vue-router';
import { testURL } from "@/Tools/testTool";
import { ElMessage } from 'element-plus'

const route = useRoute();

const information = reactive({
  sellerName: '',
  sellerAvatar: '',
  bookName: '',
  price: '',
  goodDescription: '',
  bookImg: '',
});

const purchaseBookID = ref('');
const purchasesellerID = ref('')
purchaseBookID.value = route.query.bookID
purchasesellerID.value = route.query.sellerID

console.log(purchaseBookID.value, purchasesellerID.value)

const url = 'http://' + testURL + ':5062/api/PurchasePage?purchaseBookID=' + purchaseBookID.value;


axios.post(url)
  .then(function (response) {
    information.sellerName = response.data.sellername;
    information.value = response.data.sellerscore;
    information.sellerAvatar = response.data.selleravatar;
    information.bookName = response.data.bookname;
    information.price = response.data.price;
    information.goodDescription = response.data.description;
    information.bookImg = response.data.imgURL;
    console.log(response.data);
  })
  .catch(function (error) {
    console.log(error);
  });

const go2ChatView = () => {
  console.log('go2ChatView');
  router.push('/chatRoom');
}


const go2otherProfileView = () => {
  console.log('go2otherProfileView');
  router.push({
    path: '/userProfile/otherProfile',
    query: {
      sellerID: purchasesellerID.value
    }
  });
}


const purchaseThisBook = () => {
  const tokenStr = document.cookie.split('=')[1]
  axios.post('http://' + testURL + ':5062/api/Purchase', {
    tokenStr: tokenStr,
    sellerID: purchasesellerID.value,
    goodID: purchaseBookID.value
  })
    .then(function (response) {
      if (purchasesellerID.value == response.data) {
        ElMessage({
          message: '无法购买自己发布的商品',
          type: 'error',
          plain: true,
        })
      } else {
        router.replace('/userProfile/MyOrders?personalID=' + response.data)
      }
    })
    .catch(function (error) {
      console.log(error);
    });


}
</script>

<template>
  <div>
    <div id="titleContainer">书籍购买 &emsp;>> &emsp;{{ information.bookName }}</div>

    <div style="display: flex">
      <el-aside>
        <div id="goodImgContainer">
          <img :src="information.bookImg" alt="书籍图片" width="300px" height="300px">
        </div>

        <div id="goodPriceContainer">价格&emsp;
          <div style="color: #e33546;font-size: 22px;">{{ information.price }} &ensp;¥</div>
        </div>
      </el-aside>

      <el-main>
        <div id="sellerInfoContainer">
          <div @click="go2otherProfileView" id="avatarContainer">
            <el-avatar :src="information.sellerAvatar" :size="'large'" />
          </div>
          <div @click="go2otherProfileView" id="sellerNameAndStarsContainer">
            <div style="display: flex;margin-top: 8px;">
              <div style="font-size: 12px;margin-top: 8px">用户名:&ensp;</div>
              {{ information.sellerName }}
            </div>

            <div style="margin-top: 8px">
              <el-rate v-model="information.value" :size="'small'" disabled text-color="#ff9900" />
            </div>
          </div>

          <div id="sendMessageBtn">
            <el-button round :size="'large'" @click="go2ChatView" id="sendMessageBtn">联系卖家</el-button>
          </div>
        </div>



        <div id="goodDescriptionContainer">

          <div id="scrollable-container">
            <el-card style="max-width: 800px; min-height: 300px">
              <template #header>商品描述</template>
              {{ information.goodDescription }}
            </el-card>
          </div>
        </div>

        <div style="margin: 50px 0px 0px 1070px;">
          <el-button type="primary" size="large" @click="purchaseThisBook">购买</el-button>
        </div>
      </el-main>

    </div>
  </div>
</template>

<style scoped>
#titleContainer {
  height: 40px;
  background-color: #ededee;
  line-height: 40px;
  padding-left: 10px;
  font-size: 15px;
  font-family: 'Apple Braille';
  color: #3d3939;
}

#goodImgContainer {
  width: 300px;
  height: 300px;
  background-color: #f6f8fa;
  margin-top: 35px;
  margin-left: 50px;
  border-radius: 4px
}

#goodPriceContainer {
  width: 300px;
  height: 40px;
  background-color: #e9e9ea;
  margin-left: 50px;
  font-size: 16px;
  font-family: "Microsoft YaHei";
  color: #939292;
  display: flex;
  padding-left: 35px;
  padding-top: 20px;
}

#sellerInfoContainer {
  height: 80px;
  width: 100%;
  background-color: #e9e9ea;
  margin-top: 25px;
  display: flex;
}

#avatarContainer {
  height: 70px;
  width: 70px;
  background-color: #e9e9ea;
  padding-top: 10px;
  padding-left: 10px;
  cursor: pointer;
}

#sellerNameAndStarsContainer {
  height: 70px;
  width: 200px;
  background-color: #e9e9ea;
  padding-top: 10px;
  padding-left: 20px;
  font-size: 22px;
  font-family: 'Apple Braille';
  color: #3d3939;
  cursor: pointer;
}

#sendMessageBtn {
  margin-top: 10px;
  margin-left: 370px;
}

#goodDescriptionContainer {
  height: 300px;
  width: 800px;
  background-color: #e9e9ea;
  margin-top: 25px;
  margin-left: 50px;
  border-radius: 4px;
}

#scrollable-container {
  height: 300px;
  overflow-y: auto;
}
</style>