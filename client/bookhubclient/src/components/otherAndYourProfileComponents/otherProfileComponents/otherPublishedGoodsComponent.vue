<script setup>
import { ref, computed } from 'vue';
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";
import { useRoute } from 'vue-router';
import axios from 'axios';
const route = useRoute();
const userID = ref()

userID.value = route.query.sellerID
const goodsPerPage = 12; // 每页显示的商品数量
const currentPage = ref(1); // 当前页码

const goodsList = ref([])
import { testURL } from '@/Tools/testTool';
const url = 'http://'+testURL+':5062/api/SellerPage/SellerBook?sellerID=' + userID.value

axios.post(url)
  .then(function (response) {
    goodsList.value=response.data
    console.log(response.data);
  })
  .catch(function (error) {
    console.log(error);
  });



const paginatedGoods = computed(() => {
  const start = (currentPage.value - 1) * goodsPerPage;
  const end = start + goodsPerPage;
  return goodsList.value.slice(start, end);
});

function handleCurrentChange(val) {
  currentPage.value = val;
}
</script>

<template>
  <div>
    <div id="windowsTitle">
      他上架的商品
    </div>

    <div id="goodsWindowsContainer">
      <goods-window v-for="good in  paginatedGoods" :key="good.id" :good="good"></goods-window>
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
  height: 700px;
  display: flex;
  flex-wrap: wrap;
}

#scrollable-container {
  width: 100%;
  height: 50px;
  margin-top: 0;
  margin-left: 50px;
}
#windowsTitle{
  font-size: 20px;
  font-family: 'Apple Braille';
  color: #3d3939;
  margin-left: 40px;
  margin-top: 20px;
  margin-bottom: 10px;
}
.pagination {
  margin-top: 1px;
}

</style>