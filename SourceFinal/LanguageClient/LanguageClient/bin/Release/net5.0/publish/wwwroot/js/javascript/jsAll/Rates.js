function closeModal(userId) {
    var modal = document.getElementById('userDetailsModal_' + userId);
    if (modal) {
        modal.classList.remove('show');
        modal.style.display = 'none';
        modal.setAttribute('aria-hidden', 'true');
        modal.setAttribute('aria-modal', 'false');
    }
}