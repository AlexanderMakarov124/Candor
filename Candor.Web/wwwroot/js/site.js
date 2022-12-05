// Allow popovers.
var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl);
});

/**
 * Increments likes of the post.
 * @param {number} id Post id.
 */
function Like(id) {
    $.ajax({
        url: '/Like',
        type: 'PUT',
        data: { id },
        success: function (response) {
            $('#likes').html(response);
        },
        error: function () {
            alert('Error occurred while like');
        }
    });
}

/**
 * Load user's posts.
 */
function LoadPosts() {
    const isPublic = document.getElementById('public').checked;
    const isPrivate = document.getElementById('private').checked;

    $.ajax({
        url: '/Posts',
        type: 'GET',
        data: { isPublic, isPrivate },
        success: function(response) {
            $('#postsTest').load(this.url);
        },
        error: function() {
            alert('Error occurred while loading posts.');
        }
    });
}