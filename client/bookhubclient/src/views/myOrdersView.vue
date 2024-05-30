<script setup>
import PageHeaderComponent
    from "@/components/otherAndYourProfileComponents/child3ViewComponents/pageHeaderComponent.vue";
import ordersPageComponent from "@/components/myOrdersViewComponents/ordersPageComponent.vue"
import HomeViewFooterComponent from "@/components/homeViewComoponents/homeViewFooterComponent.vue";
</script>

<template>
    <div >
        <el-container>
            <el-header id="headerContainer">
                <PageHeaderComponent :pageTitle="'订单管理'"></PageHeaderComponent>
            </el-header>

            <el-main id="mainContainer">
                <ordersPageComponent></ordersPageComponent>
            </el-main>

            <el-footer id="footerContainer">
                <home-view-footer-component></home-view-footer-component>
            </el-footer>
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
  height: 780px;
  
}
#footerContainer{
  background-color: #f6f8fa;
  width: 100%;
  height: 80px;
}
</style>