
        function closeModal(userId) {
            var modal = document.getElementById('userDetailsModal_' + userId);
            if (modal) {
                modal.classList.remove('show');
                modal.style.display = 'none';
                modal.setAttribute('aria-hidden', 'true');
                modal.setAttribute('aria-modal', 'false');
            }
}

document.addEventListener('DOMContentLoaded', function () {
    var filterBtn = document.querySelector('.filter-btn');
    var filterDropdown = document.getElementById('filter-dropdown');

    filterBtn.addEventListener('click', function () {
        if (filterDropdown.style.display === 'none' || filterDropdown.style.display === '') {
            filterDropdown.style.display = 'block';
        } else {
            filterDropdown.style.display = 'none';
        }
    });

    document.addEventListener('click', function (event) {
        if (!filterDropdown.contains(event.target) && !filterBtn.contains(event.target)) {
            filterDropdown.style.display = 'none';
        }
    });
});