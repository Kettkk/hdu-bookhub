<script setup>

import UserInfoComponent from "@/components/otherAndYourProfileComponents/yourProfileComponents/userInfoComponent.vue";
import UserGoodInfoComponent
    from "@/components/otherAndYourProfileComponents/yourProfileComponents/userGoodInfoComponent.vue";
</script>

<template>
 <div>
   <el-container id="userInfoContainer">
     <user-info-component></user-info-component>
   </el-container>

   <hr class="separator">

   <el-container id="userGoodInfoComtainer">
      <user-good-info-component></user-good-info-component>
   </el-container>
 </div>
</template>

<style scoped>
#userInfoContainer{
  height: 140px;
  background-color: #f6f8fa;
}
#userGoodInfoComtainer{
  height: 400px;
  background-color: #f6f8fa;
}
.separator {
  margin: 5px 0;
  border: none;
  background-color: #f6f8fa;
  border-top: 1px solid #d9d8d8;
}
</style>