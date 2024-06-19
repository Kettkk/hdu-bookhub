<script lang = "ts" setup>
import {onMounted, ref} from 'vue';
import axios from "axios";
import { ElDialog, ElMessage } from "element-plus";
import { URL } from '@/ToolUrl';

const errorHandler = () => true;
const confirmEvent = async (id: number) => {
    console.log('confirm!', id);
    try{
        await axios.delete('http://' + URL + ':5062/api/AdminUserList/' + id);
        await fetchData();
    } catch (error) {
        console.error('删除数据时出错', error);
    }
};
const tableData = ref([]);
const fetchData = async () => {
    try {
        const response = await axios.get('http://' + URL + ':5062/api/AdminUserList');
        tableData.value = response.data;
    } catch (error) {
        console.error('拉取数据时出错', error);
    }
};
onMounted(fetchData);

//#region 修改个人信息功能JS
const cmpData = {
    editedName1: '',
    editedPassword1: '',
    editedEmail1: '',
    editedMoney1: 0,
    editedStar1: 0,
    currentUserID1: 0,
};
const editedName = ref('');
const editedPassword = ref('');
const editedEmail = ref('');
let editedMoney = ref(0);
const editedStar = ref(0);
const dialogFormVisible = ref(false);
let currentUserID = ref(0);

//打开编辑个人信息窗口
const openEditDialog = (row: any) => {
    currentUserID.value = row.userID;
    editedName.value = row.username;
    editedPassword.value = row.password;
    editedEmail.value = row.email;
    editedMoney.value = row.money;
    editedStar.value = row.star;

    cmpData.editedName1 = row.username;
    cmpData.editedPassword1 = row.password;
    cmpData.editedEmail1 = row.email;
    cmpData.editedMoney1 = row.money;
    cmpData.editedStar1 = row.star;
    dialogFormVisible.value = true;
};

//关闭编辑个人信息窗口，清空信息
const closeEditInfoDialog = () => {
    editedName.value='';
    editedPassword.value='';
    editedEmail.value='';
    editedMoney.value=0;
    editedStar.value=0;
    dialogFormVisible.value=false;
};
//提交修改内容的方法
const submitUserInfo = async () => {
    if(editedName.value === cmpData.editedName1 && editedPassword.value === cmpData.editedPassword1 && editedEmail.value === cmpData.editedEmail1
    && editedMoney.value === cmpData.editedMoney1 && editedStar.value === cmpData.editedStar1)
    {
        ElMessage({
            message:'请至少修改一项内容',
            type:'error',
            plain:true
        })
    }else{
        try {
            await axios.put('http://' + URL + ':5062/api/AdminUserList', {
                UserID: currentUserID.value,
                Username: editedName.value,
                Password: editedPassword.value,
                Email: editedEmail.value,
                Money: editedMoney.value,
                Star: editedStar.value,
                AvatarImg: "",
            });
            closeEditInfoDialog();
            await fetchData();
            ElMessage({
                message: '修改成功',
                type: 'success',
                plain: true,
            });
            console.log('修改成功');
        } catch (error) {
            console.error('修改数据时出错', error);
            ElMessage({
                message: '修改失败',
                type: 'error',
                plain: true,
            });
        }
    }
};
//#endregion
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
                <el-button link type="primary" size="small" @click="openEditDialog(row)">Edit</el-button>
            </template>
        </el-table-column>
    </el-table>
    <el-backtop :right="100" :bottom="100" />

    <!-- #region 修改个人信息组件 -->
    <el-dialog v-model="dialogFormVisible" width="360px" :before-close="closeEditInfoDialog">
        <template #title>
            <div style="text-align: left;">修改个人信息</div>
        </template>
        <div style="display: flex;margin-bottom: 15px;margin-top: 10px;">
            <span style="margin-right: 5px;">用户名</span>
            <el-input v-model="editedName" style="width: 240px" />
        </div>
        <div style="display: flex;margin-bottom:15px ;">
            <span style="margin-right: 18px;">密码</span>
            <el-input v-model="editedPassword" style="width: 240px" />
        </div>
        <div style="display: flex;margin-bottom:15px ;">
            <span style="margin-right: 18px;">邮箱</span>
            <el-input v-model="editedEmail" style="width: 240px" />
        </div>
        <div style="display: flex;margin-bottom:15px ;">
            <span style="margin-right: 18px;">余额</span>
            <el-input v-model="editedMoney" style="width: 240px" />
        </div>
        <div style="display: flex;margin-bottom:15px ;">
            <span style="margin-right: 18px;">星级</span>
            <el-input v-model="editedStar" style="width: 240px" />
        </div>

        <div style="margin-top: 15px;">
            <el-button type="primary" @click="submitUserInfo">修改完成</el-button>
        </div>

    </el-dialog>
    <!-- #endregion -->

</template>

<style scoped>

</style>