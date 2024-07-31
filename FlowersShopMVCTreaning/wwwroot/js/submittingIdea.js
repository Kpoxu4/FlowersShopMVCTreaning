$(document).ready(function () {    
    const baseApiUrl = `https://localhost:7078`;    
    const button = $('.offer-your-bouquet-btn');     

    button.click(sendText);

    function sendText() {
        const url = baseApiUrl + "/api/FlowerIdeaSubmissionApi/CreatedIdea";
        const authorName = $('.offer-your-bouquet__name').val();
        const authorPhone = $('.offer-your-bouquet__phone').val();
        const idea = $('.offer-your-bouquet__idea').val();
        const messageWindow = $('.window-message-for-user');
        const messageContent = $('.window-message-for-user-content');
        const messageText = $('.window-message-for-user-text');  
       
        const body = {
            authorName: authorName,
            authorPhone: authorPhone,
            text: idea
        };
        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(body),
            contentType: 'application/json; charset=utf-8', 
            success: function (response) {                
                if (response.message) {                         
                    messageWindow.css("display", "flex"); 
                    messageWindow.contents().show();
                    messageText.text(response.message);  

                    $('.offer-your-bouquet__name').val('');
                    $('.offer-your-bouquet__phone').val('');
                    $('.offer-your-bouquet__idea').val('');
                }               
            },
            error: function (xhr) {                
                const errors = JSON.parse(xhr.responseText).errors;
                const firstProperty = Object.keys(errors)[0];
                const firstValue = errors[firstProperty][0];
                
                messageWindow.css("display", "flex");
                messageWindow.contents().show();
                messageText.text(firstValue);  
            }
        });
    };
});

