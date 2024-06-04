<script lang="ts" setup>
import {ref} from 'vue'

const text1 = ref("Good Morning!")
const text2 = ref("Ketk, J and X")
</script>

<template>
  <div class="image-container">
    <el-image src="src/assets/mountainPicture.jpg"></el-image>
    <div class="text-overlay">
      <div class="regards">{{text1}}</div>
      <div class="imgAutor">{{text2}}</div>
    </div>
  </div>
</template>

<style scoped>
.image-container {
  position: relative;
  width: 1200px;
  height: 1200px;
  overflow: hidden;
}
.text-overlay {
  position: absolute;
  top: 600px; /* 根据需要调整位置 */
  left: 150px; /* 根据需要调整位置 */
  z-index: 1; /* 确保文字显示在图片上方 */
}
.imgAutor {
  margin-left: 20px;
  margin-top: 10px;
  color: #eaeaea; /* 设置文字颜色 */
  font-size: 20px; /* 设置文字大小 */
  font-family: "Microsoft YaHei"; /* 设置文字字体 */
}
.regards {
  color: #ffffff; /* 设置文字颜色 */
  font-size: 55px; /* 设置文字大小 */
  font-family: "Microsoft YaHei"; /* 设置文字字体 */
}
</style>