
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

// slider
document.addEventListener("DOMContentLoaded", function () {
    const sliderItems = document.querySelectorAll(".slider__item");
    const totalItems = sliderItems.length;
    const sliderWidth = document.querySelector(".slider__items").offsetWidth;
    const itemWidth = sliderItems[0].offsetWidth;
    const itemsToShow = Math.floor(sliderWidth / itemWidth);
    let currentIndex = 0;

    function showItems(startIndex) {
        for (let i = 0; i < totalItems; i++) {
            const itemIndex = (startIndex + i) % totalItems;
            if (i < itemsToShow) {
                sliderItems[itemIndex].style.display = "block";
                animateOpacity(sliderItems[itemIndex]);
            } else {
                sliderItems[itemIndex].style.display = "none";

            }
        }
    }

    function animateOpacity(element) {
        let opacity = 0;
        function increase() {
            opacity += 0.05; // скорость анимации
            element.style.opacity = opacity;
            if (opacity >= 1) {
                element.style.opacity = 1;
            } else {
                requestAnimationFrame(increase);
            }
        }
        increase();
    }

    function nextSlide() {
        currentIndex = (currentIndex + 1) % totalItems;
        showItems(currentIndex);
    }

    function prevSlide() {
        currentIndex = (currentIndex - 1 + totalItems) % totalItems;
        showItems(currentIndex);
    }

    function centerSlide() {
        currentIndex = Math.floor(totalItems / 2);
        showItems(currentIndex);
    }

    const nextBtn = document.querySelector(".slider__btn-next");
    const prevBtn = document.querySelector(".slider__btn-prev");
    const centerBtn = document.querySelector(".slider__btn-center");

    nextBtn.addEventListener("click", nextSlide);
    prevBtn.addEventListener("click", prevSlide);
    centerBtn.addEventListener("click", centerSlide);

    showItems(currentIndex);
});

//password show
document.addEventListener('DOMContentLoaded', function () {
    const togglePasswordButtons = document.querySelectorAll('.toggle-password');

    togglePasswordButtons.forEach(button => {
        button.addEventListener('click', function () {
            const passwordInput = this.previousElementSibling;
            const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
            passwordInput.setAttribute('type', type);
            this.textContent = type === 'password' ? '👁️' : '🙈';
        });
    });
});

//Password Validation
document.addEventListener("DOMContentLoaded", function () {
    const password = document.querySelector('.password');
    const confirm = document.querySelector('.repeat-password');
    function onChange() {
        if (confirm.value === password.value) {
            confirm.setCustomValidity('');
        } else {
            confirm.setCustomValidity('Пароли не совпадают');
            confirm.reportValidity();
        }
    }    
    confirm.addEventListener('input', onChange);
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
    const messageWindow = document.querySelector('.window-message-for-user');
    const displayStatus = localStorage.getItem('messageWindowDisplay');   

    if (messageWindow && displayStatus === 'flex') {
        messageWindow.style.display = displayStatus; 
        localStorage.removeItem('messageWindowDisplay'); 
    }    
   
});

document.addEventListener("DOMContentLoaded", function () {
    const btnCloseWindow = document.querySelector('.window-message-for-user-btn');
    const messageWindow = document.querySelector('.window-message-for-user');
    btnCloseWindow.addEventListener('click', function () {
        messageWindow.style.display = 'none'; 
    });
});

document.addEventListener("DOMContentLoaded", function () { 
    
    const btnlogout = document.querySelector('.logout');

    if (btnlogout) {
        btn.addEventListener('click', function () {
            localStorage.setItem('messageWindowDisplay', 'flex');
        });
    }
    
});


