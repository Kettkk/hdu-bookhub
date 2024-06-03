<script lang = "ts" setup>
import {onMounted, ref} from 'vue';
import axios from "axios";

const handleClick = () => {
    console.log('click')
}

const tableData = ref([]);
onMounted(async () => {
    try {
        const response = await axios.get('http://localhost:5000/api/UserList');
        tableData.value = response.data;
    } catch (error) {
        console.error('拉取数据时出错', error);
    }
})
</script>

<template>
    <el-table :data="tableData" style="width: 100%">
        <el-table-column fixed prop="Username" label="Username" width="120" />
        <el-table-column prop="UserID" label="UserID" width="120" />
        <el-table-column prop="Password" label="Password" width="200" />
        <el-table-column prop="Email" label="Email" width="300" />
        <el-table-column prop="Money" label="Money" width="120" />
        <el-table-column prop="Star" label="Star" width="120" />
        <el-table-column prop="AvatarImg" label="AvatarImg" width="300"/>
        <el-table-column prop="CreateTime" label="CreateTime" width="120" />
        <el-table-column prop="LastUpdateTime" label="LastUpdateTime" width="120" />
        <el-table-column fixed="right" label="Operations" width="120">

            <template #default>
                <el-button link type="primary" size="small" @click="handleClick">
                    Detail
                </el-button>
                <el-button link type="primary" size="small">Edit</el-button>
            </template>
        </el-table-column>
    </el-table>
</template>

<style scoped>

</style>