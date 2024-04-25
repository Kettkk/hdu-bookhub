<script setup>
import router from "@/router/index.js";

const bookName = '《JavaScript高级程序设计》';
const sellerName = 'Jay';
const price = 100;
const value = 4;
const goodDescription = '《JavaScript高级程序设计》:这是一本非常好的书籍，适合初学者和高级程序员。零零落落零零落落零零落落零零落落零零落落零零落落零零落落零零落落零零落落';

const go2ChatView = () => {
  console.log('go2ChatView');
  router.push('/chatRoom');
}

const go2otherProfileView = () => {
  console.log('go2otherProfileView');
  router.push('/userProfile/otherProfile');
}
</script>

<template>
 <div>
  <div id="titleContainer">书籍购买  &emsp;>> &emsp;{{bookName}}</div>

   <div style="display: flex">
     <el-aside>
       <div id="goodImgContainer">
         <img src="https://booklibimg.kfzimg.com/data/book_lib_img_v2/user/2/459e/459e843b643f6c6909982da9a4ee4285_0_2_140_140.jpg" alt="书籍图片" width="300px" height="300px">
       </div>

       <div id="goodPriceContainer">价格&emsp;
         <div style="color: #e33546;font-size: 22px;">{{price}} &ensp;¥</div>
       </div>
     </el-aside>

     <el-main>
       <div @click="go2otherProfileView" id="sellerInfoContainer">
          <div id="avatarContainer">
            <el-avatar
                src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"
                :size="'large'"
            />
          </div>
          <div id="sellerNameAndStarsContainer">
            <div style="display: flex;margin-top: 8px;">
              <div style="font-size: 12px;margin-top: 8px">用户名:&ensp;</div>
              {{sellerName}}
            </div>

            <div style="margin-top: 8px">
              <el-rate
                  v-model="value"
                  :size="'small'"
                  disabled
                  show-score
                  text-color="#ff9900"
                  score-template="{value}"
              />
            </div>
          </div>

         <div id="sendMessageBtn">
           <el-button round :size="'large'" @click="go2ChatView" id="sendMessageBtn">联系卖家</el-button>
         </div>
       </div>


       <div id="goodDescriptionContainer">

         <div id="scrollable-container">
           <el-card style="max-width: 800px; min-height: 300px">
             <template #header>商品描述</template>
             {{goodDescription}}
           </el-card>
         </div>


       </div>
     </el-main>

   </div>
 </div>
</template>

<style scoped>
#titleContainer{
  height: 40px;
  background-color: #ededee;
  line-height: 40px;
  padding-left: 10px;
  font-size: 15px;
  font-family: 'Apple Braille';
  color: #3d3939;
}
#goodImgContainer{
  width: 300px;
  height: 300px;
  background-color: #f6f8fa;
  margin-top: 35px;
  margin-left: 50px;
  border-radius: 4px
}
#goodPriceContainer{
  width: 300px;
  height: 40px;
  background-color: #e9e9ea;
  margin-left: 50px;
  font-size: 16px;
  font-family: "Microsoft YaHei";
  color: #939292;
  display: flex;
  padding-left: 35px;
  padding-top: 20px;
}
#sellerInfoContainer{
  height: 80px;
  width: 100%;
  background-color: #e9e9ea;
  margin-top: 25px;
  display: flex;
  cursor: pointer;
}
#avatarContainer{
  height: 70px;
  width: 70px;
  background-color: #e9e9ea;
  padding-top: 10px;
  padding-left: 10px;
}
#sellerNameAndStarsContainer{
  height: 70px;
  width: 200px;
  background-color: #e9e9ea;
  padding-top: 10px;
  padding-left: 20px;
  font-size: 22px;
  font-family: 'Apple Braille';
  color: #3d3939;
}
#sendMessageBtn{
  margin-top: 10px;
  margin-left: 370px;
}
#goodDescriptionContainer{
  height: 300px;
  width: 800px;
  background-color: #e9e9ea;
  margin-top: 25px;
  margin-left: 50px;
  border-radius: 4px;
}
#scrollable-container{
  height: 300px;
  overflow-y: auto;
}
</style>