$(document).ready(function () {
    const togglePasswordButtons = $('.toggle-password');
    const btn = $('.login-btn');

    //togglePassword
    togglePasswordButtons.each(function () {
        $(this).on('click', function () {
            const parent = $(this).closest('.registration__form-group');
            const passwordInput = parent.find('input[type="password"], input[type="text"]');

            if (passwordInput.length) {
                const type = passwordInput.attr('type') === 'password' ? 'text' : 'password';
                passwordInput.attr('type', type);
                $(this).text(type === 'password' ? '👁️' : '🙈');
            }
        });
    });

    //message for user
    if (btn.length) {
        btn.on('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex');
        });
    }
});
