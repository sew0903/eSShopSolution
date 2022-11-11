const PlatList = "PLff9zSdyUhbUugZO-s0cpDQFJZPWa6YB7"
const APIURL =
    `https://www.googleapis.com/youtube/v3/playlistItems?part=snippet,contentDetails&maxResults=20&playlistId=${PlatList}&key=AIzaSyC3x0nIWqBt0f6mPKkf2-YT-BZhynqnTBA`


const main = document.querySelector('.video_list')


// initially get fav movies
getMovies(APIURL);
async function getMovies(url) {
    const resp = await fetch(url);
    const respData = await resp.json();
    console.log(respData)
    Promise
    .then(
        showMovies(respData.items),
        showMovie(respData.items),
        showHinh(respData.items),
        app()
    )
}
function showHinh(movies){
    const hinh = document.querySelectorAll('.video_item-photo')
     
    hinh.forEach((item, index) =>{
        item.innerHTML =
         `
            <img src="${movies[index].snippet.thumbnails.medium.url}" alt="hinh">
        `
    })
}

function showMovies(movies) {
    // clear main
    main.innerHTML = "";
    movies.forEach((movie, index) => {
        // const { snippet, title, vote_average, overview } = movie;
        const movieEl = document.createElement("div");
        movieEl.classList.add("movie");
        const today = new Date()
        const up = new Date(movie.snippet.publishedAt)
        const mons = Math.floor((today - up) / (1000*60*60*24*30))
        let mon;
        let view = Math.floor(Math.random() * 1000)+100;
        mon=1 + ' tháng trước';
            movieEl.innerHTML = `
            <li class="video_item">
                <ul class="video_item-photo">
                <img src="./Image/img1.jpg" alt="hinh"></ul>
                <ul class="video_item-info">
                    <li>
                        <a  class="video_item-info-title">${movie.snippet.title}</a>
                    </li>
                    <li>
                        <span class="video_item-info-channel">${movie.snippet.channelTitle} </span>
                    </li>
                    <li>
                        <span class="video_item-info-viewer"><span>${view} N lượt xem <i class="fas fa-circle"></i> ${mon} </span></span>
                    </li>
                    <li><p class='video_item-info-tag' >Mới</p></li>
                </ul>
            </li>
            `;
        main.appendChild(movieEl);
    });
}


const video_main = document.querySelector('.content-left')

function showMovie(videos) {

    const title_video = document.querySelectorAll('.video_item')
    // const index = 1;
        title_video.forEach((element, index) => {
           element.addEventListener('click', function(){
            const dayP = videos[index].snippet.publishedAt
            const year = dayP.slice(0,4)
            const mon = dayP.slice(5,7)
            const day = dayP.slice(8,10)
            const today = new Date()
            const up = new Date(videos[index].snippet.publishedAt)
            let view1 = Math.floor(( today - up) / 100000000) 
            let view2 = view1 + 69
            let like = Math.floor(view1/10)
            let dislike = Math.floor(view1/9) + 351
            video_main.innerHTML =  `
            <div class="content-video">
                        <iframe width="100%" height="720" src="https://www.youtube.com/embed/${videos[index].snippet.resourceId.videoId}?autoplay=1" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                    <div class="content-title">
                        <h3 class="content-heading">${videos[index].snippet.title}</h3>
                        <div class="content-info">
                            <div class="content-info-view">
                                <span class="content-info-viewer">${view1}.${view2}</span>
                                <i class="fas fa-circle"></i>
                                <span class="content-info-day">${day} thg ${mon}, ${year}</span>
                            </div>
                            <div class="content-info-social">
                                <ul class="content-info-social-list">
                                    <li class="content-info-social-list-item like1">
                                        <i class="fas fa-thumbs-up" ></i>
                                        <a>${like}</a>
                                        <div class="like-li_item"></div>
                                    </li>
                                    <li class="content-info-social-list-item dislike1">
                                        <i class="fas fa-thumbs-down"></i>
                                        <a>${dislike}</a>
                                    </li>
                                    <li class="content-info-social-list-item">
                                        <i class="fas fa-share" onclick="open_share()"></i>
                                        <a>Chia sẻ</a>
                                        <div class="content-share-box" id="share-content">
                                            <div class="content-share-box-content-shadow">
                                                <ul class="content-share-box-content">
                                                    <div class="content-share-box-content-header">
                                                        <p>chia sẻ</p>
                                                        <div class="content-share-box-content-header-icon"><i class="fas fa-times" onclick="close_share()"></i></div>
                                                        
                                                    </div>
                                                    <ul class="content-share-box-content-main">
                                                        <li class="content-share-box-content-main-item code-icon">
                                                            <i class="fas fa-code code-icon-item"></i>
                                                            <p>Nhúng</p>
                                                        </li>
                                                        <li class="content-share-box-content-main-item facebook-icon">
                                                            <i class="fab fa-facebook-f facebook-icon-item"></i>
                                                            <p>Facebook</p>
                                                        </li>
                                                        <li class="content-share-box-content-main-item Whatapp-icon">
                                                            <i class="fab fa-whatsapp Whatapp-icon-item"></i>
                                                            <p>Whatsapp</p>
                                                        </li>
                                                        <li class="content-share-box-content-main-item twitter-icon">
                                                            <i class="fab fa-twitter twitter-icon-item"></i>
                                                            <p>Twitter</p>
                                                        </li>
                                                        <li class="content-share-box-content-main-item email-icon">
                                                            <i class="far fa-envelope email-icon-item"></i>
                                                            <p>Email</p>
                                                        </li>
                                                        <li class="content-share-box-content-main-item github-icon">
                                                            <i class="fab fa-github github-icon-item"></i>
                                                            <p>GitHub</p>
                                                        </li>
                                                    </ul>
                                                    <div class="content-share-box-content-main2">
                                                        <p>https://youtu.be/${videos[index].snippet.resourceId.videoId}</p>
                                                        <h1>Sao chép</h1>
                                                    </div>
                                                    <div class="content-share-box-content-footer">
                                                        <input type="checkbox">
                                                        <p>Bắt đầu tại</p>
                                                    </div>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                    <li class="content-info-social-list-item" >
                                        <i class="fas fa-download" onclick="open_save()"></i>
                                        <a>Lưu</a>
                                        <div class="save-content" id="save_content">
                                            <ul class="save-content-box">
                                                <li class="save-content-box-header">
                                                    <p>Lưu vào . . .</p>
                                                    <i class="fas fa-times" onclick="close_save()"></i>
                                                </li>
                                                <ul class="save-content-box-center">
                                                <li class="save-content-box-item">
                                                    <input type="checkbox">
                                                    <p>Xem sau</p>
                                                    <i class="fas fa-lock"></i>
              
                                                </li>
                                                <li class="save-content-box-item">
                                                    <input type="checkbox">
                                                    <p>Code with Quân</p>
                                                    <i class="fas fa-globe-asia"></i>
              
                                                </li>
                                            </ul>
                                            <ul class="save-content-box-footer">
                                               <p>Tạo danh sách mới</p>  <i class="fas fa-plus"></i>
                                               
                                            </ul>
                                            </ul>

                                        </div>
                                    </li>
                                    <li class="content-info-social-list-item">
                                        <i class="fas fa-ellipsis-h" onclick="open_more()"></i>
                                        <div class="more_content" id="more_content">
                                            <ul class="more-content-box">
                                            <li class="more_content-item">
                                                <i class="fas fa-flag"></i>
                                                <p>Báo cáo vi phạm</p>
                                            </li>
                                            <i class="fas fa-times more-content-icon-x" onclick="close_more()"></i>
                                        </ul></div>
                                       
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                     
                    </div>
                    <div class="content_info">
                        <ul class="content_info-channel">
                            <li class="content_info-channel-list">
                                <img src="image/admin-avatar.png" alt="" class="content_info-channel-list-user" >
                            </li>
                            <li class="content_info-channel-list2">
                                <h2>Code with Quan</h2>
                                <p>3 Tr người đăng kí</p>
                            </li>
                        </ul>
                        <div class="btn-channel-box">
                            <button class="btn-channel btn-channel-active">ĐĂNG KÍ</button>
                            <div class="icon-bell">
                                <i class='fas fa-bell' ></i>
                            </div>
                        </div>
                        
                    </div>
                    <div class="content-info2">
                        <div class="content-desc">
                            <p class="content-desc-text">[抖音] Trào lưu Slow Motion "Counting Stars" (Violin Ver.) || Nhạc Hot Tik Tok Trung Quốc | Douyin Music
                            </p>
                            <p class="content-desc-text tag_link ">#edm #codewithQuan #nocopyright</p>
                            <p class="content-desc-text">Mail: qquannguyentrong123@gmail.com</p>
                            <p class="content-desc-text">${videos[index].snippet.description}
                            <br>
                            <br>
                            © If you have any questions, complaints about the copyright of the image or music included in the video, please contact the owner directly at G-mail: le2971997@gmail.com or Facebook: https : //www.facebook.com/LiKiller .Thanks! We will delete immediately after receiving the notification!</p>
                            <br>
                            <p class="content-desc-text">--------------------------------------------</p>
                            <p class="content-desc-text">Facebook cá nhân: <a href="https://www.facebook.com/quan.nguyentrong.35325/" class="tag_link">https://www.facebook.com/quan.nguyentrong.35325/</a></p>
                            <p class="content-desc-text">Github: <a  href="https://github.com/quandarius-pfp"class="tag_link">https://github.com/quandarius-pfp</a></p>
                            <p class="content-desc-text">--------------------------------------------</p>
                            <p class="content-desc-text">If you have a copyright issue feel free to message me on twitter and we can get it resolved: qquannguyentrong123@gmail.com</p>
                            <br>

                            <div class="content-desc-copyright">
                                <p class="content-copyright-title">Nhạc trong video này</p>
                                <p class="content-copyright-title">Tìm hiểu thêm</p>
                                <p class="content-copyright-content">
                                    <span>Bài hát</span>
                                    <a class="content-copyright-text">Code /  Noob coder</a>
                                </a>
                                <p class="content-copyright-content">
                                    <span>Coder</span>
                                    <a class="content-copyright-text">Code with Quan</a>
                                </a>
                                <p class="content-copyright-content">
                                    <span>Bên cấp phép cho YouTube</span>
                                    <a class="content-copyright-text">Code With Quân</a>
                                </a>
                            </div>
                        </div>
                        <p class="content-desc-more ">HIỂN THỊ THÊM</p>
                    </div>
                    <div class="content-comments">
                        <div class="comments-header">
                            <a class="comments-header_num">291 bình luận</a>
                            <span class="comments-header_sort"><i class='bx bx-menu-alt-left'></i>SẮP XẾP THEO </span>
                        </div>
                        <div class="comments-user">
                            <img src="./image/admin-avatar.png" alt="" class="comments-user-avt">
                            <div class="comments-user-input">
                                <input type="text" placeholder="Bình luận công khai...">
                                <div class="comments-user-btn">
                                    <button class="comments_btn-cancel color_main">HỦY</button>
                                    <button class="comments_btn-cmt">BÌNH LUẬN</button>
                                </div>
                            </div>
                        </div>
                        <div class="comments-user comments-user_rep">
                            <img src="./image/hinh-nen-anime-dep-min.jpg" alt="" class="comments-user-avt comments-user-avt2">
                            <div class="comments-user-input">
                                <a href="#" class="comments-name">That Code inline</a><span class="comments-time">1 tháng trước</span>
                                <div class="comments-user_text">
                                    <p class="comments-user_text_text2">
                                        tự nghĩ ra những kỷ niệm, những ký ức bên người cô gái.
                                    </p>
                                    <i class=' comments-user_text_icon  bx bx-dots-vertical-rounded'></i>
                                    
                                </div>
                                <ul class="comments-action">
                                    <li class="comments-action-item  ">
                                        <i class="fas fa-thumbs-up"></i>
                                    </li>
                                    <li class="comments-action-item">
                                        <p class="like_number" >130</p>
                                    </li>
                                    <li class="comments-action-item">
                                        <i class="fas fa-thumbs-down"></i>
                                    </li>
                                    <li class="comments-action-item">
                                        <p class="dislike_number">1</p>
                                    </li>
                                    <li class="comments-action-item comments-action-item2">
                                        <p class="comments_rep comments_rep_fix">PHẢN HỒI</p>
                                    </li>
                                </ul>
                                <div class="comments_rep_box comments_rep_box-fix">
                                    <div class="comments-user comments-user_rep">
                                        <img src="./Image/user.jpg" alt="" class="comments-user-avt comments-user-avt3">
                                        <div class="comments-user-input comments-user-input2">
                                            <input type="text" placeholder="Phản hồi công khai...">
                                            <div class="comments-user-btn">
                                                <button class="comments_btn-cancel color_main comments_rep_box_cancel">HỦY</button>
                                                <button class="comments_btn-cmt comments_rep">PHẢN HỒI</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <a class="comments_btn_more tag_link"><i class="fas fa-caret-down"></i></i>Xem 3 câu trả lời</a>
                                <div class="comments_box-list">
                                    <div class="comments-user comments-user_rep2">
                                        <img src="./Image/channels4_profile.jpg" alt="" class="comments-user-avt comments-user-avt3">
                                        <div class="comments-user-input">
                                            <a href="#" class="comments-name">F8 Official</a><span class="comments-time">1 tháng trước</span>
                                            <div class="comments-user_text">
                                                <p class="comments-user_text_text2">
                                                    Yêu đường gì tầm này quay kênh tôi học code đi 
                                                </p>
                                                <i class=' comments-user_text_icon  bx bx-dots-vertical-rounded'></i>
                                                <div class="comments-report">
                                                    <li>
                                                        <i class='bx bxs-flag-alt' ></i>
                                                        <p>Báo cáo</p>
                                                    </li>
                                                </div>
                                            </div>
                                            <ul class="comments-action">
                                                <li class="comments-action-item">
                                                    <i class='bx bxs-like ' ></i>
                                                </li>
                                                <li class="comments-action-item">
                                                    <p class="like_number" >34</p>
                                                </li>
                                                <li class="comments-action-item">
                                                    <i class='bx bxs-dislike'></i>
                                                </li>
                                                <li class="comments-action-item">
                                                    <p class="dislike_number"></p>
                                                </li>
                                                <li class="comments-action-item comments-action-item2">
                                                    <p class="comments_rep">PHẢN HỒI</p>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="comments-user comments-user_rep2">
                                        <img src="./Image/channels4_profile2.jpg" alt="" class="comments-user-avt comments-user-avt3">
                                        <div class="comments-user-input">
                                            <a href="#" class="comments-name">Next Sport</a><span class="comments-time">1 tuần trước</span>
                                            <div class="comments-user_text">
                                                <p class="comments-user_text_text2">
                                                    Đôi khi cô đơn giết anh từng cơn , em hỡi !
                                                </p>
                                                <i class=' comments-user_text_icon  bx bx-dots-vertical-rounded'></i>
                                                <div class="comments-report">
                                                    <li>
                                                        <i class='bx bxs-flag-alt' ></i>
                                                        <p>Báo cáo</p>
                                                    </li>
                                                </div>
                                            </div>
                                            <ul class="comments-action">
                                                <li class="comments-action-item">
                                                    <i class='bx bxs-like ' ></i>
                                                </li>
                                                <li class="comments-action-item">
                                                    <p class="like_number" >2</p>
                                                </li>
                                                <li class="comments-action-item">
                                                    <i class='bx bxs-dislike'></i>
                                                </li>
                                                <li class="comments-action-item">
                                                    <p class="dislike_number">1</p>
                                                </li>
                                                <li class="comments-action-item comments-action-item2">
                                                    <p class="comments_rep">PHẢN HỒI</p>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="comments-user comments-user_rep2">
                                        <img src="./Image/user.jpg" alt="" class="comments-user-avt comments-user-avt3">
                                        <div class="comments-user-input">
                                            <a href="#" class="comments-name">Tu Sieu Nhan</a><span class="comments-time">4 tháng trước</span>
                                            <div class="comments-user_text">
                                                <p class="comments-user_text_text2">
                                                    Ai vừa nghe vừa đọc bình luận điểm danh ❤️❤️
                                                </p>
                                                <i class=' comments-user_text_icon  bx bx-dots-vertical-rounded'></i>
                                                <div class="comments-report">
                                                    <li>
                                                        <i class='bx bxs-flag-alt' ></i>
                                                        <p>Báo cáo</p>
                                                    </li>
                                                </div>
                                            </div>
                                            <ul class="comments-action">
                                                <li class="comments-action-item">
                                                    <i class='bx bxs-like ' ></i>
                                                </li>
                                                <li class="comments-action-item">
                                                    <p class="like_number" >100</p>
                                                </li>
                                                <li class="comments-action-item">
                                                    <i class='bx bxs-dislike'></i>
                                                </li>
                                                <li class="comments-action-item">
                                                    <p class="dislike_number">1</p>
                                                </li>
                                                <li class="comments-action-item comments-action-item2">
                                                    <p class="comments_rep">PHẢN HỒI</p>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
            
            `;
            if (index != null){
                app();
            }
            })
            
        });
}

function app(){



    
    // input header
    
    // const inputSearch = document.querySelector('input')
    // const inputList = document.querySelector('.input-dropdowm-list')
    // const input_dropdowm = document.querySelector('.input-dropdowm')
    
    // inputSearch.onkeyup = (e) => {
    //     let user_data = e.target.value;
    //     let array = [];
    //     if (user_data){
    //         array = listS.filter((data)=> {
    //             return data.toLocaleLowerCase().startsWith(user_data.toLocaleLowerCase());
    //         });
    //         array = array.map((data)=> {
    //             return data = 
    //             `<li class="input-dropdowm-item">
    //                 <a class="input-dropdowm-item_heading" href="#">${data}</a>
    //             </li>`
    //         })
    //     }else{
    //         inputList.innerHTML = `${data}`
    //     }
    //     showHistory(array)
    // }
    
    
    // function showHistory(list){
    //     let list_data;
    //     if(!list.length){
    //         userValue = inputSearch.value;
    //         list_data = 
    //         `<li class="input-dropdowm-item">
    //             <a class="input-dropdowm-item_heading" href="#">${userValue}</a>
    //         </li>`
    //     } else{
    //         list_data = list.join('');
    //     }
    //     inputList.innerHTML = list_data;
    // }
    
    // sidebar 
  
    
    setInterval(() => {
        reponsiveYT()
    }, 1000);
    
    function reponsiveYT(){
        const heightListVideo =  document.querySelector('.video_list').offsetHeight
        const content_comments = document.querySelector('.content-comments')
        const content = document.querySelector('.content').offsetWidth
        if(content <= 1000){
            content_comments.style.marginTop = heightListVideo + 'px'
        } else {
            content_comments.style.marginTop = ''
        }
    
    }
    
    
}

