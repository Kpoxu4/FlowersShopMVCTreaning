$(document).ready(function () {

    $('.slider__item-btn').on('click', function () {
        const itemId = $(this).data('item-id');
        const url = `/api/Basket/CreateBasketItemWithRegisteredUser?cardId=${itemId}`;
        const basketElement = $('.basket__items');
        const userElemetn = $('.user__data');
        $.ajax({
            url: url,
            type: 'post',
            success: function (result) {
                console.log('add item to cart');
            },
            error: function (xhr) {               
                if (xhr.status === 300) {
                    userElemetn.css('display', 'block')
                    userElemetn.addClass('active')

                    const phoneInput = $('.user_data_phone');
                    const nameInput = $('.user_data_name');
                    const buttonUserData = $('.btn_user_data');                  
                    function checkInputs() {
                        const phone = phoneInput.val().trim();
                        const name = nameInput.val().trim();

                        if (phone && name) {
                            buttonUserData.css('pointer-events', 'auto');                           
                        } else {                            
                            buttonUserData.css('pointer-events', 'none');                            
                        }
                    }
                    phoneInput.on('input', checkInputs);
                    nameInput.on('input', checkInputs);
                    buttonUserData.on('click', function () {
                        const phoneInputVal = $('.user_data_phone').val();
                        const nameInputVal = $('.user_data_name').val();                       
                        const urlData = `/api/Basket/CreateBasketItem?name=${nameInputVal}&phone=${phoneInputVal}`;
                        $.ajax({
                            url: urlData, 
                            type: 'post',                            
                            success: function (response) {                                
                                console.log('X');
                            },
                            error: function (xhr) {                                
                                console.log('Error:');
                            }
                        });
                    });
                }                
            }
        });
    }); 
});


