// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code
(() => {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
    })
})()
const carousel = new bootstrap.Carousel('#myCarousel')

//$(document).ready(function () {



//    // При клике на миниатюру

//    $('.in img').click(function () {

//        // Берем свойство SRC миниатюры

//        // (можно картинку положить в ссылку и брать значение href

//        // для того, чтобы не грузить большие картинки изначально

//        // а загружать сначало миниатюры и только при клике открывать

//        // большое изображение, что будет целесообразнее).

//        var imgSrc = $(this).attr("src");

//        // Задаем свойство SRC картинке, которая в скрытом диве.

//        $('#img_container img').attr({ src: imgSrc });

//        // Показываем скрытый контейнер

//        $('#img_container').fadeIn('slow');

//    });

//    // По клику на большое изображение, скрываем его
//    $('#img_container').click(function () {
//        $(this).fadeOut();
//    });
//});