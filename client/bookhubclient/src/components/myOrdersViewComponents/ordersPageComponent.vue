<script setup>
import { onMounted, ref } from 'vue'
import { testURL } from '@/Tools/testTool';
import { useRoute } from 'vue-router';
import axios from "axios";
import { ElMessage } from 'element-plus'
const route = useRoute();

//#region 显示已购买但未收货的订单信息
const orderData = ref([])
onMounted(() => {
    const url = 'http://' + testURL + ':5062/api/OrderManagement/GetAllOrders?personalID=' + route.query.personalID
    axios.post(url)
        .then(function (response) {
            orderData.value = response.data
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
})
//#endregion

//#region 点击收货按钮，获取收货的单号
const acceptOrderID = ref()
const confirmAccept = (orderID) => {
    acceptOrderID.value = orderID
    dialogRateVisible.value = true
}
//#endregion

//#region 实现评分弹窗的功能，确认后提交给卖家的打分
const dialogRateVisible = ref(false)
const star = ref(0)
const cancelRate = () => {
    star.value = 0
    dialogRateVisible.value = false
}

const confirmRate = () => {
    axios.post('http://' + testURL + ':5062/api/OrderManagement/AcceptAndRate', {
        orderID: acceptOrderID.value,
        star: star.value
    })
        .then(function (response) {
            ElMessage({
                message: '收货成功',
                type: 'success',
            })

            console.log(response)
        })
        .catch(function (error) {
            console.log(error);
        });


    star.value = 0
    dialogRateVisible.value = false
    setTimeout(() => {
      location.reload();
    }, 1000); 
}

//#endregion

</script>

<template>
    <el-table :data="orderData" style="width: 100% " max-height="700px">
        <template #empty>暂无订单数据</template>
        <el-table-column fixed prop="purchaseTime" label="购买时间" style="width: 12.5%;" />
        <el-table-column prop="orderID" label="订单号" style="width: 12.5%;" />
        <el-table-column prop="goodName" label="商品名称" style="width: 12.5%;" />
        <el-table-column prop="bookImg" label="商品图片" style="width: 12.5%;">
            <template v-slot="scope">
                <el-image style="width: 100px; height: 100px" :src="scope.row.bookImg" :fit="fill" />
            </template>
        </el-table-column>
        <el-table-column prop="price" label="商品价格" style="width: 12.5%;" />
        <el-table-column prop="sellerName" label="卖家名称" style="width: 12.5%;" />
        <el-table-column fixed="right" style="width: 12.5%;">
            <template v-slot="scope">
                <div style="display: flex;justify-content: center;">
                    <el-button type="primary" @click="confirmAccept(scope.row.orderID)">
                        确认收货
                    </el-button>
                </div>
            </template>

        </el-table-column>
    </el-table>

    <!--评分弹窗-->
    <el-dialog v-model="dialogRateVisible" title="评分" width="300">
        <div style="display: flex;justify-content: center;">
            <el-rate v-model="star" allow-half size="large" />
        </div>

        <template #footer>
            <div class="dialog-footer">
                <el-button @click="cancelRate">取消</el-button>
                <el-button type="primary" @click="confirmRate">
                    确定
                </el-button>
            </div>
        </template>
    </el-dialog>
</template>

<style scoped>
.demo-image__error .image-slot {
    font-size: 30px;
}

.demo-image__error .image-slot .el-icon {
    font-size: 30px;
}

.demo-image__error .el-image {
    width: 100%;
    height: 200px;
}
</style>