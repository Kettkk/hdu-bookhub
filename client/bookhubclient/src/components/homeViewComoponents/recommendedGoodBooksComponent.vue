<!--好书推荐-->
<script setup>
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";
import { ref, computed} from 'vue';
import axios from "axios";
import { testURL } from "@/Tools/testTool";
const goodsList = ref([])

//获取推荐的书
axios.get('http://'+testURL+':5062/api/HomePage/RecommendedBook').then(response => {
    console.log(response.data)
    goodsList.value = response.data; 
}).catch(error => {
    console.log(error)
});


const goodsPerPage = 8;
const currentPage = ref(1);
const paginateGoods = computed(() => {
    const start = (currentPage.value - 1) * goodsPerPage;
    const end = start + goodsPerPage;
    return goodsList.value.slice(start, end);
});
</script>

<template>
<div class="recGoodBooks">
    <p class="title">
        <span>好书推荐</span>
        <i> / </i>
        <el-button color="#0057a0" :dark="true" plain link>更多</el-button>
    </p>
    <div class="books">
        <goods-window v-for="good in paginateGoods" :key="good.id" :good="good"></goods-window>
    </div>
</div>
</template>

<style scoped>
.title {
    width: 100%;
    height: 10px;
    margin-bottom: 5px;
    border-bottom: 1px solid #ccc;
    margin-top: 20px;
    padding-bottom: 34px;
}
.title span {
    font-size: 18px;
    color: #333;
    font-weight: 700;
}
.title i {
    font-size: 14px;
    font-style: normal;
    color: #999;
    font-weight: 400;
}
.books {
    height: 700px;
    display: flex;
    flex-wrap: wrap;
}

</style>