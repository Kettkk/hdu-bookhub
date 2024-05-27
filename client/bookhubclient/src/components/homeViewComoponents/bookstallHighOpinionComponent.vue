<!--最新发布-->
<script setup>
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";
import { ref, computed} from 'vue';
import axios from "axios";

const goodsList = ref([])

axios.get('http://101.34.70.172:5062/api/BookStall/AllRecommendedBook').then(response => {
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

function handleCurrentChange(val) {
    currentPage.value = val;
}
</script>

<template>
    <div class="recGoodBooks">
        <div class="books">
            <goods-window v-for="good in paginateGoods" :key="good.id" :good="good"></goods-window>
        </div>
        <div class="pageChange">
            <el-pagination
                class="pagination"
                background
                layout="prev, pager, next"
                :total="goodsList.length"
                :page-size="goodsPerPage"
                @current-change="handleCurrentChange"
            ></el-pagination>
        </div>
    </div>
</template>

<style scoped>
.books {
    width: 990px;
    height: 700px;
    display: flex;
    flex-wrap: wrap;
    margin: 0 auto;
    margin-bottom: 40px;
}
.pageChange {
    display: flex;
    justify-content: center;
}

</style>