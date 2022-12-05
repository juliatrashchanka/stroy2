
let initialData;




var PagedGridModel = function (items) {
    this.items = ko.observableArray(items);
    document.addEventListener(("#create_order").click, GetOrders().then((items) => {
        for (var i = 0; i < items.length; i++) {
            this.items.push({ Work: items[i].Work, Locality: items[i].Locality, Volume: items[i].Volume, Material: items[i].Material })
        }
    }))
 
    //this.addItem = function () {
    //    this.items.push({ Work: "New item", Locality: "New item", Volume: "New item"});
    //};
    //this.addItem = function () {
       
    //    this.items.push({ Work: items[items.length].Work, Locality: items[items.length].Locality, Volume: items[items.length].Volume, Material: items[items.length].Material })
        
    //};


    this.sortByName = function () {
        this.items.sort(function (a, b) {
            return a.Work < b.Work ? -1 : 1;
        });
    };

    this.jumpToFirstPage = function () {
        this.gridViewModel.currentPageIndex(0);
    };

    this.gridViewModel = new ko.simpleGrid.viewModel({
        data: this.items,
        columns: [
            { headerText: "Наименование работы", rowText: "Work" },
            { headerText: "Населенный пункт", rowText: "Locality" } ,
            { headerText: "Объём работы", rowText: "Volume" },
            { headerText: "Материалы", rowText: "Material" }
        ],
        pageSize: 10
    });
};
 async function GetOrders() {
    return new Promise(function(resolve, reject)
    {
        $.ajax({
            type: "GET",
            url: "/Home/GetOrder",

            success: function (response) {
                resolve(JSON.parse(response))
               alert("Get: ");
                //Table();
               

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
};
//export function GetOrders();
ko.applyBindings(new PagedGridModel(initialData));
