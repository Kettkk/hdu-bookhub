<script setup>

</script>

<template>
<div>
 <el-container id="ComponentsWindows">
   <el-row v-for="(row, index) in rows" :key="index">
     <el-col v-for="(product, colIndex) in row" :key="colIndex" :span="4">
       <product-item :product="product" v-if="product"></product-item>
     </el-col>
   </el-row>
 </el-container>


</div>
</template>

<style scoped>

</style>