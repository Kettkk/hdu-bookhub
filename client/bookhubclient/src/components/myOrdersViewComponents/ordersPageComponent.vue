<script setup>
import { onMounted, ref } from 'vue'
import { testURL } from '@/Tools/testTool';
const route = useRoute();
import { useRoute } from 'vue-router';
import axios from "axios";
const value = ref()
const orderData = ref([])


onMounted(() => {
    const url = 'http://'+testURL+':5062/api/OrderManagement/GetAllOrders?personalID='+route.query.personalID
    axios.post(url)
    .then(function (response) {
      orderData.value=response.data
      console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });
})


</script>

<template>
        <el-table :data="orderData" style="width: 100% " max-height="700px">
            <el-table-column fixed prop="purchaseTime" label="购买时间" style="width: 20%;" />
            <el-table-column prop="goodName" label="商品名称" style="width: 20%;" />
            <el-table-column prop="sellerName" label="卖家名称" style="width: 20%;" />
            <el-table-column fixed="right" label="评分" style="width: 20%;">
                <el-rate v-model="value" allow-half clearable size="large" />
            </el-table-column>
            <el-table-column fixed="right" label="" style="width: 20%;">
                <div style="display: flex;justify-content: center;">
                    <el-button type="primary">
                        确认收货
                    </el-button>
                </div>
            </el-table-column>
        </el-table>
</template>
