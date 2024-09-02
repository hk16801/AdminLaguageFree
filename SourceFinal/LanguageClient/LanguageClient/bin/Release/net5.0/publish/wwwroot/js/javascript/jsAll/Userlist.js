$(document).ready(function () {
    var accessToken = $('#accessToken').val();

    $(document).on('click', '.banButton', function () {
        var userId = $(this).data('userid'); // Lấy userId từ thuộc tính data
        Swal.fire({
            title: 'Are you sure?',
            text: "Do you want to block this account?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, block it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: 'http://languagefree.cosplane.asia/Accounts/remove/' + userId,
                    type: 'PUT',
                    headers: {
                        'Authorization': 'Bearer ' + accessToken
                    },
                    success: function (response) {
                        Swal.fire(
                            'Blocked!',
                            'This account has been blocked.',
                            'success'
                        ).then(() => {
                            window.location.reload();
                        });
                    },
                    error: function (xhr, status, error) {
                        Swal.fire(
                            'Error!',
                            'An error occurred while blocking the account.',
                            'error'
                        );
                    }
                });
            }
        });
    });

   
});
