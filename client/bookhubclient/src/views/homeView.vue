<script setup>

import NavHeader from "@/components/homeViewComoponents/navHeaderComponent.vue";
import HeaderSearchBox from "@/components/homeViewComoponents/headerSearchBoxComponent.vue";
import Footer from "@/components/homeViewComoponents/homeViewFooterComponent.vue";
import Navigation from "@/components/homeViewComoponents/navigationComponent.vue";
</script>

<template>
    <div class="content-box">
        <nav-header></nav-header>
        <header-search-box></header-search-box>
        <navigation></navigation>
        <Footer></Footer>
    </div>
</template>

<style scoped>
.content-box {
    background-color: #f6f8fa;
}
</style>