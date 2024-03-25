// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    var dropdown = document.querySelector(".dropdown");
    var dropdownContent = document.querySelector(".dropdown-content");

    dropdown.addEventListener("click", function () {
        dropdownContent.style.display = dropdownContent.style.display === "block" ? "none" : "block";
    });
});


document.querySelectorAll('.close-alert').forEach(function(btn) {
    btn.addEventListener('click', function () {       
        this.closest('.alert').remove();
    });
});

var mensagens = document.querySelectorAll('.alert');

mensagens.forEach(function (mensagem) {
    setTimeout(function () {
        mensagem.remove();
    }, 8000);
});

