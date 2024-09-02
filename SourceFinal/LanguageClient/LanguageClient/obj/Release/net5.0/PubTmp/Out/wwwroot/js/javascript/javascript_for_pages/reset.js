/* ==============HOVER CHANGE COLOR================  */
$("#Username")
  .focusin(function () {
    $(".login__icon").css("color", "#ffffff");
  })
  .focusout(function () {
    $(".login__icon").css("color", "#193978");
  });

$("#Password")
  .focusin(function () {
    $(".pass__icon").css("color", "#ffffff"),
      $(".login__icon").css("color", "#193978"),
      $(".hide__icon").css("color", "#ffffff");
  })
  .focusout(function () {
    $(".pass__icon").css("color", "#193978"),
      $(".hide__icon").css("color", "#193978");
  });

$(document).ready(function () {
  $(".login__submit").hover(
    function () {
      $(".button__icon").css("color", "#ffffff");
    },
    function () {
      $(".button__icon").css("color", "#ffffff");
    }
  );
});
/* ==============HIDEPASSWORD================  */
$(document).ready(function () {
  $(".toggle__password").click(function () {
    var passwordField = $(this).siblings(".login__pass");
    var icon = $(this).find("i");

    // Toggle password field visibility
    if (passwordField.attr("type") === "password") {
      passwordField.attr("type", "text");
      icon.removeClass("fa-eye").addClass("fa-eye-slash");
    } else {
      passwordField.attr("type", "password");
      icon.removeClass("fa-eye-slash").addClass("fa-eye");
    }
  });
});
