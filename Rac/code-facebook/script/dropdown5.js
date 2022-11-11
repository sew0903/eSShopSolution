function hamadmin() {
    document.querySelector(".noidung-admin").classList.toggle("show");
   }
   
   window.onclick = function(e) {
     if (!e.target.matches('.nut-admin')) {
     var noiDungDropdown4 = document.querySelector(".noidung-admin");
       if (noiDungDropdown4.classList.contains('show')) {
         noiDungDropdown4.classList.remove('show');
       }
     }
   }