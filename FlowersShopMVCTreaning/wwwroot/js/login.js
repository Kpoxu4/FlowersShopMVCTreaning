$(document).ready(function () {
    const togglePasswordButtons = $('.toggle-password');
    const btn = $('.login-btn');

    //togglePassword
    togglePasswordButtons.each(togglePassword);

    //message for user
    if (btn.length) {
        btn.on('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex');
        });
    }
});
