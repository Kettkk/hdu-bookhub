<script setup>
import GoodsWindow from "@/components/otherAndYourProfileComponents/child3ViewComponents/goodsWindow.vue";


const goodsList = [
  {
    id: 1,
    name: "Apple",
    price: 10,
    description: "Fresh apple from the garden",
    image: "https://th.bing.com/th/id/OIP.NSqoq-JMoS7QzSJeSJTA0QHaIO?w=164&h=182&c=7&r=0&o=5&dpr=2&pid=1.7",
  },
  {
    id: 2,
    name: "Banana",
    price: 5,
    description: "Fresh banana from the garden",
    image: "https://th.bing.com/th/id/OIP.DzzBtp9wRuY1VocmOurZ7gHaJE?w=134&h=180&c=7&r=0&o=5&dpr=2&pid=1.7",
  },
  {
    id: 3,
    name: "Orange",
    price: 7,
    description: "Fresh orange from the garden",
    image: "https://cdn.pixabay.com/photo/2016/11/22/23/44/orange-1851465_960_720.jpg",
  },
  {
    id: 4,
    name: "Pineapple",
    price: 15,
    description: "Fresh pineapple from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/pineapple-1238248_960_720.jpg",
  },
  {
    id: 5,
    name: "Strawberry",
    price: 20,
    description: "Fresh strawberry from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/strawberries-1238249_960_720.jpg",
  },
  {
    id: 6,
    name: "Watermelon",
    price: 25,
    description: "Fresh watermelon from the garden",
    image: "https://cdn.pixabay.com/photo/2016/03/05/19/02/watermelon-1238250_960_720.jpg",
  },
];

</script>

<template>
<div>
 <div id="goodsWindowsContainer">

    <GoodsWindow v-for="good in goodsList" :key="good.id" :good="good" ></GoodsWindow>

 </div>
</div>
</template>

<style scoped>

#goodsWindowsContainer{
  background-color: #bdd1e5;
  width: 100%;
  height: auto;
  display: flex;
  flex-wrap: wrap;
}
</style>