<!--搜索栏开始-->
<script setup>
    import { ref } from 'vue'
    import router from '@/router/index.js'
    import { Search } from '@element-plus/icons-vue'
    const input3 = ref('');

    const go2homeView = () => {
        router.push({name: 'home'})
    }

</script>
<template>
    <div id="headerSearchBox" class="header-search-box">
        <div class="header-search">
          <img src="../../assets/HDUBookhub.png" class="logo" alt="logo" @click="go2homeView"/>
            <div class="search-box">
                <div class="mt-4">
                    <el-input v-model="input3" style="max-width: 600px" placeholder="商品名称" class="input-with-select" size="large">
                        <template #append>
                            <el-button :icon="Search" />
                        </template>
                    </el-input>
                </div>
            </div>
        </div>
    </div>
</template>
<style>
    .header-search-box {
        background: #f2f1ea;
        height: 100px;
    }
    .header-search{
        width: 1200px;
        height: 100px;
        margin: 0 auto;
        padding-top: 25px;
        box-sizing: border-box;
    }
    .logo {
      max-height: 40px;
      cursor: pointer;
    }
    .search-box {
        float: right;
    }
    .mt-4 {
        margin-top: 4px;
        width: 600px;
    }
</style>