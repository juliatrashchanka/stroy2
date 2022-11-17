   // alert("hello");
    document.addEventListener("DOMContentLoaded", function () {

       // alert("hello");
        GetOrder();
    });
     
    function GetOrder() {
        debugger;
        $.ajax({
             type: "GET",
             url: "/Home/GetOrder",

             success: function (response) {
                           alert("table: ");
                            //Table();
                            UpdateOrder(response);

                        },
             failure: function (response) {
                            alert(response.responseText);
                        },
             error: function (response) {
                            alert(response.responseText);
                        }
        });
        

    };
   
//var viewModel = {
//    name: ko.observable("Евгений")
//};
//ko.applyBindings(viewModel);

var initialData = [
    { name: "Well-Travelled Kitten", sales: 352, price: 75.95 },
    { name: "Speedy Coyote", sales: 89, price: 190.00 },
    { name: "Furious Lizard", sales: 152, price: 25.00 },
    { name: "Indifferent Monkey", sales: 1, price: 99.95 },
    { name: "Brooding Dragon", sales: 0, price: 6350 },
    { name: "Ingenious Tadpole", sales: 39450, price: 0.35 },
    { name: "Optimistic Snail", sales: 420, price: 1.50 }
];

var PagedGridModel = function (items) {
    this.items = ko.observableArray(items);

    this.addItem = function () {
        this.items.push({ name: "New item", sales: 0, price: 100 });
    };

    this.sortByName = function () {
        this.items.sort(function (a, b) {
            return a.name < b.name ? -1 : 1;
        });
    };

    this.jumpToFirstPage = function () {
        this.gridViewModel.currentPageIndex(0);
    };

    this.gridViewModel = new ko.simpleGrid.viewModel({
        data: this.items,
        columns: [
            { headerText: "Item Name", rowText: "name" },
            { headerText: "Sales Count", rowText: "sales" },
            { headerText: "Price", rowText: function (item) { return "$" + item.price.toFixed(2) } }
        ],
        pageSize: 4
    });
};

ko.applyBindings(new PagedGridModel(initialData));

    function UpdateOrder(orderJson) {

        // url: "/Home/GetOrder",


       // alert("Update: ");
        debugger;
        let obj = JSON.parse(orderJson);
        if (obj != null) {
            Table(obj);
        }


        // Table();



    };


    function Table(obj) {
        //let table = document.createElement('table');
        let tbody = document.createElement('tbody');
        document.getElementById('tableScript').appendChild(tbody);

        //   let tbody = document.createElement('tbody');


        //   let row_th = document.createElement('tr');

        // Adding the entire table to the body tag
        for (let i = 0; i < obj.length; i++) {

            let item = obj[i];

            let row = document.createElement('tr');

            let row_data_1 = document.createElement('td');

            row_data_1.innerHTML = item.Work;

            let EditOrderPartial = document.createElement('button');
            EditOrderPartial.classList.add("btn", "btn-light");
            EditOrderPartial.innerHTML = "Изменить";


            let PartialDetails = document.createElement('button');
            PartialDetails.classList.add("btn", "btn-light");
            PartialDetails.innerHTML = "Подробнее";
            PartialDetails.addEventListener("onclick", function (e) {
                debugger;
            })

            let DeleteOrder = document.createElement('a');
            DeleteOrder.classList.add("btn", "btn-light");
            DeleteOrder.innerHTML = "Удалить";
            DeleteOrder.href = "/Home/ConfirmDelete";

            row.appendChild(row_data_1);
            row.appendChild(EditOrderPartial);
            row.appendChild(PartialDetails);
            row.appendChild(DeleteOrder);


            tbody.appendChild(row);

        }
    }