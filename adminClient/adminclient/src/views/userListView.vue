<script lang = "ts" setup>
import {onMounted, ref} from 'vue';
import axios from "axios";

const errorHandler = () => true

const confirmEvent = async (id: number) => {
    console.log('confirm!', id);
    try{
        await axios.delete('http://localhost:5000/api/UserList/' + id);
        await fetchData();
    } catch (error) {
        console.error('删除数据时出错', error);
    }
}

const tableData = ref([]);
const fetchData = async () => {
    try {
        const response = await axios.get('http://localhost:5000/api/UserList');
        tableData.value = response.data;
    } catch (error) {
        console.error('拉取数据时出错', error);
    }
};

onMounted(fetchData);
</script>

<template>
    <el-table :data="tableData" style="width: 100%">
        <el-table-column fixed prop="username" label="Username" width="120" />
        <el-table-column prop="userID" label="UserID" width="120" />
        <el-table-column prop="password" label="Password" width="200" />
        <el-table-column prop="email" label="Email" width="300" />
        <el-table-column prop="money" label="Money" width="120" />
        <el-table-column prop="star" label="Star" width="120" />
        <el-table-column prop="avatarImg" label="Avatar" width="100">
            <template #default="{ row }">
                <el-avatar :size="50" :src="row.avatarImg" @error="errorHandler" shape="circle">
                    <img
                        src="https://cube.elemecdn.com/e/fd/0fc7d20532fdaf769a25683617711png.png"
                        alt="Avatar"/>
                </el-avatar>
            </template>
        </el-table-column>
        <el-table-column prop="createTime" label="CreateTime" width="180" />
        <el-table-column prop="lastUpdateTime" label="LastUpdateTime" width="180" />
        <el-table-column fixed="right" label="Operations" width="120">

            <template #default="{ row }">
                <el-popconfirm title="Are you sure to delete this?" @confirm="() => confirmEvent(row.userID)">
                    <template #reference>
                        <el-button link type="primary" size="small">
                            Delete
                        </el-button>
                    </template>
                </el-popconfirm>
                <el-button link type="primary" size="small">Edit</el-button>
            </template>
        </el-table-column>
    </el-table>
    <el-backtop :right="100" :bottom="100" />
</template>

<style scoped>

</style>