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

// general functions
const togglePassword = function () {
    $(this).on('click', function () {
        const parent = $(this).closest('.registration__form-group');
        const passwordInput = parent.find('input[type="password"], input[type="text"]');

        if (passwordInput.length) {
            const type = passwordInput.attr('type') === 'password' ? 'text' : 'password';
            passwordInput.attr('type', type);
            $(this).text(type === 'password' ? '👁️' : '🙈');
        }
    });
}








