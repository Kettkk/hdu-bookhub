<script setup>


import YourProfileViewMainComponent
  from "@/components/otherAndYourProfileComponents/YourProfileComponents/yourProfileViewMainComponent.vue";
import NavHeader from "@/components/homeViewComoponents/navHeader.vue";
import HeaderSearchBox from "@/components/homeViewComoponents/headerSearchBox.vue";
</script>

<template>
  <div class="common-layout">
    <div>
      <div id="headerContainer">
        <nav-header></nav-header>
        <header-search-box></header-search-box>
      </div>

      <el-main id="mainContainer">
        <your-profile-view-main-component></your-profile-view-main-component>
      </el-main>

      <el-footer id="footerContainer">Footer</el-footer>
    </div>
  </div>
</template>

<style scoped>
#headerContainer{
  height: 136px;
  width: 100%;
  margin: 0;
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