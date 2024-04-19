<script setup>

import NavHeaderComponent from "@/components/homeViewComoponents/navHeaderComponent.vue";
import HeaderSearchBoxComponent from "@/components/homeViewComoponents/headerSearchBoxComponent.vue";
import OtherInfoComponent
  from "@/components/otherAndYourProfileComponents/otherProfileComponents/otherInfoComponent.vue";
</script>

<template>
  <div class="common-layout">

    <div id="headerContainer">
      <nav-header-component></nav-header-component>
      <header-search-box-component></header-search-box-component>
    </div>

    <el-main id="MainContainer">
      <other-info-component></other-info-component>
    </el-main>

    <el-footer id="footerContainer">Footer</el-footer>

  </div>
</template>

<style scoped>
#headerContainer{
  height: 136px;
  width: 100%;
  margin: 0;
  background-color: #f6f8fa;
}
#MainContainer{
  height: 600px;
  background-color: #d0d3d7;
}
#footerContainer{
  height: 80px;
  background-color: #f6f8fa;
}
</style>