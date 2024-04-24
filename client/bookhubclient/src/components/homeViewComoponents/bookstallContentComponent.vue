<script setup>
import { ref } from 'vue';
import BookstallNewBooksComponent from "@/components/homeViewComoponents/bookstallNewBooksComponent.vue";
import BookstallHighOpinionComponent from "@/components/homeViewComoponents/bookstallHighOpinionComponent.vue";

// 初始化时默认显示"文字一"的内容
const activeContent = ref('content1');

const showContent = (contentId) => {
    activeContent.value = contentId;
};

// 修改hideContent以不清除activeContent
const hideContent = () => {
    // 想让文字保持高亮，所以这里不重置 activeContent
};
</script>

<template>
    <div>
        <div class="text-container">
            <span @mouseover="showContent('content1')" @mouseleave="hideContent"
                  :class="{ 'highlight': activeContent === 'content1', 'text-one': activeContent === 'content1' }">最新发布</span>
            <span @mouseover="showContent('content2')" @mouseleave="hideContent"
                  :class="{ 'highlight': activeContent === 'content2', 'text-one': activeContent === 'content2' }">好评优先</span>
        </div>

        <div class="content-section">
            <div v-if="activeContent === 'content1'" class="content"><bookstall-new-books-component></bookstall-new-books-component></div>
            <div v-if="activeContent === 'content2'" class="content"><bookstall-high-opinion-component></bookstall-high-opinion-component></div>
        </div>
    </div>
</template>

<style scoped>
.text-container {
    margin-top: 30px;
    margin-bottom: 20px;
    display: flex;
}

.text-container span {
    margin-right: 20px;
    cursor: pointer;
    color: #333;
    transition: color 0.3s ease;
    font-size: 16px;
}

.text-container span:hover {
    color: #e60000;
}

.text-container .text-one {
    font-weight: bold;
}

.content-section {
    border: 1px solid #ccc;
    padding: 20px;
    border-radius: 5px;
    background-color: #f9f9f9;
}

.content-section .content.show {
    display: block;
}
</style>