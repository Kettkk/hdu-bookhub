<script>
import {defineComponent} from 'vue'

export default defineComponent({
  name: "MountainOfLoginPicture",
  data() {
    return {
      src: require("@/assets/mountainPicture.jpg"),
      positionX: -300,
      positionY: 0,
      text1 : "Good Morning!",
      text2 : "Bali, Indonesia",
    }
  }
})
</script>

<template>
  <div id="image-container">
    <el-image :src="src"></el-image>
    <div id="text-overlay">
      <div id="regards">{{text1}}</div>
      <div id="imgAutor">{{text2}}</div>
    </div>
  </div>
</template>

<style scoped>
#image-container {
  position: relative;
  width: 1200px;
  height: 1000px;
  overflow: hidden;
}
#text-overlay {
  position: absolute;
  top: 600px; /* 根据需要调整位置 */
  left: 150px; /* 根据需要调整位置 */
  z-index: 1; /* 确保文字显示在图片上方 */
}
#imgAutor {
  margin-left: 20px;
  margin-top: 10px;
  color: #eaeaea; /* 设置文字颜色 */
  font-size: 20px; /* 设置文字大小 */
  font-family: "Microsoft YaHei"; /* 设置文字字体 */
}
#regards {
  color: #ffffff; /* 设置文字颜色 */
  font-size: 55px; /* 设置文字大小 */
  font-family: "Microsoft YaHei"; /* 设置文字字体 */
}
</style>