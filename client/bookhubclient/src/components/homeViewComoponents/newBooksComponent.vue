<!--最新发布-->
<script setup>
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";
import { ref, computed} from 'vue';

const goodsList = [
    {
        id: 1,
        name: "Apple",
        price: 10,
        description: "Fresh apple from the garden",
        image: "https://th.bing.com/th/id/OIP.NSqoq-JMoS7QzSJeSJTA0QHaIO?w=164&h=182&c=7&r=0&o=5&dpr=2&pid=1.7",
    },
    {
        id: 2,
        name: "Banana",
        price: 5,
        description: "Fresh banana from the garden",
        image: "https://th.bing.com/th/id/OIP.DzzBtp9wRuY1VocmOurZ7gHaJE?w=134&h=180&c=7&r=0&o=5&dpr=2&pid=1.7",
    },
    {
        id: 3,
        name: "Orange",
        price: 7,
        description: "Fresh orange from the garden",
        image: "https://cdn.pixabay.com/photo/2016/11/22/23/44/orange-1851465_960_720.jpg",
    },
    {
        id: 4,
        name: "Pineapple",
        price: 15,
        description: "Fresh pineapple from the garden",
        image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/pineapple-1238248_960_720.jpg",
    },
    {
        id: 5,
        name: "Strawberry",
        price: 20,
        description: "Fresh strawberry from the garden",
        image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/strawberries-1238249_960_720.jpg",
    },
    {
        id: 6,
        name: "Watermelon",
        price: 25,
        description: "Fresh watermelon from the garden",
        image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/watermelon-1238250_960_720.jpg",
    },
];

const goodsPerPage = 8;
const currentPage = ref(1);
const paginateGoods = computed(() => {
    const start = (currentPage.value - 1) * goodsPerPage;
    const end = start + goodsPerPage;
    return goodsList.slice(start, end);
});
</script>

<template>
    <div class="recGoodBooks">
        <p class="title">
            <span>最新上架</span>
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
    margin-top: 50px;
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
    margin-bottom: 40px;
}

</style>