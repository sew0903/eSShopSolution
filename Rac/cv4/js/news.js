let menu=document.getElementById("menu");

window.addEventListener('scroll',function(){
   var value=window.scrollY;
   if(value>160){
      document.getElementById("menu").style.position="fixed";
      document.getElementById("menu").style.top=0;
   } else {
      document.getElementById("menu").style.position="relative";

   }

});

function open_news(){
   document.querySelector(".bar-news-dow").classList.toggle("show")
}

function close_news(){
   document.querySelector(".bar-news-dow").classList.remove("show")
}