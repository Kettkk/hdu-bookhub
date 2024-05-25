<script setup>
    import { onMounted, onBeforeUnmount } from 'vue';
    import NavHeader from "@/components/homeViewComoponents/navHeaderComponent.vue";
    import HeaderSearchBox from "@/components/homeViewComoponents/headerSearchBoxComponent.vue";
    import Footer from "@/components/homeViewComoponents/homeViewFooterComponent.vue";
    import SearchedBookList from "@/components/searchBooksViewComponents/searchedBookList.vue";

    const handleKeyDown = (event) => {
      if (event.keyCode === 13) {
        location.reload();
      }
    };

    onMounted(() => {
      window.addEventListener('keydown', handleKeyDown);
    });

    onBeforeUnmount(() => {
      window.removeEventListener('keydown', handleKeyDown);
    });
</script>

<template>
    <div>
        <nav-header></nav-header>
        <header-search-box></header-search-box>
        <searchedBookList></searchedBookList>
        <Footer></Footer>
    </div>
</template>

<style scoped>

</style>