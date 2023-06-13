$(document).ready(function () {
    $("#contactForm").submit(function (event) {
        var name = $("#name").val();
        var email = $("#email").val();
        var subject = $("#subject").val();
        var message = $("#message").val();
        var error = "";

        if (name === "") {
            error += "Please enter your name.\n";
        }

        if (email === "") {
            error += "Please enter your email address.\n";
        } else {
            // Email validation using regular expression
            var regex = /^\S+@\S+\.\S+$/;
            if (!regex.test(email)) {
                error += "Please enter a valid email address.\n";
            }
        }

        if (subject === "") {
            error += "Please enter a subject.\n";
        }

        if (message === "") {
            error += "Please enter your message.\n";
        }

        if (error !== "") {
            alert(error);
            event.preventDefault();
        }
    });
});
