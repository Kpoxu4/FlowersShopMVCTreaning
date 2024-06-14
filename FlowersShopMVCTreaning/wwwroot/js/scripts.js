
//burger menu
document.addEventListener('DOMContentLoaded', function () {
    const burgerButton = document.querySelector('.burger');
    const menu = document.querySelector('.burger__menu');

    burgerButton.addEventListener('click', function () {
        if (menu.style.display === 'block') {
            menu.style.display = 'none';
        } else {
            menu.style.display = 'block';
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
        function increase () {
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
document.addEventListener("DOMContentLoaded", function () {
    function togglePasswordVisibility() {
        const passwordInput = document.querySelector('input[name="password"]');
        const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
        passwordInput.setAttribute('type', type);
    };
});