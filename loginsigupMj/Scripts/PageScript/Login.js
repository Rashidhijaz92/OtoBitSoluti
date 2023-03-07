
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

// Code for bind all Controls by Button Click event
$("#btnSearchItem").click(function () {
    var ItemCode = ddlItemCode.val();
    $.ajax({
        type: "POST",
        url: SearchItemUrl,
        data: "{'ItemCode':'" + ItemCode + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSuccess(response) {
        var ItemDtl = response.d;
        $("#txtItemCode").val(ItemDtl.ItemCode);
        $("#txtItemName").val(ItemDtl.ItemName);
        $("#txtItemManuf").val(ItemDtl.Manufacturer);
        $("#txtItemMaterial").val(ItemDtl.Material);
        $("#txtItemType").val(ItemDtl.ItemType);
        $("#txtItemSubType").val(ItemDtl.ItemSubType);
        $("#txtItemColor").val(ItemDtl.Color);
        $("#txtItemUOM").val(ItemDtl.UOM);
        $("#txtItemHSN").val(ItemDtl.HSNCODE);
        $("#txtGSTRate").val(ItemDtl.GSTRate);
        $("#txtItemPurchaseCost").val(ItemDtl.PurchaseCost);
        $("#txtItemSellingCost").val(ItemDtl.SellingPrice);
    }
});     // btnClick End