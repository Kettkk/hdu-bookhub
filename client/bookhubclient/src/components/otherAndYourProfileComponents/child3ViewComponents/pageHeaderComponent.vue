<script setup>
import router from "@/router/index.js";
import { defineProps } from "vue";
import { ArrowLeft } from "@element-plus/icons-vue";

const goBack = () => {
  router.go(-1);
}
const props = defineProps({
  pageTitle: {
    type: String,
    default: "未定义",
  }

});

</script>

<template>
  <div>
    <el-page-header style="padding-top: 5px" :icon="ArrowLeft" :title="'返回'" @click="goBack">
      <template #content>
        <span class="text-large font-600 mr-3"> {{props.pageTitle}} </span>
      </template>
    </el-page-header>
    <div class="separator"></div>
  </div>
</template>

<style scoped>
.separator {
  height: 1px;
  background-color: #ccc;
  margin-top: 10px;
  margin-bottom: 5px;
}
.text-large {
  font-size: 20px; /* 调整文字大小 */
}
.font-600 {
  font-weight: 650; /* 设置粗体字 */
}
</style>
