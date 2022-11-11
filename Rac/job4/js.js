function openCity(cityName,elmnt,color) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].style.color = "";
      tablinks[i].style.borderRight="";
      tablinks[i].style.borderLeft="";
      tablinks[i].style.borderTop="";
      tablinks[i].style.borderBottom="";
      tablinks[i].style.zIndex="";
    }
    document.getElementById(cityName).style.display = "block";
    elmnt.style.color = color;
    elmnt.style.borderRight="1px solid #ccc";
    elmnt.style.borderLeft="1px solid #ccc";
    elmnt.style.borderTop="1px solid #ccc";
    elmnt.style.borderBottom="1px solid #fff";
    elmnt.style.zIndex="2";
  
  }
  // Get the element with id="defaultOpen" and click on it
  document.getElementById("defaultOpen").click();