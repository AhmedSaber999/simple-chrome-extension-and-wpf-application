
  $(document).ready(function () {
    FitchPageData();
  });

function FillTable(data){
    data.forEach(raw => {
        $("#table-body-id").append(
            `
                <tr>
                    <td>${raw.email}</td>
                    <td>${raw.first_name}</td>
                    <td>${raw.last_name}</td>
                    <td><img src="${raw.avatar}" /></td>
                </tr>
            `
        )
    });
}

function FitchPageData(){
    $.ajax({
        url: "https://reqres.in/api/users?page=1",
        "method": "GET",
        "datatype": "json",
        success: function (data) {
            FillTable(data.data);
        }
    });
}