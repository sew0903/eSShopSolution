function hammore() {
    document.querySelector(".noidung-nutmore").classList.toggle("show");
   }
   
   window.onclick = function(e) {
     if (!e.target.matches('.nut-more')) {
     var noiDungDropdown = document.querySelector(".noidung-nutmore");
       if (noiDungDropdown.classList.contains('show')) {
         noiDungDropdown.classList.remove('show');
       }
     }
   }