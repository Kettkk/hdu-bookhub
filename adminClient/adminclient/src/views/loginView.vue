<script lang="ts" setup>
import { ref } from 'vue';
import axios from "axios";
import router from "@/router";
import MountainOfLoginPicture from "@/Components/loginViewComponents/mountainOfLoginPicture.vue";

const loginForm = ref({
    username: '',
    password: ''
});

const loginFormRules = {
    username: [
        {
            required: true,
            message: '请输入用户名',
            trigger: 'blur'
        }
    ],
    password: [
        {
            required: true,
            message: '请输入密码',
            trigger: 'blur'
        }
    ]
};

const formRef = ref(null);

const go2SignUpForm = () => {
    router.push({name: 'signUp'});
}

const submitForm = () => {
    if (formRef.value) {
        formRef.value.validate((valid) => {
            if (valid) {
                console.log('表单验证通过！尝试登录...');
                // 示例：使用Axios API请求进行用户登录
                axios.post('http://localhost:5000/api/Login', {
                    username: loginForm.value.username,
                    password: loginForm.value.password
                }).then(response => {
                    console.log('登录成功：', response.data);
                    // 处理登录成功的逻辑（例如，路由导航，存储token）
                    router.push({name: 'console'});
                }).catch(error => {
                    console.error('登录失败：', error);
                    alert('登录失败！请检查用户名或密码是否正确');
                });
            } else {
                console.error('表单验证失败！');
                alert('登录失败！请检查输入是否正确');
            }
        });
    }
};
</script>

<template>
    <el-container>
        <el-aside width="500px" class="loginWindow">
            <div style="margin-top: 200px">
                <strong class="title">欢迎来到HDU Bookhub</strong>
                <div class="subTitle">后台管理系统</div>
            </div>

            <div class="login-form">
                <el-form ref="formRef" :model="loginForm" :rules="loginFormRules" label-width="100px" class="demo-ruleForm">
                    <el-form-item label="用户名" prop="username">
                        <el-input v-model="loginForm.username" autocomplete="off"></el-input>
                    </el-form-item>
                    <el-form-item label="密码" prop="password">
                        <el-input type="password" v-model="loginForm.password" autocomplete="off" show-password></el-input>
                    </el-form-item>
                    <el-form-item>
                        <el-button type="primary" class="loginBtn" @click="submitForm">登录</el-button>
                    </el-form-item>
                </el-form>

                <el-form>
                    <el-button type="text" class="signUpBtn" @click="go2SignUpForm">还没有账号？马上注册</el-button>
                </el-form>

                <span class="bottomWords">
                    Copyright © 2024 HDU Bookhub
                </span>
                <span class="bottomWords">
                    &ensp;&ensp;&ensp;&ensp;&ensp;&emsp;Powered by Vue.js
                </span>
            </div>
        </el-aside>

        <el-main class="pic">
            <mountain-of-login-picture></mountain-of-login-picture>
        </el-main>
    </el-container>
</template>

<style scoped>
.pic{
    padding: 0;
}
.loginWindow {
    height: 1221px;
    background-color: #f5f5f5;
    align-items: center;
}
.loginBtn {
    margin-left: 80%;
}
.signUpBtn {
    margin-left: 35%;
}
.title {
    margin-left: 6%;
    font-size: 23px;
    color: #333;
}
.subTitle {
    margin-top: 5px;
    margin-left: 6%;
    font-size: 14px;
    color: #999;
}
.bottomWords {
    margin-left: 29%;
    margin-top: 10%;
    font-size: 12px;
    color: #999;
}
.login-form {
    width: 100%;
    max-width: 430px;
    margin-right: 25px;
    margin-top: 20px;
}
</style>
