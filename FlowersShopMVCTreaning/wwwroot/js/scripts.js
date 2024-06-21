$(document).ready(function () {
    const burgerButton = $('.burger');
    const menu = $('.burger__menu');

    //burger menu
    function toggleMenu() {
        if (menu.css('display') === 'block') {
            menu.hide();
        } else {
            menu.show();
        }
    }

    burgerButton.on('click', function (event) {
        event.stopPropagation();
        toggleMenu();
    });

    $(document).on('click', function (event) {
        if (!menu.is(event.target) && menu.css('display') === 'block') {
            menu.hide();
        }
    });

    $(document).on('scroll', function () {
        if (menu.css('display') === 'block') {
            menu.hide();
        }
    });
});








