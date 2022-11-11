var tetAmLich = new Date("Aug 19, 2021 0:0:0").getTime();
 
 function newYear() {
    
     var ngayHienTai = new Date().getTime();

     
     thoigianConLai = tetAmLich - ngayHienTai;

    
     var giay = 1000;
     var phut = giay * 60;
     var gio = phut * 60;
     var ngay = gio * 24;


     var d = Math.floor(thoigianConLai / (ngay));
     var h = Math.floor((thoigianConLai % (ngay)) / (gio));
     var m = Math.floor((thoigianConLai % (gio)) / (phut));
     var s = Math.floor((thoigianConLai % (phut)) / (giay));


     document.getElementById("day").innerText = d;
     document.getElementById("hour").innerText = h;
     document.getElementById("minute").innerText = m;
     document.getElementById("second").innerText = s;
 }


 setInterval(function () {
     newYear()
 }, 1000)



Resources