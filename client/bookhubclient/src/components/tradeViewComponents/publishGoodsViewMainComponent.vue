<script lang="ts" setup>
const username = 'Jay';
import { ref } from 'vue'
import { ElMessage } from 'element-plus'
import { Plus } from '@element-plus/icons-vue'

import type { UploadProps } from 'element-plus'

const price = ref('')

const goodName = ref('')

const imageUrl = ref('')


const handleAvatarSuccess: UploadProps['onSuccess'] = (
    response,
    uploadFile
) => {
  imageUrl.value = URL.createObjectURL(uploadFile.raw!)
}
const beforeAvatarUpload: UploadProps['beforeUpload'] = (rawFile) => {
  if (rawFile.type !== 'image/jpeg') {
    ElMessage.error('Avatar picture must be JPG format!')
    return false
  } else if (rawFile.size / 1024 / 1024 > 2) {
    ElMessage.error('Avatar picture size can not exceed 2MB!')
    return false
  }
  return true
}
</script>

<template>
<div>

  <el-container>
    <el-aside>
      <el-container id="goodImgContainer">
        <el-upload
            class="avatar-uploader"
            action="https://run.mocky.io/v3/9d059bf9-4660-45f2-925d-ce80ad6c4d15"
            :show-file-list="false"
            :on-success="handleAvatarSuccess"
            :before-upload="beforeAvatarUpload"
        >
          <img v-if="imageUrl" :src="imageUrl" class="avatar" />
          <el-icon v-else class="avatar-uploader-icon"><Plus /></el-icon>
        </el-upload>
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