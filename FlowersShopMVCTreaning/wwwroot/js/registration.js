$(document).ready(function () {
    const togglePasswordButtons = $('.toggle-password');
    const password = $('.password');
    const confirm = $('.repeat-password');

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

    function onChange() {
        if (confirm.val() === password.val()) {
            confirm.get(0).setCustomValidity('');
        } else {
            confirm.get(0).setCustomValidity('Пароли не совпадают');
            confirm.get(0).reportValidity();
        }
    }

    confirm.on('input', onChange);
});

