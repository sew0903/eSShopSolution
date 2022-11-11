
        var slideIndex = 1;
        showSlides(slideIndex);
        
        function plusSlides(n) {
          showSlides(slideIndex += n);
        }
        
        function currentSlide(n) {
          showSlides(slideIndex = n);
        }
        
        function showSlides(n) {
          var i;
          var slides = document.getElementsByClassName("mySlides");
          var dots = document.getElementsByClassName("demo");
          var captionText = document.getElementById("caption");
          if (n > slides.length) {slideIndex = 1}
          if (n < 1) {slideIndex = slides.length}
          for (i = 0; i < slides.length; i++) {
              slides[i].style.display = "none";
          }
          for (i = 0; i < dots.length; i++) {
              dots[i].className = dots[i].className.replace(" active1", "");
          }
          slides[slideIndex-1].style.display = "block";
          dots[slideIndex-1].className += " active1";
          captionText.innerHTML = dots[slideIndex-1].alt;
        }
function fun1(){
    document.getElementById("black-color").style.border="2px solid red";
    document.getElementById("red-color").style.border="2px solid #fff";
}
function fun2(){
    document.getElementById("red-color").style.border="2px solid red";
    document.getElementById("black-color").style.border="2px solid #fff";
}

function openNav() {
  document.getElementById("mySidenav2").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav2").style.width = "0";
}
function show(){
  document.querySelector(".an-content").classList.toggle("show");
  
}
function show2(){
  document.querySelector(".show2-content").classList.toggle("show");
  
}
function show3(){
  document.querySelector(".show2-content3").classList.toggle("show");
  
}
function show4(){
  document.querySelector(".show2-content4").classList.toggle("show");
  
}
function show5(){
  document.querySelector(".show2-content5").classList.toggle("show");
  
}
function show6(){
  document.querySelector(".show2-content6").classList.toggle("show");
  
}
function show7(){
  document.querySelector(".show2-content7").classList.toggle("show");
  
}
