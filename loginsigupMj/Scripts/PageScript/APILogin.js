
//$(Document).ready(function () {
//    Getuserdetails();

//});s


var GetLogin=function(){

    var email = $('#txtusername').val();
    let password = $('#txtpassword').val();
    var url = "/Api/Values/GetLogin";
    var data = JSON.stringify({

        "username": email,
        "password": password
        
    });

    $.ajax({
        type: "POST",
        data: data,
        url: url,
        //url: http://localhost:50549/api/Values/GetLogin,
        contentType: "application/json; chartset=utf-8",
        dataType: 'json',
        success: function (result) {

            if (result != "Login Failed")
                //clear();
                alert(result);
            
            window.location.href = "/Admin/Index";


            Getuserdetails();
          


        },
        Error: function (result) {
            alert(result);
        }

    });
}
function Getuserdetails() {
    var GetuserUrl ="/api/values/GetUserApi"
    $.ajax({
        type: "Get",
        url: GetuserUrl,
        //url: http://localhost:50549/api/Values/GetUserApi,
        contentType: "application/json; chartset=utf-8",
        dataType: 'json',
        success: function (response) {

            var ItemDtl = (response.d);
            $("#txtFName").val(ItemDtl.FirstName);
            $("#txtLName").val(ItemDtl.LastName);
            $("#txtEmail").val(ItemDtl.email);
            $("#txtGender").val(ItemDtl.Gender);
            $("#chkbox").checked == true(ItemDtl.Active);
            
                //alert(JSON.stringify(result));
            //if(result)
            //var row = '';
            //for (var i = 0; i < result.length; i++) {
            //    ro = row
            //        + "<tr"
            //    +"<td>"+result[i].ID+"</td>"
            //    +"<td>"+result[i].FirstName+"</td>"
            //    +"<td>"+result[i].LastName+"</td>"
            //    +"<td>"+result[i].Gender+"</td>"
            //        + "<td>" + result[i].Email + "</td>"
            //    +"</tr>"
            //}
            //if (row != '') {

            //    $('#tblUserBody').append(row)
            //}

        },
        Error: function (msg) {
            alert(msg);
        }

    });
}



//Update Email & data
$("#btnUpdate").click(function () {
    var UpdateData = {
        FirstName: $("#lblId").val(UpdateData.Id),
        FirstName: $("#txtFName").val(UpdateData.FirstName),
        LastName: $("#txtLName").val(UpdateData.LastName),
        Email: $("#txtEmail").val(UpdateData.Email),
        Gender: $("#txtGender").val(UpdateData.Gender),
        Active: $("")
       
        
      
    };
    var updatedataurl = "/api/Values/PostUpdateUser";
    $.ajax({
        type: "POST",
        url: updatedataurl,
        data: JSON.stringify({ 'UpdateData': UpdateData }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSuccess(response) {
        var ItemDtl = response.d;
        alert(ItemDtl);
        $("#txtFName").val(ItemDtl.FirstName);
        $("#txtLName").val(ItemDtl.LastName);
        $("#txtEmail").val(ItemDtl.email);
        $("#txtGender").val(ItemDtl.Gender);
        $("#chkbox").checked==true(ItemDtl.Active);
  
    }
}); // End of Update Code







function clear() {

    $('#txtusername').val('');
    $('#txtpassword').val('');

}

