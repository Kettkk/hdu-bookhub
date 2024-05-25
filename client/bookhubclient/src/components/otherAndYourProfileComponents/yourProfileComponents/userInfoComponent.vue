<script setup lang="ts">
import { onMounted, ref } from 'vue';
import axios from 'axios';
const dialogFormVisible = ref(false);
const dialogPublishGoodVisible = ref(false);

//#region 个人信息显示JS
const username = ref('');
const money = ref();
const star = ref();
const squareUrl = ref('');
onMounted(() => {
  const tokenStr = document.cookie.split('=')[1]

  axios.post('http://localhost:5062/api/PersonalPage', {
    tokenValue: tokenStr
  })
    .then(function (response) {
      username.value = response.data.userName
      star.value = response.data.star
      money.value = response.data.money
      squareUrl.value = response.data.avatarImg
      console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });
})
//#endregion

//#region 商品上传功能JS
import { ElDialog, UploadProps, UploadFile, ElMessage } from "element-plus"
import { Plus, EditPen } from '@element-plus/icons-vue'

const price = ref('')
const goodName = ref('')
const description = ref('')
const formData = new FormData()//存储数据

const validImageFormats = ["jpg", "jpeg", "png"];
//选择文件格式校验//并限制上传数量
const checkImageFormat = (file) => {
  console.log("文件格式校验");
  console.log(file);
  // noUpload.value = true
  const fileFormat = file.name.split(".").pop().toLowerCase(); // 获取文件格式
  if (!validImageFormats.includes(fileFormat)) {
    ElMessage({ type: "error", message: "商品图片格式必须为 jpg/jpeg/png" });
    faceList.value = []; //删除格式不符合的文件
    return false; // 阻止文件上传
  }

  formData.append("img", file.raw)
  noUpload.value = true//设置为true阻止继续上传
  return true; // 允许文件上传
};

const dialogImageUrl = ref(""); //预览图片路径
const dialogVisible = ref(false); //预览框可见
//删除
const handleImgRemove: UploadProps["onRemove"] = (file: UploadFile) => {
  console.log("删除图片：");
  console.log(faceList.value);
  formData.delete("img");
  noUpload.value = false
};
//预览
const handlePictureCardPreview: UploadProps["onPreview"] = (file: UploadFile) => {
  dialogImageUrl.value = file.url!;
  dialogVisible.value = true;
};

const faceList = ref([])//图片列表
const noUpload = ref(false)//不再上传

const closePublishGoodDialog = () => {
  price.value = ''
  goodName.value = ''
  description.value = ''
  faceList.value = []
  noUpload.value = false
  dialogPublishGoodVisible.value = false
}

const submitGoodInfo = () => {
  if (goodName.value == '' || price.value == '' || description.value == '' || !formData.has("img")) {
    ElMessage({
      message: '商品信息请填写完整',
      type: 'error',
      plain: true
    })
  } else {
    formData.append("goodName", goodName.value)
    formData.append("price", price.value)
    formData.append("description", description.value)

    const tokenStr = document.cookie.split('=')[1]
    axios.post('http://localhost:5062/api/PublishBook', formData, {
      headers: {
        Authorization: `Bearer ${tokenStr}`
      }
    })
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

    //上传商品信息后所有内容置空
    dialogPublishGoodVisible.value = false;
    price.value = ''
    goodName.value = ''
    description.value = ''
    faceList.value = []
    noUpload.value = false;
    ElMessage({
      message: '发布成功',
      type: 'success',
      plain: true,
    })
    setTimeout(() => {
      location.reload();
    }, 2000); 
  }
}
//#endregion

//#region 修改个人信息功能JS
const editedName = ref('')
const editedEmail = ref('')
const editedFormData= new FormData()

const checkAvatarFormat = (file) => {
  const fileFormat = file.name.split(".").pop().toLowerCase(); // 获取文件格式
  if (!validImageFormats.includes(fileFormat)) {
    ElMessage({ type: "error", message: "商品图片格式必须为 jpg/jpeg/png" });
    avatarList.value = []; //删除格式不符合的文件
    return false; // 阻止文件上传
  }
  editedFormData.append("img",file.raw)
  dontUpload.value = true//设置为true阻止继续上传
  return true; // 允许文件上传
};

const previewImageUrl = ref(""); //预览图片路径
const isdialogVisible = ref(false); //预览框可见
//删除
const handleAvatarRemove: UploadProps["onRemove"] = (file: UploadFile) => {
  editedFormData.delete("img")
  dontUpload.value = false
};
//预览
const handleAvatarPreview: UploadProps["onPreview"] = (file: UploadFile) => {
  previewImageUrl.value = file.url!;
  isdialogVisible.value = true;
};

const avatarList = ref([])//图片列表
const dontUpload = ref(false)//不再上传

//关闭编辑个人信息窗口，清空信息
const closeEditInfoDialog = () => {
  editedName.value=''
  editedEmail.value=''
  avatarList.value=[]
  dontUpload.value=false
  dialogFormVisible.value=false
}
//提交修改内容的方法
const submitUserInfo = () => {
  if(editedName.value =='' && editedEmail.value == '' && !editedFormData.has("img"))
  {
    ElMessage({
      message:'若要修改个人信息，请至少填写一项内容',
      type:'error',
      plain:true
    })
  }else{
    editedFormData.append("editedName",editedName.value)
    editedFormData.append("editedEmail",editedEmail.value)
    
    const tokenStr = document.cookie.split('=')[1]
    axios.post('http://localhost:5062/api/EditPersonalInfo', editedFormData, {
      headers: {
        Authorization: `Bearer ${tokenStr}`
      }
    })
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

    dialogFormVisible.value=false
    editedName.value=''
    editedEmail.value=''
    avatarList.value=[]
    dontUpload.value=false
    ElMessage({
      message: '修改成功',
      type: 'success',
      plain: true,
    })
    setTimeout(() => {
      location.reload();
    }, 2000); 
  }
}
//#endregion
</script>


<template>
  <div class="common-layout">
    <el-container>
      <el-aside id="asideContainer">
        <div>
          <el-avatar @click="dialogFormVisible = true" style="margin-top: 8px;cursor: pointer;" shape="square"
            :size="135" fit="fill" :src="squareUrl" />
        </div>
        <!-- #region 修改个人信息组件 -->
        <el-dialog v-model="dialogFormVisible" width="360px" :before-close="closeEditInfoDialog">
          <template #title>
            <div style="text-align: left;">修改个人信息</div>
          </template>
          <div style="display: flex;margin-bottom: 15px;;margin-top: 10px;">
            <span style="margin-right: 5px;">用户名</span>
            <el-input v-model="editedName" style="width: 240px" />
          </div>
          <div style="display: flex;margin-bottom:15px ;">
            <span style="margin-right: 18px;">邮箱</span>
            <el-input v-model="editedEmail" style="width: 240px" />
          </div>

          <div style="display: flex;">
            <span style="margin-right: 18px;">头像</span>
            <el-upload :class="{ disabled: dontUpload }" :auto-upload="false" list-type="picture-card"
              :on-preview="handleAvatarPreview" :on-change="checkAvatarFormat" :on-remove="handleAvatarRemove"
              :limit="1" ref="businessLicense" :file-list="avatarList">

              <el-icon v-if="avatarList.length == 0">
                <EditPen />
              </el-icon>
            </el-upload>
          </div>

          <el-dialog v-model="isdialogVisible">
            <img w-full :src="previewImageUrl" alt="Preview Image" class="preview-image"/>
          </el-dialog>


          <div style="margin-top: 15px;">
            <el-button type="primary" @click="submitUserInfo">修改完成</el-button>
          </div>

        </el-dialog>
        <!-- #endregion -->
      </el-aside>

      <el-main id="mainContainer">
        <div style="display: flex">
          <el-container id="nameContainer">{{ username }}</el-container>
          <el-button size="large" @click="dialogPublishGoodVisible = true">发布商品</el-button>

          <!-- #region 商品发布组件 -->
          <el-dialog v-model="dialogPublishGoodVisible" title="发布商品" width="620px"
            :before-close="closePublishGoodDialog">
            <div style="display: flex;">
              <div>
                <div style="display: flex; margin-bottom: 15px;width: 220px;">
                  <span style="margin-right: 5px;">
                    商品图片
                  </span>
                  <el-upload :class="{ disabled: noUpload }" :auto-upload="false" list-type="picture-card"
                    :on-preview="handlePictureCardPreview" :on-change="checkImageFormat" :on-remove="handleImgRemove"
                    :limit="1" ref="businessLicense" :file-list="faceList">
                    <el-icon v-if="faceList.length == 0">
                      <Plus />
                    </el-icon>
                  </el-upload>
                </div>

                <el-dialog v-model="dialogVisible">
                  <img class="preview-image" :src="dialogImageUrl" alt="Preview Image" />
                </el-dialog>

                <div style="display: flex;margin-bottom: 15px;width: 220px; ">
                  <span style="margin-right: 5px; display: flex; align-items: center;">商品名称</span>
                  <el-input v-model="goodName" style="width: 148px" maxlength="10" show-word-limit type="text" />
                </div>

                <div style="display: flex;width: 220px;">
                  <span style="margin-right: 5px; display: flex; align-items: center;">商品价格</span>
                  <el-input v-model="price" style="width: 148px" maxlength="10" show-word-limit type="text" />
                </div>
              </div>

              <div>
                <div style="display: flex; ">
                  <span style="margin-right: 5px;">商品描述</span>

                  <el-input v-model="description" maxlength="180" style="width: 300px" show-word-limit type="textarea"
                    resize="none" rows="11" />
                </div>

                <div style="float: right; margin-top: 15px;">
                  <el-button type="primary" @click="submitGoodInfo">上传</el-button>
                </div>

              </div>
            </div>
          </el-dialog>
          <!-- #endregion -->
        </div>

        <!--#region 账户余额和评分显示-->
        <div style="display: flex">
          <div style="display: flex">
            <el-container id="moneyTextContainer">账号余额:</el-container>
            <el-container id="moneyContainer" v-model="money">{{ money }} ¥</el-container>
          </div>

          <el-container id="starsContainer">
            <el-rate v-model="star" disabled text-color="#ff9900" size="large" />
          </el-container>
        </div>
        <!--endregion-->
      </el-main>
    </el-container>
  </div>
</template>

<style scoped>
#asideContainer {
  width: 180px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
}

#mainContainer {
  width: 1276px;
  height: 150px;
  background-color: #f6f8fa;
}

#nameContainer {
  height: 40px;
  width: 150px;
  font-size: 22px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
}

#moneyContainer {
  height: 80px;
  width: 150px;
  font-size: 30px;
  font-family: "Apple Braille";
  color: #726969;
  background-color: #f6f8fa;
  padding-top: 35px;

}

#moneyTextContainer {
  height: 80px;
  width: 70px;
  font-size: 15px;
  font-family: "Apple Braille";
  color: #726969;
  padding-top: 45px;
}

#starsContainer {
  height: 80px;
  width: 80px;
  background-color: #f6f8fa;
  text-align: center;
  justify-content: space-between;
  padding-top: 35px;
  padding-left: 860px;
}

.avatar-uploader .avatar {
  width: 178px;
  height: 178px;
  display: block;
}

/*发布商品的样式*/
::v-deep .disabled .el-upload--picture-card {
  display: none !important;
}

.preview-image {
  max-width: 100%;
  max-height: 80vh;
}
</style>