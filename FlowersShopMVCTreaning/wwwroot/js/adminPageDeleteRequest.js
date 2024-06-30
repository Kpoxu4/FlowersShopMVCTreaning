$(document).ready(function () {
    $('.admin-change-button-del').on('click', function () {
        const postElement = $(this).closest('.slider__item.admin__item'); 
        const itemId = postElement.data('item-id');
        const url = `/api/Admin/DeleteCard?cardId=${itemId}`;
        $.ajax({
            url: url,
            type: 'DELETE',
            success: function (result) {
                console.log('Post deleted successfully');
                postElement.remove();
            },
            error: function (xhr, status, error) {
                console.error('Error deleting post:', error);
            }
        });
    });
});

