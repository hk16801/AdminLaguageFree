$(document).ready(function () {
    // Lấy giá trị của AccessToken từ hidden field khi trang được tải
    var accessToken = $('#accessToken').val();

    $(document).on('click', '.banButton', function () {
        var userId = $(this).data('userid');
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
                // Gọi AJAX để xóa người dùng
                $.ajax({
                    url: 'http://languagefree.cosplane.asia/Accounts/remove/' + userId,
                    type: 'PUT',
                    headers: {
                        'Authorization': 'Bearer ' + accessToken
                    },
                    success: function (response) {
                        Swal.fire(
                            'Block!',
                            'This account has been blocked!',
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
                        )
                    }
                });
            }
        });
    });
});
    document.getElementById("saveButton").addEventListener("click", function () {
        Swal.fire({
            title: 'Profile Saved',
            text: 'This profile has been saved successfully!',
            icon: 'success',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
        });
    });
    document.getElementById("editButton").addEventListener("click", function () {
        window.location.href = 'edit_profile.html';
    });

    document.getElementById("createButton").addEventListener("click", function () {
        Swal.fire({
            title: 'Create',
            text: 'This new item has been created!',
            icon: 'success',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK'
        });
    });

        function closeModal(userId) {
            var modal = document.getElementById('userDetailsModal_' + userId);
            if (modal) {
                modal.classList.remove('show');
                modal.style.display = 'none';
                modal.setAttribute('aria-hidden', 'true');
                modal.setAttribute('aria-modal', 'false');
            }
        }

        function closeModal(userId) {
            var modal = document.getElementById('userDetailsModal_' + userId);
            if (modal) {
                modal.classList.remove('show');
                modal.style.display = 'none';
                modal.setAttribute('aria-hidden', 'true');
                modal.setAttribute('aria-modal', 'false');
            }
        }
