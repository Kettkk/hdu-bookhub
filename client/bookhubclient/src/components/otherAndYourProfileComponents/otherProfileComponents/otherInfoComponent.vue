<script setup>
import { ref } from 'vue';

const squareUrl = ref('https://avatars.githubusercontent.com/u/26627064?v=4');

</script>

<template>
<div id="otherInfoContainer">
  <div>
    <el-aside id="asideContainer">
      <div>
        <el-avatar  style="margin-top: 10px;cursor: pointer;" shape="square" :size="135" :fit="fill" :src="squareUrl"/>
      </div>
    </el-aside>

    <el-main>
      <div>

      </div>
    </el-main>
  </div>


</div>
</template>

<style scoped>
#otherInfoContainer{
  width: 100%;
  height: 170px;
  background-color: #f1e0e0;
}
#asideContainer{
  width: 180px;
  text-align: center;
  background-color: #3d3939;
  justify-content: space-between;
}
</style>