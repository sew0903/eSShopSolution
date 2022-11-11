const btn_microphone = document.querySelector('.fa-microphone')
const btn_mic = document.querySelector('.mix-content-box')
const btn_x = document.querySelector('.fa-times')
const modal_microphone = document.querySelector('.modal-microphone')
const mic_sub = document.querySelector('.mic-sub')

var modal = document.getElementById('id01');


window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
 function audio_mic(){
        let mic_title = document.querySelector('.mic-content-title')
        let mic_noti = document.querySelector('.mic-noti')
        mic_noti.style.display = 'none'
        btn_mic.classList.toggle('mic-active');
        setTimeout(() => {
            btn_mic.classList.remove('mic-active');
            mic_noti.style.display = 'block'
            mic_title.innerHTML = 'Tôi chưa nghe rõ. Mời bạn nói lại.'
        }, 5000);
    }
    
    btn_mic.addEventListener('click', function(){
        let mic_title = document.querySelector('.mic-content-title')
        let mic_noti = document.querySelector('.mic-noti')
        mic_noti.style.display = 'none'
        btn_mic.classList.toggle('mic-active');
        mic_title.innerHTML ='Đang nghe...'
        setTimeout(() => {
            btn_mic.classList.remove('mic-active');
            mic_noti.style.display = 'block'
            mic_title.innerHTML = 'Tôi chưa nghe rõ. Mời bạn nói lại.'
        }, 5000);
    });
    
    
    btn_microphone.addEventListener('click', function(){
        modal_microphone.classList.toggle('active');
        // btn_mic.classList.add('mic-active');
       
    });
    
    btn_x.addEventListener('click', function(){
        modal_microphone.classList.toggle('active');
    })
    mic_sub.addEventListener('click', function(){
        modal_microphone.classList.remove('active');
    })

    // const btn_sidebar1 = document.querySelector('.btn-sidebar1')
    // const btn_sidebar2 = document.querySelector('.btn-sidebar2')
    // const sidebar = document.querySelector('.sidebar')
    // const sidebar_sub = document.querySelector('.sidebar-sub')
    
    // btn_sidebar1.addEventListener('click', function(){
    //     sidebar.classList.toggle('sidebar-active');
    //     sidebar_sub.classList.add('active')
        
    // });
    // btn_sidebar2.addEventListener('click', function(){
    //     sidebar.classList.toggle('sidebar-active');
    //     sidebar_sub.classList.remove('active')
    // });
    // sidebar_sub.addEventListener('click', function(){
    //     sidebar_sub.classList.remove('active')
    //     sidebar.classList.remove('sidebar-active');
    // })
    

    const btn_add = document.querySelector('.btn-add');
    const btn_add_hai = document.querySelector('.btn-add-hai');
    
    btn_add.addEventListener('mouseover', function(){
        let btn_more_down = document.querySelector('.btn_more_down')
        let sidebar_more = document.querySelector('.sidebar-center-list-more')
        let sidebar_more_title = document.querySelector('.sidebar_more_title')
        let sidebar_more2 = document.querySelector('.sidebar-center-list-more.add_more')
        sidebar_more.classList.toggle('add_more');
        btn_more_down.classList.toggle('btn_more_up')
          
        if(!sidebar_more2){
            sidebar_more_title.innerHTML = 'Ẩn bớt'
        } else {
            sidebar_more_title.innerHTML = 'Hiển thị thêm'
        }
    })
    btn_add_hai.addEventListener('click', function(){
        let btn_more_down = document.querySelector('.btn_more_down2')
        let sidebar_more = document.querySelector('.sidebar-center2-list-more')
        let sidebar_more_title = document.querySelector('.sidebar_more_title2')
        let abc_xyz = document.querySelector('.sidebar-top-list.sidebar-center2-list-more.add_more')
        sidebar_more.classList.toggle('add_more');
        btn_more_down.classList.toggle('btn_more_up')
        
        if(!abc_xyz){
            sidebar_more_title.innerHTML = 'Ẩn bớt'
        } else {
            sidebar_more_title.innerHTML = 'Hiển thị thêm'
        }
    })

    function openNav() {
        document.getElementById("mySidenav").style.display= "block";
        document.getElementById("mySidenav").style.transform= "translateX(0%)";

       
       document.getElementById("s-sub").style.display="block";
      }
      
      function closeNav() {
        document.getElementById("mySidenav").style.display = "none";
      
        document.getElementById("s-sub").style.display="none";
         
      }
      var subnav=document.getElementById("mySidenav")
      window.onclick = function(event) {
        if (event.target == subnav) {
            subnav.style.display = "none";
        }
    }
    

    function Video_dropdown_Function() {
        document.getElementById("VideoDropdown").classList.toggle("active");
      }
      

      window.onclick = function(event) {
        if (!event.target.matches('.video-dropdown-btn')) {
          var dropdowns = document.getElementsByClassName("video-dropdown-list");
          var i;
          for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('active')) {
              openDropdown.classList.remove('active');
            }
          }
        }
      }

      function Menu_dropdown_Function() {
        document.getElementById("MenuDropdown").classList.toggle("active");
      }
      

      window.onclick = function(event) {
        if (!event.target.matches('.menu-drowdown-btn')) {
          var dropdowns2 = document.getElementsByClassName("menu-dropdown-list");
          var b;
          for (b = 0; b < dropdowns2.length; b++) {
            var openDropdown2 = dropdowns2[b];
            if (openDropdown2.classList.contains('active')) {
              openDropdown2.classList.remove('active');
            }
          }
        }
      }

      function Bell_dropdown_Function() {
        document.getElementById("BellDropdown").classList.toggle("active");
      }
      function User_dropdown_btn() {
        document.getElementById("Image_dropdown").classList.toggle("active");
      }