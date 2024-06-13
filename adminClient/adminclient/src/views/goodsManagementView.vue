<script lang="ts" setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';
import { ElMessage } from 'element-plus';

const tableData = ref([]);
const dialogVisible = ref(false);
const previewImageSrc = ref('');

onMounted(async () => {
    try {
        const response = await axios.get('http://localhost:5062/api/AdminGoodManagement');
        tableData.value = response.data;
    } catch (error) {
        console.error('拉取数据时出错', error);
        ElMessage.error('拉取数据时出错');
    }
});

const handlePreview = (bookPicture) => {
    previewImageSrc.value = bookPicture;
    dialogVisible.value = true;
};
</script>

<template>
    <el-table
        :data="tableData"
        style="width: 100%"
    >
        <el-table-column prop="goodID" label="商品编号" width="180" />
        <el-table-column prop="sellerName" label="卖家" width="180" />
        <el-table-column prop="bookName" label="书名及描述" width="430" />
        <el-table-column label="书" width="180">
            <template #default="{ row }">
                <el-image
                    :src="row.bookPicture"
                    fit="cover"
                    style="width: 50px; height: 50px; cursor: pointer;"
                    @click="handlePreview(row.bookPicture)"
                />
            </template>
        </el-table-column>
        <el-table-column prop="bookPrice" label="价格" width="129" />
        <el-table-column prop="goodCreateTime" label="发布时间" width="180" />
        <el-table-column prop="goodLatestUpdateTime" label="更新时间" width="180" />
    </el-table>

    <el-dialog
        v-model="dialogVisible"
        :close-on-click-modal="true"
        :show-close="false"
        width="50%"
    >
        <img :src="previewImageSrc" style="width: 100%" alt=""/>
    </el-dialog>
</template>

<style>

</style>