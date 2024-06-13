<script lang="ts" setup>
import {ref} from 'vue'
import axios from "axios";
import router from '@/router';

const signUpFrom = ref({
    username: '',
    password: '',
    passwordAgain: ''
});

const signUp = () => {
    const from = signUpFrom.value
    if (from.password !== from.passwordAgain) {
        alert('两次输入的密码不一致！')
        return
    }
    axios.post('http://localhost:5062/api/AdminSignUp', {username: from.username, password: from.password})
        .then(response => {
            console.log(response)
            if (response.status == 200) {
                alert('注册成功！')
                router.push({name: 'login'})
            } else {
                alert('注册失败！用户已存在')
            }
        })
        .catch(error => {
            console.log(error)
            alert('注册失败！')
        })
}
const go2LoginView = () =>{
  router.push({name: 'login'})
}
</script>

<template>
  <div id="view">
    <div id="topItem">
      Sign Up
    </div>
    <el-container id="formContainer">

      <el-form>
        <el-form-item label="用户名">
          <el-input
              placeholder="输入用户名"
              v-model=signUpFrom.username
              clearable>
          </el-input>
        </el-form-item>

        <el-form-item label="密码">
          <el-input
              placeholder="输入密码"
              v-model="signUpFrom.password"
              clearable
              show-password
              >
          </el-input>
        </el-form-item>

        <el-form-item label="再次输入密码">
          <el-input
              placeholder="重复输入密码"
              v-model="signUpFrom.passwordAgain"
              clearable
              show-password
              >
          </el-input>
        </el-form-item>

        <el-form-item id="btnContainer">
          <el-button type="primary" @click="signUp">注册</el-button>
          <el-button type="primary" @click="go2LoginView">返回</el-button>
        </el-form-item>
      </el-form>

    </el-container>
  </div>

</template>

<style scoped>
#formContainer {
  border: #999999 solid 1px;
  border-radius: 10px;
  background: whitesmoke;
  width: 500px;
  height: auto;
  margin-top: 150px;
  margin-left: 580px;
  padding: 60px;
}
#btnContainer {
  margin-left: 200px;
}
#topItem {
  width: 100%;
  height: 50px;
  background: #2c3e50;
  color: whitesmoke;
  font-size: 30px;
  text-align: center;
  font-family: "Apple Braille";
}
#view {
  width: 100%;
  height: 100vh;
  background: #ecf0f1;
}
</style>