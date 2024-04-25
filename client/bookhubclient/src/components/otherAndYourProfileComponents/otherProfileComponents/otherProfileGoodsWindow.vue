<script setup>

import router from "@/router/index.js";

const props = defineProps({
  good: {
    type: Object,
    required: true
  }
});

const go2BuyGoodsView = () => {
  console.log(props.good);
  router.push({
    name: "buyGoods",
    params: {
      good: props.good
    }
  });
};

</script>

<template>
  <div id="window" @click="go2BuyGoodsView">

    <el-card style="max-width: 480px">
      <div class="image-container">
        <img
            :src= "good.image"
            style="width: 100%"
            class="image"
        />
      </div>

      <hr class="separator">
      <div style="padding-top: 5px">
        <span><strong>{{props.good.name}}</strong></span>
        <br>
        <span style="font-size: 20px;color: #5d85ad;padding-top: 8px"><strong>{{props.good.price}} ¥</strong></span>
      </div>
    </el-card>

  </div>
</template>

<style scoped>
.separator {
  margin: 5px 0;
  border: none;
  background-color: #f6f8fa;
  border-top: 1px solid #d9d8d8;
}
#window{
  background-color: #f6f8fa;
  width: 200px;
  height: 220px;
  margin-left: 40px;
  margin-top: 10px;
  cursor: pointer;
}
.image-container {
  width: 100%;
  height: 200px; /* 设置容器的高度 */
  overflow: hidden; /* 隐藏溢出的部分 */
}
.image {
  width: 100%; /* 图片宽度填满容器 */
  height: 100%; /* 图片高度填满容器 */
  object-fit: cover; /* 裁剪图片以填满容器 */
}
</style>