<script setup>
import { onMounted, ref } from 'vue'
import { testURL } from '@/Tools/testTool';
import { useRoute } from 'vue-router';
import axios from "axios";

const route = useRoute();

const purchasedData = ref([])

onMounted(() => {
    const url = 'http://' + testURL + ':5062/api/PersonalBook/GetAllPurchasedGood?personalID=' + route.query.personalID
    axios.post(url)
        .then(function (response) {
            purchasedData.value = response.data
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
})
</script>

<template>
  <el-table :data="purchasedData" style="width: 100% " max-height="700px">
        <template #empty>暂未购买任何商品</template>
        <el-table-column prop="purchasedTime" label="购买时间" style="width: 12.5%;" />
        <el-table-column prop="acceptTime" label="收货时间" style="width: 12.5%;" />
        <el-table-column prop="orderID" label="订单号" style="width: 12.5%;" />
        <el-table-column prop="bookName" label="商品名称" style="width: 12.5%;" />
        <el-table-column prop="bookImg" label="商品图片" style="width: 12.5%;">
            <template v-slot="scope">
                <el-image style="width: 100px; height: 100px" :src="scope.row.bookImg" :fit="fill" />
            </template>
        </el-table-column>
        <el-table-column prop="price" label="商品价格" style="width: 12.5%;" />
        <el-table-column prop="sellerName" label="卖家名称" style="width: 12.5%;" />
    </el-table>
</template>

<style scoped>

</style>