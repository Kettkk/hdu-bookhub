<template>
  <div>
    <NavHeader></NavHeader>
    <div id="assistant">
      <serviceWindow></serviceWindow>
    </div>
  </div>
</template>

<script setup>
import NavHeader from "@/components/homeViewComoponents/navHeaderComponent.vue";
import serviceWindow from "@/components/assistantViewComponents/serviceWindow.vue";
</script>

<style scoped>
#assistant {
  height: 895px;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: blanchedalmond;
  background-image: url('src/assets/demo1.jpg'); /* 使用相对路径引用图片 */
  background-size: cover; /* 使背景图覆盖整个容器 */
  background-position: center; /* 使背景图居中 */
}
</style>
