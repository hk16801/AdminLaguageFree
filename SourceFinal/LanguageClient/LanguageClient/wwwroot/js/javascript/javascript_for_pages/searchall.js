document.getElementById("showAllLink").addEventListener("click", function(event) {
    event.preventDefault(); // Prevent default anchor behavior

    document.getElementById("reloadForm").submit(); // Submit the form
});

