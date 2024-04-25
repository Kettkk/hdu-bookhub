<script setup>
import { ref } from "vue";
import axios from "axios";

const dialogVisible = ref(false); // 控制对话框显示的状态
const registerForm = ref({
    username: '',
    email: '',
    password: '',
    confirmPassword: '',
    agreeTerms: false // 用户协议勾选状态
});
const formRef = ref(null); // 引用表单实例

// 表单验证规则
const registerFormRules = {
    username: [
        { required: true, message: '请输入用户名', trigger: 'blur' },
        { pattern: /^[^\u4e00-\u9fa5]{1,10}$/, message: '用户名不能包含中文，长度为1-10字符', trigger: 'blur' }
    ],
    email: [
        { required: true, message: '请输入邮箱地址', trigger: 'blur' },
        { pattern: /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$/, message: '邮箱地址格式不正确', trigger: 'blur' },
        { min: 5, max: 30, message: '邮箱长度必须在5到30字符之间', trigger: 'blur' }
    ],
    password: [
        { required: true, message: '请输入密码', trigger: 'blur' },
        { pattern: /^[a-zA-Z0-9]{6,20}$/, message: '密码只能包含英文字母和数字，长度为6-20字符', trigger: 'blur' }
    ],
    confirmPassword: [
        { required: true, message: '请再次输入密码', trigger: 'blur' },
        { validator: (rule, value, callback) => {
                if (value !== registerForm.value.password) {
                    callback(new Error('两次输入的密码不一致'));
                } else {
                    callback();
                }
            }, trigger: 'blur' }
    ],
    agreeTerms: [
        { validator: (rule, value, callback) => {
                if (!value) {
                    callback(new Error('必须同意用户协议才能注册'));
                } else {
                    callback();
                }
            }, trigger: 'change' }
    ]
};

const submitRegisterForm = () => {
    formRef.value.validate((valid) => {
        if (valid) {
            console.log('注册信息正确，可以提交到服务器:', registerForm.value);
            dialogVisible.value = false; // 关闭对话框

          const registerInfo = "{" +
              "username: " + registerForm.value.username + "," +
              "email: " + registerForm.value.email + "," +
              "password: " + registerForm.value.password +
              "}";

          console.log(registerInfo)

          test(registerInfo);

            // 清空表单
            registerForm.value.username = '';
            registerForm.value.email = '';
            registerForm.value.password = '';
            registerForm.value.confirmPassword = '';
            registerForm.value.agreeTerms = false;




        } else {
            console.log('表单验证未通过');
            return false;
        }
    });
};

const test = (registerInfo) => {
    axios.post('http://bkhb.site:5062/api/Register', {
      registerInfo
    })
    .then((response) => {
      console.log(response);
    })
    .catch((error) => {
      console.log(error);
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
</script>

<template>
    <el-button class="button" color="#e2c8ca" :dark="true" plain link @click="dialogVisible = true">
        注册
    </el-button>
    <el-dialog
        v-model="dialogVisible"
        title="注册"
        width="30%"
        :before-close="handleClose"
    >
        <el-form ref="formRef" :model="registerForm" :rules="registerFormRules" label-width="100px">
            <el-form-item label="用户名" prop="username">
                <el-input v-model="registerForm.username" placeholder="请输入用户名"></el-input>
            </el-form-item>
            <el-form-item label="邮箱" prop="email">
                <el-input v-model="registerForm.email" placeholder="请输入邮箱"></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="password">
                <el-input type="password" v-model="registerForm.password" placeholder="请输入密码" show-password></el-input>
            </el-form-item>
            <el-form-item label="确认密码" prop="confirmPassword">
                <el-input type="password" v-model="registerForm.confirmPassword" placeholder="请再次输入密码" show-password></el-input>
            </el-form-item>
            <el-form-item prop="agreeTerms">
                <el-checkbox v-model="registerForm.agreeTerms">我同意用户协议</el-checkbox>
            </el-form-item>
        </el-form>
        <template #footer>
            <div class="dialog-footer">
                <el-button @click="handleCancel">取消</el-button>
                <el-button type="primary" @click="submitRegisterForm">注册</el-button>
            </div>
        </template>
    </el-dialog>
</template>

<style scoped>
.button {
    margin-left: 12px;
    padding: 2px;
}
</style>