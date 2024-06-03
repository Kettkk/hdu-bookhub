<script setup>
import { onMounted, ref } from 'vue'
import { testURL } from '@/Tools/testTool';
import { useRoute } from 'vue-router';
import axios from "axios";

const route = useRoute();

const publishedData = ref([])

onMounted(() => {
    const url = 'http://' + testURL + ':5062/api/PersonalBook/GetAllPublishedGoods?personalID=' + route.query.personalID
    axios.post(url)
        .then(function (response) {
            publishedData.value = response.data
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
})


</script>

<template>
  <el-table :data="publishedData" style="width: 100% " max-height="700px">
        <template #empty>暂未发布任何商品</template>
        <el-table-column prop="publishedTime" label="发布时间" style="width: 25%;" />
        <el-table-column prop="bookName" label="商品名称" style="width: 25%;" />
        <el-table-column prop="bookImg" label="商品图片" style="width: 25%;">
            <template v-slot="scope">
                <el-image style="width: 100px; height: 100px" :src="scope.row.bookImg" :fit="fill" />
            </template>
        </el-table-column>
        <el-table-column prop="price" label="商品价格" style="width: 25%;" />
    </el-table>
</template>

<style scoped>

</style>