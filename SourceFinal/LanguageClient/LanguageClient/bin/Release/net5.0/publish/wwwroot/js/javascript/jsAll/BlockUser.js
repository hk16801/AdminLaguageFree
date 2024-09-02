
$(document).ready(function () {
    var accessToken = $('#accessToken').val();
        $(document).on('click', '.reopenButton', function () {
            var userId = $(this).data('userid'); // Lấy userId từ thuộc tính data
        Swal.fire({
            title: 'Are you sure?',
        text: "Do you want to unblock this account?",
        icon: 'success',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, open it!'
            }).then((result) => {
                if (result.isConfirmed) {
            // Gọi AJAX để xóa người dùng
            $.ajax({
                url: 'http://languagefree.cosplane.asia/Accounts/active/' + userId,
                type: 'PUT',
                headers: {
                    'Authorization': 'Bearer ' + accessToken
                },
                success: function (response) {
                    Swal.fire(
                        'Unblock!',
                        'This account has been unblocked!',
                        'success'
                    ).then(() => {
                        window.location.reload();
                    });

                }

            });
                }
            });
    });
 

});