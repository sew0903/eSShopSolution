function btn1_1(){
    document.querySelector(".btn1-1").classList.toggle("active3");
    document.querySelector(".choose_p").classList.toggle("choose-mod");
    
    document.querySelector(".btn1-2").classList.remove("active3");
    document.querySelector(".choose_p1").classList.remove("choose-mod");
    
    
  }
  function btn1_2(){
    document.querySelector(".btn1-2").classList.toggle("active3");
    document.querySelector(".choose_p1").classList.toggle("choose-mod");
    document.querySelector(".btn1-1").classList.remove("active3");
    document.querySelector(".choose_p").classList.remove("choose-mod");
    
  }
  
  function btn2_1(){
    document.querySelector(".btn2-1").classList.toggle("active3");
    document.querySelector(".btn2-2").classList.remove("active3");
    document.querySelector(".btn2-3").classList.remove("active3");
    document.querySelector(".btn2-4").classList.remove("active3");
    document.querySelector(".choose_p2").classList.toggle("choose-mod");
    document.querySelector(".choose_p3").classList.remove("choose-mod");
    document.querySelector(".choose_p4").classList.remove("choose-mod");
    document.querySelector(".choose_p5").classList.remove("choose-mod");



    
  }
  function btn2_2(){
    document.querySelector(".btn2-2").classList.toggle("active3");
    document.querySelector(".btn2-1").classList.remove("active3");
    document.querySelector(".btn2-3").classList.remove("active3");
    document.querySelector(".btn2-4").classList.remove("active3");
    document.querySelector(".choose_p3").classList.toggle("choose-mod");
    document.querySelector(".choose_p2").classList.remove("choose-mod");
    document.querySelector(".choose_p4").classList.remove("choose-mod");
    document.querySelector(".choose_p5").classList.remove("choose-mod");
    
  }
  function btn2_3(){
    document.querySelector(".btn2-3").classList.toggle("active3");
    document.querySelector(".btn2-2").classList.remove("active3");
    document.querySelector(".btn2-1").classList.remove("active3");
    document.querySelector(".btn2-4").classList.remove("active3");
    document.querySelector(".choose_p4").classList.toggle("choose-mod");
    document.querySelector(".choose_p3").classList.remove("choose-mod");
    document.querySelector(".choose_p2").classList.remove("choose-mod");
    document.querySelector(".choose_p5").classList.remove("choose-mod");

    
  }
  
  function btn2_4(){
    document.querySelector(".btn2-4").classList.toggle("active3");
    document.querySelector(".btn2-1").classList.remove("active3");
    document.querySelector(".btn2-3").classList.remove("active3");
    document.querySelector(".btn2-2").classList.remove("active3");
    document.querySelector(".choose_p5").classList.toggle("choose-mod");
    document.querySelector(".choose_p3").classList.remove("choose-mod");
    document.querySelector(".choose_p4").classList.remove("choose-mod");
    document.querySelector(".choose_p2").classList.remove("choose-mod");

    
  }
  function seemore(){
    document.querySelector(".item-see").classList.toggle("show");
    document.querySelector(".item-see2").classList.toggle("show");
    document.querySelector(".item-see1").classList.toggle("show");
    document.querySelector(".item-see3").classList.toggle("show");
    document.querySelector(".item-see4").classList.toggle("show");
    document.querySelector(".main-sp-2-left-content").classList.toggle("width");
    document.querySelector(".see-more-btn").classList.toggle("show2");
   
    

    
  }
  
  
  function openCity(cityName,elmnt,color) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].style.backgroundColor = "";
      tablinks[i].style.color = "";
    }
    document.getElementById(cityName).style.display = "block";
    elmnt.style.backgroundColor = color;
    elmnt.style.color = "#fff";
  
  }
  // Get the element with id="defaultOpen" and click on it
  document.getElementById("defaultOpen").click();



  let dj=document.getElementById("scroll");
window.addEventListener('scroll',function(){
  var value=window.scrollY;
  var value2=window.innerWidth;
 if(value>=600 && value2<=650){
   dj.style.display="flex";
 } else{
  dj.style.display="none";
 }
})


$(function() {
  $(".main-sp-content3-text").owlCarousel({
          items:5,
          slideBy: 2,
          responsive: {
              1200: {
                  item: 6,
              }, // breakpoint from 1200 up
              982: {
                  items: 5,
              },
              768: {
                  items: 4,
              },
              480: {
                  items: 2,
                  slideBy: 2,
              },
              0: {
                  items: 2,
              }
          },
          rewind: false,
          autoplay: false,
          autoplayTimeout: 5000,
          autoplayHoverPause: true,
          smartSpeed: 500,
          dots: true,
          loop: false,
          nav: false,
          autoWidth: false,
          margin: 15,
          lazyLoad: false,
          nav: true,
          navText: ["<img src='img/left.png'>", "<img src='img/right.png'>"],
          transitionStyle: "backSlide",
          animateOut: 'fadeOut', // default: false
          animateIn: 'fadeIn', // default: false
      });

      $(".main-sp-content3-text-media").owlCarousel({
          items:5,
          slideBy: 2,
          responsive: {
              1200: {
                  item: 6,
              }, // breakpoint from 1200 up
              982: {
                  items: 5,
              },
              768: {
                  items: 4,
              },
              480: {
                  items: 2,
                  slideBy: 2,
              },
              0: {
                  items: 2,
              }
          },
          rewind: false,
          autoplay: false,
          autoplayTimeout: 5000,
          autoplayHoverPause: true,
          smartSpeed: 500,
          dots: true,
          loop: false,
          nav: false,
          autoWidth: false,
          margin: 15,
          lazyLoad: false,
          nav: true,
          navText: ["<img src='img/left.png'>", "<img src='img/right.png'>"],
          transitionStyle: "backSlide",
          animateOut: 'fadeOut', // default: false
          animateIn: 'fadeIn', // default: false
      });

})

function opennav1() {
  document.getElementById("dropdown-left-content").style.width = "300px";
  document.getElementById("lopphu").style.width = "100%";
  }
  
  function closenav1() {
  document.getElementById("dropdown-left-content").style.width = "0";
  document.getElementById("lopphu").style.width = "0";
  }
  function footer_btn(){
    document.querySelector(".footer-content-all").classList.toggle("show");
    let y=document.querySelector(".footer-content-all")
    let x = document.getElementById("footer-text");
    if(!y){
        x.innerHTML="ẨN BỚT"
    }
    else{
        x.innerHTML="MỞ RỘNG CHÂN TRANG ^ "
    }
    document.querySelector(".end").classList.toggle("end-top");
  }