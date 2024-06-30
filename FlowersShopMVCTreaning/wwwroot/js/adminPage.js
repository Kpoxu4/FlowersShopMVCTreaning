$(document).ready(function () {
    const discountInput = $('.admin_discount');
    const mesageCreateCard = $('.message-creation-card');

    discountInput.on('input', function () {
       
        let newValue = parseInt(this.value, 10);
        if (isNaN(newValue)) {
            newValue = 0;
        }
        this.value = newValue;
    });

    $('.admin_discount').on('keydown', function (e) {
        if (e.key === 'ArrowUp') {            
            const currentValue = parseInt(this.value, 10);
            const newValue = isNaN(currentValue) ? 0 : Math.min(currentValue + 1, 50);
            this.value = newValue; 
        } else if (e.key === 'ArrowDown') {           
            const currentValue = parseInt(this.value, 10);
            const newValue = isNaN(currentValue) ? 0 : Math.max(currentValue - 1, 0);
            this.value = newValue; 
        }
    });
    if (mesageCreateCard)
    {
        const buttonMessage = $('.message-creation-card-btn');
        buttonMessage.on('click', function () {
            mesageCreateCard.hide();
        });
    }
});