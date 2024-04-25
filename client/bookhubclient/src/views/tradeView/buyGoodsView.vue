<script setup>

import NavHeaderComponent from "@/components/homeViewComoponents/navHeaderComponent.vue";
import HeaderSearchBoxComponent from "@/components/homeViewComoponents/headerSearchBoxComponent.vue";
import BuyGoodsViewMainComponent from "@/components/tradeViewComponents/buyGoodsViewMainComponent.vue";
import HomeViewFooterComponent from "@/components/homeViewComoponents/homeViewFooterComponent.vue";
</script>

<template>
  <div style="background-color: #f6f8fa">
    <div id="headerContainer">
      <nav-header-component></nav-header-component>
      <header-search-box-component></header-search-box-component>
    </div>

    <div id="mainContainer">
      <buy-goods-view-main-component></buy-goods-view-main-component>
    </div>

    <div id="footerContainer">
      <home-view-footer-component></home-view-footer-component>
    </div>

  </div>
</template>

<style scoped>
#mainContainer{
  height: 660px;
  background-color: #f6f8fa;
}
#footerContainer{
  height: 80px;
  background-color: #f6f8fa;
}
</style>