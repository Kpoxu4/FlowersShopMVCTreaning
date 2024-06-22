$(document).ready(function () {
    const togglePasswordButtons = $('.toggle-password');
    const password = $('.password');
    const confirm = $('.repeat-password');
    const btn = $('.registration-btn');

    //togglePassword
    togglePasswordButtons.each(togglePassword);

    function onChange() {
        if (confirm.val() === password.val()) {
            confirm.get(0).setCustomValidity('');
        } else {
            confirm.get(0).setCustomValidity('Пароли не совпадают');
            confirm.get(0).reportValidity();
        }
    }

    confirm.on('input', onChange);

    //message for user
    if (btn.length) {
        btn.on('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex');
        });
    }

    //Check Login ant phone
    function checkInput(inputElement, url) {
        inputElement.removeClass('registration__login-available registration__login-validation-error registration__phone-available registration__phone-validation-error');
        if (inputElement.val() == '')
        {
            return;
        }
        $.get(url)
            .done(function (isAvailable) {
                if (isAvailable) {
                    inputElement.addClass('registration__login-available registration__phone-available');
                } else {
                    inputElement.addClass('registration__login-validation-error registration__phone-validation-error');
                }
            })
            .fail(function () {
                alert('server is bad');
            });
    }

    const debounceCheckLogin = debounce(function () {
        const loginInput = $('.registration_login');
        const userName = loginInput.val();
        const url = `/api/AuthUser/IsLoginAvailable?login=${userName}`;
        checkInput(loginInput, url);
    }, 500);

    $('.registration_login').on('keyup', debounceCheckLogin);

    const debounceCheckPhone = debounce(function () {
        const phoneInput = $('.registration_phone');
        const userPhone = phoneInput.val();
        const url = `/api/AuthUser/IsPhoneAvailable?phone=${userPhone}`;
        checkInput(phoneInput, url);
    }, 500);

    $('.registration_phone').on('keyup', debounceCheckPhone);
});
