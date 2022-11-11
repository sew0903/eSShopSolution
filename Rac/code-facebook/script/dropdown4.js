function hamlist() {
    document.querySelector(".noidung-nutlist").classList.toggle("show");
   }
   
   window.onclick = function(e) {
     if (!e.target.matches('.nut-list')) {
     var noiDungDropdown2 = document.querySelector(".noidung-nutlist");
       if (noiDungDropdown.classList.contains('show')) {
         noiDungDropdown.classList.remove('show');
       }
     }
   }