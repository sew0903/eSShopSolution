//.............................. Menu-SLIDERBAR-CARTEGORY....................
const itemsliderbar= document.querySelectorAll(".cartegory-left-li")
itemsliderbar.forEach(function(menu, index){
   menu.addEventListener("click",function(){
        menu.classList.toggle("block")
   })
})

/*-------------------------------PRODUCT- CONTENT- BOTTOM-------------------- */
const baoquan= document.querySelector(".baoquan")
const chitiet= document.querySelector(".chitiet")
if(baoquan){
   baoquan.addEventListener("click",function(){
      document.querySelector(".product-right-bottom-content").style.display="none"
      document.querySelector(".product-right-bottom-content-baoquan").style.display="block"
   })
}

if(chitiet){
   chitiet.addEventListener("click",function(){
      document.querySelector(".product-right-bottom-content").style.display="block"
      document.querySelector(".product-right-bottom-content-baoquan").style.display="none"
   })
}

const butTon = document.querySelector(".product-content-right-bottom-top")
if(butTon){
   butTon.addEventListener("click",function(){
      document.querySelector(".product-content-right-bottom-content-big").classList.toggle="activeB"
   })
}
const bigImg= document.querySelector(".product-content-left-big-img img")
const smallImg= document.querySelectorAll(".product-content-left-small-img img")
smallImg.forEach(function(imgItem,X){
    imgItem.addEventListener("click",function(){
        bigImg.src=imgItem.src
    })
})