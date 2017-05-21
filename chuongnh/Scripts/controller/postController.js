$(document).ready(function () {

    $('#frm-comment').submit(function (e) {
        //e.preventDefault();

        var action = $(this).attr('action');
        var method = 'POST';
        var data = $(this).serialize();

        $.ajax({
            url: action,
            method: method,
            data: data,
            success: function (res) {
                confirm(res);
                if (res.status == true) {

                    var html =
                        '<li>' +
                        '<div class="comment-avatar">' +
                        '<i class="fa fa-user"></i>' +
                        '</div>' +
                        '<div class="comment-container">' +
                        '<div class="comment-author">' +
                        res.Fullname +
                        '<span class="comment-date">' +
                        'Vào <span class="underline">Ngày @item.CreatedDate.Day tháng @item.CreatedDate.Month năm @item.CreatedDate.Year</span> lúc <span class="underline">@item.CreatedDate.Hour:@item.CreatedDate.Minute</span>' +
                        '</span>' +
                        '</div>' +
                        '<div class="comment-content">' +
                        res.Comment +
                        '</div>' +
                        '</div>' +
                        '</li>';

                    $('#comment-list').append(html);
                }
            }
        })
    })
})