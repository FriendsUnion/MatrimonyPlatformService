const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButton.addEventListener('click', () => {
    container.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
    container.classList.remove("right-panel-active");
});

function showPassword() {
    if ($("#password").val().length > 0) {
        var x = document.getElementById("password");
        if (x.type == "text") {
            x.type = "password";
            $("#passwordIcon").removeClass("fa-eye-slash");
            $("#passwordIcon").addClass("fa-eye");
        } else {
            x.type = "text";
            $("#passwordIcon").removeClass("fa-eye");
            $("#passwordIcon").addClass("fa-eye-slash");
        }
    }
}

function enableConfirmPass() {
    if ($("#password").val().length > 0) {
        $("#confirmPass").prop("disabled", false);
    }
    else {
        $("#confirmPass").prop("disabled", true);
    }
}
jQuery('#confirmPass').on('input', function () {
    if ($("#password").val() === $("#confirmPass").val()) {
        $("#confirmPass").css("outline - color", "green");
        $("#passwordOk").show();
        $("#passwordWrong").hide();
    } else {
        $("#confirmPass").css("outline - color", "#ffdede");
        $("#passwordWrong").show();
        $("#passwordOk").hide();
    }

});

$(document).ready(function () {
    $("#confirmPass").prop("disabled", true);
    $("#passwordOk").hide();
    $("#passwordWrong").hide();
});

function showPasswordSignin() {
    if ($("#passwordsingin").val().length > 0) {
        var x = document.getElementById("passwordsingin");
        if (x.type == "text") {
            x.type = "password";
            $("#passwordIconsignin").removeClass("fa-eye-slash");
            $("#passwordIconsignin").addClass("fa-eye");
        } else {
            x.type = "text";
            $("#passwordIconsignin").removeClass("fa-eye");
            $("#passwordIconsignin").addClass("fa-eye-slash");
        }
    }
}
