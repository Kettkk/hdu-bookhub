<script setup>
import YourProfileViewMainComponent
  from "@/components/otherAndYourProfileComponents/yourProfileComponents/yourProfileViewMainComponent.vue";
import NavHeader from "@/components/homeViewComoponents/navHeaderComponent.vue";
import HeaderSearchBox from "@/components/homeViewComoponents/headerSearchBoxComponent.vue";
import HomeViewFooterComponent from "@/components/homeViewComoponents/homeViewFooterComponent.vue";
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

      <el-footer id="footerContainer"><home-view-footer-component></home-view-footer-component></el-footer>
    </div>
  </div>
</template>

<style scoped>
#headerContainer{
  height: 136px;
  width: 100%;
  margin: 0;
  background-color: #f6f8fa;
}
#mainContainer{
  height: 600px;
  background-color: #f6f8fa;
}
#footerContainer{
  height: 80px;
  background-color: #f6f8fa;
}
</style>