function resumeBtn() {
    $.ajax({
        url: "/resume",
        type: "Get",
        data: {}
    }).done(function (result) {
        $('#renderbodydiv').empty();
        $('#renderbodydiv').html(result);
        $('.nav__item a').removeClass('active');
        $('#resumeItem a').addClass('active');
        initializeBootstrapProgressBars();
        history.replaceState(null, null, '/resume');
    });
}
//inam ye rahe dgashe baraye taqire rang
//$(document).on('click', '#resumeItem a', function () {
//    $('.nav__item a').removeClass('active');
//    $(this).addClass('active');
//});
// تابع برای افکت نوار دهی در حالت ایجکس
function initializeBootstrapProgressBars() {
    // مقداردهی برای Bootstrap یا دیگر کتابخانه‌ها
    $('.progress-bar').css('width', function () {
        return $(this).attr('aria-valuenow') + '%';
    });
}
function worksBtn() {
    $.ajax({
        url: "/Works",
        type: "Get",
        data: {}
    }).done(function (result) {
        $('#renderbodydiv').empty();
        $('#renderbodydiv').html(result);
        $('.nav__item a').removeClass('active');
        $('#worksItem a').addClass('active');
        history.replaceState(null, null, '/Works');
    });
}
function contactPost() {
    var input = $('#contactForm').serialize();
    $.ajax({
        url: "/contact-us",
        type: "Post",
        data: input,
    }).done(function (result) {
        if (result.success) {
            $('#renderbodydiv').empty();
            $('#renderbodydiv').html(result.view);
            alert('پیام ثبت شد نتیجه با ایمیل پاسخ داده میشود');
            $('#contactForm').find('input, textarea').val('');
        }
        else {
            $('#renderbodydiv').empty();
            $('#renderbodydiv').html(result.view);
        }
    });
}
