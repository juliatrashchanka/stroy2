//include("/js/scriptForTable.js");

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
                alert("Post: ");
                //GetOrder();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    //function GetOrder() {
    //    {
    //        $.ajax({
    //            type: "GET",
    //            url: "/Home/GetOrder",

    //            success: function (response) {
    //                alert("Get: ");
    //                //Table();
    //                UpdateOrder(response);

    //            },
    //            failure: function (response) {
    //                alert(response.responseText);
    //            },
    //            error: function (response) {
    //                alert(response.responseText);
    //            }
    //        });
    //    };
    //};



    //function UpdateOrder(orderJson) {
                        
    //           // url: "/Home/GetOrder",

              
    //        alert("Update: ");
    //        debugger;
    //        let obj = JSON.parse(orderJson);
    //        if (obj != null) {
    //           // Table(obj);
    //        }


    //        // Table();

         
       
    //};


    //function Table(obj) {
    //    //let table = document.createElement('table');
    //    let tbody = document.createElement('tbody');
    //    document.getElementById('tableScript').appendChild(tbody);

    //    //   let tbody = document.createElement('tbody');


    //    //   let row_th = document.createElement('tr');

    //    // Adding the entire table to the body tag
    //    for (let i = 0; i < obj.length; i++) {

    //        let item = obj[i];

    //        let row = document.createElement('tr');

    //        let row_data_1 = document.createElement('td');

    //        row_data_1.innerHTML = item.Work;

    //        let EditOrderPartial = document.createElement('button');
    //        EditOrderPartial.classList.add("btn", "btn-light");
    //        EditOrderPartial.innerHTML = "Изменить";


    //        let PartialDetails = document.createElement('button');
    //        PartialDetails.classList.add("btn", "btn-light");
    //        PartialDetails.innerHTML = "Подробнее";
    //        PartialDetails.addEventListener("onclick", function () {

    //        })

    //        let DeleteOrder = document.createElement('a');
    //        DeleteOrder.classList.add("btn", "btn-light", "ord");
    //        DeleteOrder.innerHTML = "Удалить";
    //        DeleteOrder.href = "/Home/DeleteOrder";

    //        row.appendChild(row_data_1);
    //        row.appendChild(EditOrderPartial);
    //        row.appendChild(PartialDetails);
    //        row.appendChild(DeleteOrder);


    //        tbody.appendChild(row);

    //    }
    //}
   

});