var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: "/User/ChangeStatus",
                data: { id: id },
                type: "json",
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    if (response.status == true) {
                        $(this).text('Kích Hoạt');
                    }
                    else {
                        $(this).text('Khóa');
                    }
                }
            });
        });
    }
}