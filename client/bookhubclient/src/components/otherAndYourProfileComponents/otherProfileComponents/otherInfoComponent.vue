<script setup>
import { ref } from 'vue';

const username = ref('Jay');
const value = ref(3.9);
const squareUrl = ref('https://th.bing.com/th?id=ODL.96e57f16a53ddb576b897410372a9a73&w=100&h=100&c=12&pcl=faf9f7&o=6&dpr=2&pid=13.1');

</script>

<template>
  <div class="common-layout">
    <el-container>

      <el-aside id="asideContainer">
        <div>
          <el-avatar style="margin-top: 8px;cursor: pointer;" shape="square" :size="135" :fit="fill" :src="squareUrl"/>
        </div>
      </el-aside>

      <el-main id="mainContainer">
        <div style="display: flex">
          <el-container id="nameContainer">{{username}}</el-container>
        </div>

          <div style="display: flex">
            <el-container id="starsContainer">
              <el-rate
                  v-model="value"
                  disabled
                  show-score
                  text-color="#ff9900"
                  score-template="{value}"
              />
            </el-container>

            <el-button round :size="'large'" id="sendMessageBtn">发消息</el-button>
          </div>


      </el-main>
    </el-container>
  </div>
</template>

<style scoped>
#asideContainer{
  width: 180px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
}
#mainContainer{
  width: 1276px;
  height: 150px;
  background-color: #f6f8fa;
}
#nameContainer{
  height: 40px;
  width: 150px;
  font-size: 22px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
}
#starsContainer{
  height: 80px;
  width: 80px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
  padding-top: 35px;
}
#sendMessageBtn{
  margin-top: 30px;
}
</style>