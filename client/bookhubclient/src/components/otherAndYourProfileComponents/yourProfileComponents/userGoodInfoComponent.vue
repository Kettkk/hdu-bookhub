<script setup>
import { Goods, Sell, SoldOut } from "@element-plus/icons-vue";
import { ref, onMounted } from 'vue';
import router from "@/router/index.js";
import axios from "axios";
const goodsPublishedCount = ref();
const goodsSoldCount = ref();
const goodsPurchasedCount = ref();
const personalID=ref()

onMounted(() => {
  const tokenStr = document.cookie.split('=')[1]

  axios.post('http://101.34.70.172:5062/api/PersonalPage', {
    tokenValue: tokenStr
  })
    .then(function (response) {
      personalID.value=response.data.userId
      goodsPublishedCount.value = response.data.publishedNum
      goodsSoldCount.value = response.data.soldNum
      goodsPurchasedCount.value = response.data.purchasedNum
      console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });
})


const go2PublishedGoodsView = () => {
  router.push({
     name: 'publishedGoodsView',
     query:{
      personalID:personalID.value,
      whichView:1
     }
  });
}
const go2SoldGoodsView = () => {
  router.push({ 
    name: 'soldGoodsView', 
    query:{
      personalID:personalID.value,
      whichView:2
    }
  });
}
const go2BroughtGoodsView = () => {
  router.push({ 
    name: 'broughtGoodsView',
    query:{
      personalID:personalID.value,
      whichView:3
    }
  }); 
}
</script>

<template>
  <div>
    <el-container id="infoWindowContainer">
      <div class="goodInfoWindow" @click="go2PublishedGoodsView">
        <div style="font-size: 30px;
      font-family: 'Apple Braille';
      color: #525252;
      margin-top: 5px;
      margin-left: 10px">
          我发布的商品
        </div>

        <div>
          <el-icon :size="145" style="margin-left: 80px;margin-top: 10px">
            <Goods style="color: #3f3f3f;" />
          </el-icon>
        </div>

        <div style="margin-top: 10px;
      margin-left: 55px;
      font-family: 'Apple Braille';
      font-size: 20px;
      color: #3d3939">
          已发布的商品数量 {{ goodsPublishedCount }}
        </div>
      </div>

      <div class="goodInfoWindow" @click="go2SoldGoodsView">
        <div style="font-size: 30px;
      font-family: 'Apple Braille';
      color: #525252;
      margin-top: 5px;
      margin-left: 10px">
          我卖出的商品
        </div>

        <div>
          <el-icon :size="145" style="margin-left: 80px;margin-top: 10px">
            <sell style="color: #3f3f3f;" />
          </el-icon>
        </div>

        <div style="margin-top: 10px;
      margin-left: 55px;
      font-family: 'Apple Braille';
      font-size: 20px;
      color: #3d3939">
          已卖出的商品数量 {{ goodsSoldCount }}
        </div>
      </div>

      <div class="goodInfoWindow" @click="go2BroughtGoodsView">
        <div style="font-size: 30px;
      font-family: 'Apple Braille';
      color: #525252;
      margin-top: 5px;
      margin-left: 10px">
          我买到的商品
        </div>

        <div>
          <el-icon :size="145" style="margin-left: 80px;margin-top: 10px">
            <SoldOut style="color: #3f3f3f;" />
          </el-icon>
        </div>

        <div style="margin-top: 10px;
      margin-left: 55px;
      font-family: 'Apple Braille';
      font-size: 20px;
      color: #3d3939">
          已买到的商品数量 {{ goodsPurchasedCount }}
        </div>
      </div>


    </el-container>
  </div>
</template>

<style scoped>
#infoWindowContainer {
  height: 350px;
  width: 1400px;
  margin-top: 25px;
  margin-left: 35px;
  background-color: #f6f8fa;
}

.goodInfoWindow {
  height: 280px;
  width: 350px;
  border-radius: 4px;
  margin-top: 25px;
  margin-left: 50px;
  background-color: #f6f8fa;
  border: 1px solid #d4d4d4;
  box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1);
  transition: background-color 0.3s ease;
  cursor: pointer;
}

.goodInfoWindow:hover {
  background-color: #f3f3f3;
}
</style>