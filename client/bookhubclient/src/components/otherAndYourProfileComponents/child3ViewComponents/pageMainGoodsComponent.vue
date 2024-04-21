<script setup>
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";
import { ref, computed } from 'vue';
import router from "@/router/index.js";

const goodsPerPage = 12; // 每页显示的商品数量
const currentPage = ref(1); // 当前页码

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
  {
    id: 7,
    name: "Grape",
    price: 30,
    description: "Fresh grape from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/grapes-1238251_960_720.jpg",
  },
  {
    id: 8,
    name: "Mango",
    price: 35,
    description: "Fresh mango from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/mango-1238252_960_720.jpg",
  },
  {
    id: 9,
    name: "Peach",
    price: 40,
    description: "Fresh peach from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/peach-1238253_960_720.jpg",
  },
  {
    id: 10,
    name: "Pear",
    price: 45,
    description: "Fresh pear from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/pear-1238254_960_720.jpg",
  },
  {
    id: 11,
    name: "Plum",
    price: 50,
    description: "Fresh plum from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/plum-1238255_960_720.jpg",
  },
  {
    id: 12,
    name: "Cherry",
    price: 55,
    description: "Fresh cherry from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/cherry-1238256_960_720.jpg",
  },
  {
    id: 13,
    name: "Kiwi",
    price: 60,
    description: "Fresh kiwi from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/kiwi-1238257_960_720.jpg",
  },
  {
    id: 14,
    name: "Lemon",
    price: 65,
    description: "Fresh lemon from",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/lemon-1238258_960_720.jpg",
  },
];

const paginatedGoods = computed(() => {
  const start = (currentPage.value - 1) * goodsPerPage;
  const end = start + goodsPerPage;
  return goodsList.slice(start, end);
});

function handleCurrentChange(val) {
  currentPage.value = val;
}



</script>

<template>
  <div>
    <div id="goodsWindowsContainer">
      <GoodsWindow v-for="good in paginatedGoods" :key="good.id" :good="good" ></GoodsWindow>
    </div>
    <div id="scrollable-container">
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
#goodsWindowsContainer {
  background-color: #f6f8fa;
  width: 100%;
  height: 650px;
  display: flex;
  flex-wrap: wrap;
}

#scrollable-container {
  width: 100%;
  height: 50px;
  margin-top: 50px;
  margin-left: 50px;
}

.pagination {
  margin-top: 10px;
}
</style>