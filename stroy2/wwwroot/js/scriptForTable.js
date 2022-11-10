document.addEventListener("DOMContentLoaded", function () {
    //let table = document.createElement('table');

    let tbody = document.createElement('tbody');


   

    // Adding the entire table to the body tag
 

    let row_1 = document.createElement('tr');
    let heading_1 = document.createElement('th');
    heading_1.innerHTML = "Sr. No.";

    row_1.appendChild(heading_1);
 
 


    // Creating and adding data to second row of the table
    let row_2 = document.createElement('tr');
    let row_2_data_1 = document.createElement('td');
    row_2_data_1.innerHTML = "1.";
    let row_2_data_2 = document.createElement('td');
    row_2_data_2.innerHTML = "James Clerk";


    row_2.appendChild(row_2_data_1);
    row_2.appendChild(row_2_data_2);
    row_2.appendChild(row_2_data_3);
    tbody.appendChild(row_2);


    // Creating and adding data to third row of the table
    let row_3 = document.createElement('tr');
    let row_3_data_1 = document.createElement('td');
    row_3_data_1.innerHTML = "2.";
    let row_3_data_2 = document.createElement('td');
    row_3_data_2.innerHTML = "Adam White";
    let row_3_data_3 = document.createElement('td');
    row_3_data_3.innerHTML = "Microsoft";

    row_3.appendChild(row_3_data_1);
    row_3.appendChild(row_3_data_2);
    row_3.appendChild(row_3_data_3);
    tbody.appendChild(row_3);
})