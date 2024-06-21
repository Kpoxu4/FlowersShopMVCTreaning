$(document).ready(function () {
    
    const sliderItems = $(".slider__item");
    const totalItems = sliderItems.length;
    const sliderWidth = $(".slider__items").width();
    const itemWidth = sliderItems.eq(0).width();
    const itemsToShow = Math.floor(sliderWidth / itemWidth);
    let currentIndex = 0;
    const messageWindow = $('.window-message-for-user');
    const displayStatus = localStorage.getItem('messageWindowDisplay');
    const btnCloseWindow = $('.window-message-for-user-btn');
   

    // slider
    function showItems(startIndex) {
        for (let i = 0; i < totalItems; i++) {
            const itemIndex = (startIndex + i) % totalItems;
            if (i < itemsToShow) {
                sliderItems.eq(itemIndex).css("display", "block");
                animateOpacity(sliderItems.eq(itemIndex));
            } else {
                sliderItems.eq(itemIndex).css("display", "none");
            }
        }
    }

    function animateOpacity(element) {
        let opacity = 0;
        function increase() {
            opacity += 0.05; // speed animation
            element.css("opacity", opacity);
            if (opacity >= 1) {
                element.css("opacity", 1);
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

    const nextBtn = $(".slider__btn-next");
    const prevBtn = $(".slider__btn-prev");
    const centerBtn = $(".slider__btn-center");

    nextBtn.on("click", nextSlide);
    prevBtn.on("click", prevSlide);
    centerBtn.on("click", centerSlide);

    showItems(currentIndex);

    //User show message
    if (messageWindow.length && displayStatus === 'flex') {
        messageWindow.css('display', displayStatus);
        localStorage.removeItem('messageWindowDisplay');
    }
    btnCloseWindow.on('click', function () {
        messageWindow.hide();
    });
});


