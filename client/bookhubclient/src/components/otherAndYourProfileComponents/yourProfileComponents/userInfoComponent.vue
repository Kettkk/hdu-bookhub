<script setup>
import { ref } from 'vue';
import GoodImgUploader from "@/components/tradeViewComponents/goodImgUploader.vue";
import { ElMessage } from 'element-plus'

const username = ref('Jay');
const money = ref(1000);
const value = ref(3.9);
const squareUrl = ref('src/assets/userAvatars/Jay.jpg');
const dialogFormVisible = ref(false);
const dialogPublishGoodVisible = ref(false);
const email = ref('ketk03@outlook.com');
const userCreateTime = ref('2021-10-10');
const templeUsername = ref(username.value);


const price = ref('')
const goodName = ref('')

const closePublishDialog = () => {
  dialogPublishGoodVisible.value = false;
  ElMessage({
    message: '发布成功',
    type: 'success',
    plain: true,
  })
}


const submitUserInfo = () => {

}
</script>

<template>
  <div class="common-layout">
    <el-container>

      <el-aside id="asideContainer">
        <div>
          <el-avatar @click="dialogFormVisible = true" style="margin-top: 8px;cursor: pointer;" shape="square" :size="135" :fit="fill" :src="squareUrl"/>
        </div>

        <el-dialog v-model="dialogFormVisible" title="修改个人信息" width="800">
          <el-form>

            <el-form-item label="用户名">
              <el-input v-model="templeUsername"></el-input>
            </el-form-item>

            <el-form-item label="邮箱">
              <el-input v-model="email" disabled></el-input>
            </el-form-item>

            <el-form-item label="账号余额">
              <el-input v-model="money" disabled></el-input>
            </el-form-item>

            <el-form-item>
              <el-form-item label="账号创建时间">
                <el-input v-model="userCreateTime" disabled></el-input>
              </el-form-item>
            </el-form-item>

            <el-form-item label="我的评分">
              <el-rate
                  v-model="value"
                  disabled
                  show-score
                  text-color="#ff9900"
                  score-template="{value} points"
              />
            </el-form-item>


            <el-form-item><span style="font-size: 20px">修改头像</span></el-form-item>

            <el-form-item>
              <el-container>
                <el-upload
                    class="upload-demo"
                    drag
                    action="none"
                >
                  <el-icon class="el-icon--upload"><upload-filled /></el-icon>
                  <div class="el-upload__text">
                    上传头像 <em>点击此处上传</em>
                  </div>
                  <template #tip>
                    <div class="el-upload__tip">
                      上传的文件大小不超高 500kb
                    </div>
                  </template>
                </el-upload>

              </el-container>
            </el-form-item>

          </el-form>

          <span class="dialog-footer">
            <el-button type="primary" @click="dialogFormVisible = false; submitUserInfo()">修改完成</el-button>
          </span>

        </el-dialog>
      </el-aside>

      <el-main id="mainContainer">
          <div style="display: flex">
            <el-container id="nameContainer">{{username}}</el-container>
            <el-button size="large" @click="dialogPublishGoodVisible = true">发布商品</el-button>

            <!-- 商品发布组件 -->
            <el-dialog v-model="dialogPublishGoodVisible" title="发布商品" width="1100">

              <div>
                <el-container>
                  <el-aside>
                    <el-container id="goodImgContainer">
                      <good-img-uploader></good-img-uploader>
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
                      <el-button round :size="'large'" id="publishBtn" @click="closePublishDialog">发布商品</el-button>
                    </div>
                  </el-main>
                </el-container>
              </div>
            </el-dialog>
          </div>
        <!-- 商品发布组件 -->

          <div style="display: flex">
            <div style="display: flex">
              <el-container id="moneyTextContainer">账号余额:</el-container>
              <el-container id="moneyContainer" v-model="money">{{money}} ¥</el-container>
            </div>

            <el-container id="starsContainer">
              <el-rate
                  v-model="value"
                  disabled
                  show-score
                  text-color="#ff9900"
                  score-template="{value}"
              />
            </el-container>
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
#moneyContainer{
  height: 80px;
  width: 150px;
  font-size: 30px;
  font-family: "Apple Braille";
  color: #726969;
  background-color: #f6f8fa;
  padding-top: 35px;

}
#moneyTextContainer{
  height: 80px;
  width: 70px;
  font-size: 15px;
  font-family: "Apple Braille";
  color: #726969;
  padding-top: 45px;
}
#starsContainer{
  height: 80px;
  width: 80px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
  padding-top: 35px;
  padding-left: 860px;
}
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
  margin-left: 35px;
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