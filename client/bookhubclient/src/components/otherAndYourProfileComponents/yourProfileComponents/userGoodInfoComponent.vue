<script setup>
import {Goods, Sell, SoldOut} from "@element-plus/icons-vue";
import { ref } from 'vue';
import router from "@/router/index.js";

const goodsPublishedCount = ref(12);
const goodsSoldCount = ref(12);
const goodsSoldoutCount = ref(12);

const go2SoldGoodsView = () => {
  router.push({name: 'soldGoodsView'});
}
const go2PublishedGoodsView = () => {
  router.push({name: 'publishedGoodsView'});
}
const go2BroughtGoodsView = () => {
  router.push({name: 'broughtGoodsView'});
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
         <Goods style="color: #3f3f3f;"/>
        </el-icon>
      </div>

      <div style="margin-top: 10px;
      margin-left: 55px;
      font-family: 'Apple Braille';
      font-size: 20px;
      color: #3d3939">
        已发布的商品数量 {{goodsPublishedCount}}
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
          <sell style="color: #3f3f3f;"/>
        </el-icon>
      </div>

      <div style="margin-top: 10px;
      margin-left: 55px;
      font-family: 'Apple Braille';
      font-size: 20px;
      color: #3d3939">
        已卖出的商品数量 {{goodsSoldCount}}
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
          <SoldOut style="color: #3f3f3f;"/>
        </el-icon>
      </div>

      <div style="margin-top: 10px;
      margin-left: 55px;
      font-family: 'Apple Braille';
      font-size: 20px;
      color: #3d3939">
        已买到的商品数量 {{goodsSoldoutCount}}
      </div>
    </div>


  </el-container>
</div>
</template>

<style scoped>
#infoWindowContainer{
  height: 350px;
  width: 1400px;
  margin-top: 25px;
  margin-left: 35px;
  background-color: #f6f8fa;
}
.goodInfoWindow{
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
.goodInfoWindow:hover{
  background-color: #f3f3f3;
}
</style>