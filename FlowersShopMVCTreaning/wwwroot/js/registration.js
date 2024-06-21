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
});

