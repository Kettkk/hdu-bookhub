<template>
    <div id="message">
        <div id="message-content">
            嗨！很高兴见到你！希望你今天过得愉快。无论是新的一天还是美好的夜晚，都希望你能充满活力，心情愉快。
            在这个瞬息万变的世界里，与你分享这一刻，感觉格外美好。无论你正在做什么，我都想对你说声“你好”，
            愿你的每一天都充满阳光和欢笑！
        </div>
        <el-avatar id="message-avatar" :icon="UserFilled" />
    </div>
</template>

<script setup>
    
</script>

<style scoped>
#message{
    display: flex;
    justify-content: flex-end;
    margin: 20px 0px 20px 0px;
}

#message-content{
    max-width: 350px;
    border-radius: 10px;
    font-size: 13px;
    color: white;
    background-color:#9370DB; 
    padding: 12px;
    line-height: 20px;
}

#message-avatar{
    margin: 0px 15px 0px 15px;
}
</style>