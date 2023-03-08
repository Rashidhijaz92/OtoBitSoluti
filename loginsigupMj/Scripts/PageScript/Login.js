
function login() {

    let email = $('#txtEmail').val();
    let password = $('#txtPass').val();


    var url = "/Admin/Login";

    var data = JSON.stringify({

        "Email": email,
        "Password": password
        
    });

    $.ajax({
        type: "POST",
        data: data,
        url: url,
        contentType: "application/json; chartset=utf-8",
        dataType: 'json',
        success: function (result) {
            if (result != "Login Failed")
                window.location.href = "/Admin/Index";

        },
        Error: function (result) {
            alert(error);
        }

    });
}
