<script setup>

import NavHeaderComponent from "@/components/homeViewComoponents/navHeaderComponent.vue";
import HeaderSearchBoxComponent from "@/components/homeViewComoponents/headerSearchBoxComponent.vue";
import OtherInfoComponent
  from "@/components/otherAndYourProfileComponents/otherProfileComponents/otherInfoComponent.vue";
import OtherPublishedGoodsComponent
  from "@/components/otherAndYourProfileComponents/otherProfileComponents/otherPublishedGoodsComponent.vue";
import HomeViewFooterComponent from "@/components/homeViewComoponents/homeViewFooterComponent.vue";
</script>

<template>
  <div class="common-layout" style="background-color: #f6f8fa">

    <div id="headerContainer">
      <nav-header-component></nav-header-component>
      <header-search-box-component></header-search-box-component>
    </div>

    <el-main id="MainContainer">
      <other-info-component></other-info-component>

      <hr class="separator">

      <other-published-goods-component></other-published-goods-component>
    </el-main>

    <el-footer id="footerContainer">
      <home-view-footer-component></home-view-footer-component>
    </el-footer>

  </div>
</template>

<style scoped>
.separator {
  margin: 5px 0;
  border: none;
  background-color: #f6f8fa;
  border-top: 1px solid #d9d8d8;
}
#headerContainer{
  height: 136px;
  width: 100%;
  margin: 0;
  background-color: #f6f8fa;
}
#MainContainer{
  height: 1040px;
  background-color: #f6f8fa;
}
#footerContainer{
  height: 80px;
  background-color: #f6f8fa;
}
</style>