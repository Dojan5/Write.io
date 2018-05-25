$(document).ready(function () {
    //Script handling the front-page search bar
    var FPtypingTimer;
    var FPdoneTypingInterval = 150;
    $("#FrontpageSearch").on('keyup', function () {
        clearTimeout(FPtypingTimer);
        FPtypingTimer = setTimeout(FPSearch, FPdoneTypingInterval);
    });
    $("#FrontpageSearch").on('keydown', function () {
        clearTimeout(FPtypingTimer);
    });
    //Script handling the search function in the blog
    $('#BlogSearchbar').on('keypress', function (e) {
        if (e.which === 13) {
            var URL = $(this).data('url');
            var Query = $(this).val();
            window.location.href = URL + Query;

        }
    });
    //Ajax request firing when posting a comment on a blog post
    $('#PostCommentButton').on('click', function (e) {
        var jsonObject = {
            "body": $('#PostComment').val(),
            "PostId": $(this).data("p")
        };
        $.ajax({
            url: "/Blog/PostComment/",
            type: "POST",
            data: JSON.stringify(jsonObject),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (response) {
                //alert(response.responseText);
            },
            success: function (response) {
                //alert(response);
            }
        }).done(function () {
            location.reload();
        });
    });


});

//Front-page search function
//Function that runs when someone stops typing in the search bar
function FPSearch() {
    var filter = $("#FrontpageSearch").val();
    $.ajax({
        url: "/Home/Search/?Query=" + filter,
        type: "GET",
    }).done(function (partialViewResult) {
        $("#HomePageBlogGrid").html(partialViewResult);
    });
};