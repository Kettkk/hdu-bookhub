<!--中间导航栏-->
<script setup>
import { ref } from 'vue'
import NavHomepageComponent from "@/components/homeViewComoponents/navHomepageComponent.vue";
import PosterHomepageComponent from "@/components/homeViewComoponents/posterHomepageComponent.vue";
import RecommendedGoodBooksComponent from "@/components/homeViewComoponents/recommendedGoodBooksComponent.vue";
import NewsBooksComponent from "@/components/homeViewComoponents/newBooksComponent.vue";
import BookstallContentComponent from "@/components/homeViewComoponents/bookstallContentComponent.vue";
const activeName = ref('first')
</script>

<template>
    <div class="nav-box">
        <el-tabs v-model="activeName" class="demo-tabs">
            <el-tab-pane label="首页" name="first">
                <div class="common-layout">
                    <el-container>
                        <el-aside width="200px"><nav-homepage-component></nav-homepage-component></el-aside>
                        <el-main>
                            <poster-homepage-component></poster-homepage-component>
                            <recommended-good-books-component></recommended-good-books-component>
                            <news-books-component></news-books-component>
                        </el-main>
                    </el-container>
                </div>
            </el-tab-pane>
            <el-tab-pane label="书摊区" name="second">
                <div class="poster">
                    <img src="../../assets/poster1.png" alt="" />
                </div>
                <bookstall-content-component></bookstall-content-component>
            </el-tab-pane>
        </el-tabs>
    </div>
</template>

<style scoped>
.nav-box {
    width: 1200px;
    margin: 0 auto;
}
.demo-tabs > .el-tabs__content {
    padding: 32px;
    color: #6b778c;
    font-size: 32px;
    font-weight: 600;
}
.el-main {
    padding: 0px;
    padding-left: 10px;
}
。poster {
    width: 1200px;
    height: 270px;
    overflow: hidden;
    margin: 0 auto;
}
.poster img {
    width: 100%;
    height: 270px;
}
</style>