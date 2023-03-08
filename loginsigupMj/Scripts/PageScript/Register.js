


function register() {
    let firstname = $('#txtFirstName').val();
    let lastName = $('#txtLastName').val();
    let gender = '';
    if ($('#rbtnMale').prop('checked') == true) {
        gender = 'Male';
    }
    else
        gender = 'Female';

    let Active = '';
    if ($('#chkbox'.checked == true)) {
        Active = '1';
    } else {
        Active = '0';
    }

    let email = $('#txtmail').val();
    let password = $('#txtpassword').val();


    var url = "/admin/Register";

    var data = JSON.stringify({
        "FirstName": firstname,
        "LastName": lastName,
        "Gender": gender,
        "Email": email,
        "PassWord": password,
        "Active": Active
    });

    $.ajax({
        type: "POST",
        data: data,
        url: url,
        contentType: "application/json; chartset=utf-8",
        dataType: 'json',
        success: function (result) {
            clear();
            alert(result);
        },
        Error: function (result) {
            alert(error);
        }

    });
}

function clear(){

    $('#txtFirstName').val('');
    $('#txtLastName').val('');
    $('#rbtnMale').prop('checked', false);
    $('#rbtnFemale').prop('checked', false);
    $('#chkbox').prop('checked', false);
    $('#txtmail').val('');
    $('#txtpassword').val('');

}


