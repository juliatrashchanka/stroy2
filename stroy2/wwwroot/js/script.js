
$(function () {
    $("#create_order").click(function () {
        let datata = {

            "work": $("#Work").val(),
            "locality": $("#Locality").val(),
            "volume": $("#Volume").val(),
            "material": $("#Material").val(),

        }

        $.ajax({
            type: "POST",
            url: "/Home/Create",
            data: datata,
            success: function (response) {
                alert("Hello: ");
                GetOrder();
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });


    function GetOrder() {
        {
            $.ajax({
                type: "GET",
                url: "/Home/GetOrder",

                success: function (response) {
                    alert("Hello: ");
                    var t = JSON.parse();

                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        };
    };

   

});