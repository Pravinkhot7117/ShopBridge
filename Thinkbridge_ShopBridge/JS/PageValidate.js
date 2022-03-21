function validate() {
    var name = document.getElementById("txt_ItemName");
    var ItemPrice = document.getElementById("txt_ItemPrice");
    var Quantity = document.getElementById("txt_Quantity");
    var status = true;

    if (name.value == '') {
        alert("Please enter item name",name.focus());
        status = false;
    } else if (ItemPrice.value <= 0) {
        alert("Please enter item price", ItemPrice.focus());
        status = false;
    } else if (Quantity.value <= 0) {
        alert("Please enter item price", Quantity.focus());
        status = false;
    }
    return status;
}

function Clear() {
    var name = document.getElementById("txt_ItemName");
    var ItemPrice = document.getElementById("txt_ItemPrice");
    var Desciption = document.getElementById("txt_ItemDescription");
    var Quantity = document.getElementById("txt_Quantity");

    name.value = '';
    ItemPrice.value = '';
    Desciption.value = '';
    Quantity.value = '';
}

function confirmAction() {
    let confirmAction = confirm("Are you sure delete this reord?");
    if (confirmAction) {
        alert("Action successfully executed");
    }
}

function Confirm() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";
    confirm_value.value = "";
    if (confirm("Are you sure delete this reord?")) {
        //confirm_value.value = "Yes";
        hdn_ConfirmValue.value = "Yes";
    } else {
        hdn_ConfirmValue.value = "No";
    }
    //document.forms[0].appendChild(confirm_value);
}

