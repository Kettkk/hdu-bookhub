<script setup>

import YourProfileViewMainComponent from "@/components/otherAndYourProfileComponents/yourProfileComponents/yourProfileViewMainComponent.vue";
</script>

<template>
  <div class="common-layout">
    <el-container>
      <el-header id="headerContainer">
        <el-container></el-container>
        <el-container></el-container>
      </el-header>

      <el-main id="mainContainer">
        <YourProfileViewMainComponent></YourProfileViewMainComponent>
      </el-main>

      <el-footer id="footerContainer">Footer</el-footer>
    </el-container>
  </div>
</template>

<style scoped>
#headerContainer{
  height: 136px;
  background-color: gray;
}
#mainContainer{
  height: 600px;
  background-color: #f6f8fa;
}
#footerContainer{
  height: 80px;
  background-color: gray;
}
</style>