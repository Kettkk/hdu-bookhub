<script setup>

import PageHeaderComponent
  from "@/components/otherAndYourProfileComponents/child3ViewComponents/PageHeaderComponent.vue";
</script>

<template>
<div>
  <el-container>
    <el-header id="headerContainer">
      <PageHeaderComponent></PageHeaderComponent>
    </el-header>

    <el-main id="mainContainer">

    </el-main>

    <el-footer>Footer</el-footer>
  </el-container>
</div>
</template>

<style scoped>
#headerContainer{
  background-color: #f6f8fa;
  width: 100%;
  height: 50px;
}
#mainContainer{
  background-color: #f6f8fa;
  width: 100%;
  height: 800px;
}
</style>