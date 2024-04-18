<script setup>

const props = defineProps({
  good: {
    type: Object,
    required: true
  }
});

</script>

<template>
<div id="window">
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
      <span style="font-size: 20px;color: #5d85ad;padding-top: 8px"><strong>{{}}</strong></span>
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
  background-color: #8b9aa9;
  width: 220px;
  height: 280px;
  margin-left: 20px;
  margin-top: 25px;
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