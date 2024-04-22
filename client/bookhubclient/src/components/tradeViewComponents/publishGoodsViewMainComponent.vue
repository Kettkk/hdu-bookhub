<script lang="ts" setup>
import { ref } from 'vue'

const price = ref('')

const goodName = ref('')

</script>

<template>
<div>

  <el-container>
    <el-aside>
      <el-container id="goodImgContainer">

      </el-container>

      <div style="width: 300px;height: 100px;">
        <el-container id="priceContainer">
          <el-container style="margin-top: 5px;margin-left: 5px">商品价格</el-container>
          <el-input
              v-model="price"
              style="width: 180px"
              maxlength="10"
              placeholder="输入商品价格"
              show-word-limit
              type="text"
              suffix-icon="el-icon-money"
          />
        </el-container>

        <el-container id="priceContainer">
          <el-container style="margin-top: 5px;margin-left: 5px">商品名</el-container>
          <el-input
              v-model="goodName"
              style="width: 180px"
              maxlength="10"
              placeholder="输入商品名"
              show-word-limit
              type="text"
              suffix-icon="el-icon-money"
          />
        </el-container>
      </div>


    </el-aside>

    <el-main>
      <div id="goodDescriptionContainer">
          <el-card style="min-height: 240px;max-height: 330px">
            <template #header>商品描述</template>
            <div id="scrollable-container" contenteditable="true">
            </div>
          </el-card>
      </div>

      <div id="publishBtnContainer">
        <el-button round :size="'large'" id="publishBtn">发布商品</el-button>
      </div>
    </el-main>
  </el-container>
</div>
</template>

<style scoped>
#priceContainer{
  margin-top: 25px;
  margin-left: 50px;
  font-size: 15px;
  font-family: 'Apple Braille';
  box-shadow: 0px 2px 4px rgba(0, 0.1, 0.1, 0.1);
  color: #3d3939;
  display: flex;
}
#goodImgContainer{
  width: 260px;
  height: 260px;
  background-color: #f6f8fa;
  margin-top: 25px;
  margin-left: 50px;
  border-radius: 4px
}
#goodDescriptionContainer{
  height: 260px;
  width: 650px;
  background-color: #e9e9ea;
  margin-top: 5px;
  margin-left: 50px;
  border-radius: 4px;
}
#publishBtnContainer{
  margin-top: 70px;
  margin-left: 480px;
}
#publishBtn{
  width: 200px;
  height: 50px;
  background-color: #3d3939;
  color: #f6f8fa;
}
#scrollable-container{
  height: 200px;
  overflow-y: auto;
  padding: 10px;
  font-size: 15px;
  line-height: 1.5;
}
.avatar-uploader .avatar {
  width: 178px;
  height: 178px;
  display: block;
}
</style>