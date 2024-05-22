<script setup>
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";
import { onMounted, ref,computed } from 'vue';
import axios from "axios";
const goodsPerPage = 12; // 每页显示的商品数量
const currentPage = ref(1); // 当前页码
const route = useRoute();
import { useRoute } from 'vue-router';

const goodsList = ref([]);

onMounted(()=>{
  axios.post('http://localhost:5062/api/PersonalBook', {
      userID:route.query.personalID,
      whichView:route.query.whichView
    })
    .then(function (response) {
      goodsList.value= response.data
      console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });

})

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