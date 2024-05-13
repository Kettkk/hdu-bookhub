<template>
<!--  element  div-->
  <el-container>
    <el-aside width="500px" id="loginWindow">
      <div style="margin-top: 200px">
        <strong id="title">欢迎来到Ketk22's Blog</strong>
        <div id="subTitle">一个简单的博客系统</div>
      </div>

      <div class="login-form">
        <el-form :model="ruleForm" status-icon :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
          <el-form-item label="用户名" prop="username">
            <el-input v-model="ruleForm.username" autocomplete="off" s></el-input>
          </el-form-item>
          <el-form-item label="密码" prop="password">
            <el-input type="password" v-model="ruleForm.password" autocomplete="off" show-password></el-input>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" id="loginBtn" @click="submitForm('ruleForm')">登录</el-button>
          </el-form-item>
        </el-form>

        <el-form>
          <el-button type="text" id="signUpBtn" @click="go2SighUpForm">还没有账号？马上注册</el-button>
        </el-form>

        <span class="bottomWords">
          Copyright © 2023 Ketk22
        </span>
        <span class="bottomWords">
          &ensp;&emsp;Powered by Vue.js
        </span>
      </div>
    </el-aside>

    <el-main>
      <mountain-of-login-picture></mountain-of-login-picture>
    </el-main>

  </el-container>
</template>

<script>
import { defineComponent } from 'vue'
import mountainOfLoginPicture from "@/components/MountainOfLoginPicture.vue";
import axios from "axios";

export default defineComponent({
  name: 'LoginView',
  components: {
    mountainOfLoginPicture
  },
  data() {
    var validateUsername = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请输入用户名'));
      } else {
        callback();
      }
    };

    var validatePassword = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请输入密码'));
      } else {
        callback();
      }
    };

    return {
      ruleForm: {
        username: '',
        password: ''
      },
      rules: {
        username: [
          { validator: validateUsername, trigger: 'blur' }
        ],
        password: [
          { validator: validatePassword, trigger: 'blur' }
        ]
      },
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          axios.post('http://localhost:8081/api/login', {
            username: this.ruleForm.username,
            password: this.ruleForm.password
          }).then((response) => {
            console.log(response);
            if (response.data.message === 'success') {
              localStorage.setItem('token', response.data.token);
              localStorage.setItem('username', response.data.username);
              this.$router.push('/home/issue');
              console.log('登录成功！')
            } else {
              console.log('登录失败！error: 请检查输入是否正确');
              alert('登录失败！error: 请检查输入是否正确')
            }
          }).catch((error) => {
            console.log(error);
            alert('登录失败！error: 请检查输入是否正确')
          });
        } else {
          console.log('登录失败！error: 请检查输入是否正确');
          alert('登录失败！error: 请检查输入是否正确')
          return false;
        }
      });
    },
    go2SighUpForm() {
      this.$router.push('/signUp')
    },
  },
})
</script>

<style scoped>
#loginWindow {
  height: 100vh;
  background-color: #f5f5f5;
  align-items: center;
}
#loginBtn {
  margin-left: 80%;
}
#signUpBtn {
  margin-left: 35%;
}
#title {
  margin-left: 6%;
  font-size: 23px;
  color: #333;
}
#subTitle {
  margin-top: 5px;
  margin-left: 6%;
  font-size: 14px;
  color: #999;
}
.bottomWords {
  margin-left: 35%;
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
