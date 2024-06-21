
//burger menu
document.addEventListener('DOMContentLoaded', function () {
    const burgerButton = document.querySelector('.burger');
    const menu = document.querySelector('.burger__menu');

    function toggleMenu() {
        if (menu.style.display === 'block') {
            menu.style.display = 'none';
        } else {
            menu.style.display = 'block';
        }
    }

    burgerButton.addEventListener('click', function (event) { 
        event.stopPropagation();
        toggleMenu();
    });

    document.addEventListener('click', function (event) {        
        if (!menu.contains(event.target) && menu.style.display === 'block') {
            menu.style.display = 'none';
        }
    });

    document.addEventListener('scroll', function () {
        if (menu.style.display === 'block') {
            menu.style.display = 'none';
        }
    });
});






//Password Message for User
document.addEventListener("DOMContentLoaded", function () {
    const btn = document.querySelector('.registration-btn');

    if (btn) {
        btn.addEventListener('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex'); 
        });
    }
});
document.addEventListener("DOMContentLoaded", function () {

    const btnlogout = document.querySelector('.logout');

    if (btnlogout) {
        btnlogout.addEventListener('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex');
        });
    }

});


document.addEventListener("DOMContentLoaded", function () { 
    
    const btnlogout = document.querySelector('.logout');

    if (btnlogout) {
        btn.addEventListener('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex');
        });
    }
    
});


