<script setup>
import { ref } from "vue";
import axios from "axios";

const dialogVisible = ref(false); // 控制对话框显示的状态
const loginForm = ref({
    username: '',
    password: '',
    rememberMe: false // 是否记住密码
});
const formRef = ref(null); // 引用表单实例

// 表单验证规则
const loginFormRules = {
    username: [
        { required: true, message: '请输入用户名', trigger: 'blur' },
        { pattern: /^[a-zA-Z]{1,10}$/, message: '用户名只能包含英文字母，且长度为1-10字符', trigger: 'blur' }
    ],
    password: [
        { required: true, message: '请输入密码', trigger: 'blur' },
        { pattern: /^[a-zA-Z0-9]{6,20}$/, message: '密码只能包含英文字母和数字，且长度为6-20字符', trigger: 'blur' }
    ]
};

const submitLoginForm = () => {
    formRef.value.validate((valid) => {
        if (valid) {
            console.log('登录信息正确，可以提交服务器:', loginForm.value);
            const loginInfo = {
                username: loginForm.value.username,
                password: loginForm.value.password
            };
            console.log(loginInfo);
            test(loginInfo);
            loginForm.value.username = '';
            loginForm.value.password = '';
            dialogVisible.value = false;
        } else {
            console.log('表单验证未通过');
            return false;
        }
    });
};

const handleCancel = () => {
    // 重置表单字段和清除验证结果
    formRef.value.resetFields();
    // 关闭对话框
    dialogVisible.value = false;
};

const handleClose = () => {
    // 关闭窗口时也重置表单字段和清除验证结果
    formRef.value.resetFields();
    dialogVisible.value = false;
};

const test = (loginInfo) => {
    axios.post('http://101.34.70.172:5062/api/Login', loginInfo)
        .then(res => {
            console.log(res);
            const jwt = res.data;
            console.log(jwt);
            // 设置 Cookie
            document.cookie = `jwt1=${jwt}; expires=${new Date(new Date().getTime() + 24 * 60 * 60 * 1000).toUTCString()}; path=/`;
        })
        .catch(err => {
            console.error(err);
        });
}
</script>

<template>
    <el-button class="button" color="#e2c8ca" :dark="true" plain link @click="dialogVisible = true">
        登录
    </el-button>
    <el-dialog
        v-model="dialogVisible"
        title="登录"
        width="30%"
        :before-close="handleClose"
    >
        <el-form ref="formRef" :model="loginForm" :rules="loginFormRules" label-width="80px">
            <el-form-item label="用户名" prop="username">
                <el-input v-model="loginForm.username" placeholder="请输入用户名"></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="password">
                <el-input type="password" v-model="loginForm.password" placeholder="请输入密码" show-password></el-input>
            </el-form-item>
            <el-form-item>
                <el-checkbox v-model="loginForm.rememberMe">记住密码</el-checkbox>
                <a href="#" class="forget">忘记密码</a>
            </el-form-item>
        </el-form>
        <template #footer>
            <div class="dialog-footer">
                <el-button @click="handleCancel">取消</el-button>
                <el-button type="primary" @click="submitLoginForm">登录</el-button>
            </div>
        </template>
    </el-dialog>
</template>

<style scoped>
.button {
    margin-left: 12px;
    padding: 2px;
}
.forget {
    margin-left: 20px;
}
</style>