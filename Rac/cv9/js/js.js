function myFunction(x) {
    x.classList.toggle("change");
    
  }

  function opennav(){
      document.querySelector(".media-menu-drop").classList.toggle("show");
  }
  function show1(){
      document.querySelector(".content1-right-content-item").classList.toggle("show");
      document.querySelector(".content-docnhieu").classList.remove("show");
      document.querySelector(".tinmoi").classList.toggle("onnow");
      document.querySelector(".docnhieu").classList.remove("onnow");
     
      


  }
  function show2(){
    document.querySelector(".content-docnhieu").classList.toggle("show");
    document.querySelector(".content1-right-content-item").classList.remove("show");
    document.querySelector(".docnhieu").classList.toggle("onnow");
    document.querySelector(".tinmoi").classList.remove("onnow");
   

}