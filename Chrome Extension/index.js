
 $(document).ready(function () {
    $("#loader-id").hide();
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
    let page_number = $("#page-number").val();
    $.ajax({
        url: "https://reqres.in/api/users?page=" + page_number,
        "method": "GET",
        "datatype": "json",
        success: function (data) {
            FillTable(data.data);
        }
    });
}

$( "#sync-button-id" ).click(function() {
    SendPageDataToLocalhost();
});

async function SendPageDataToLocalhost(){
    page_1_data = await GetPageData(1);
    page_2_data = await GetPageData(2);
    
    PostToLocalhost(page_1_data);
    PostToLocalhost(page_2_data);
}

async function GetPageData(page_number){
    return await $.ajax({
            url: "https://reqres.in/api/users?page=" + page_number,
            "method": "GET",
            "datatype": "json",
            success: function (data) {
                return data;
            }
        });
}

function PostToLocalhost(data){
    $.ajax
    ({
        type: 'post',
        url:"http://localhost:5000/",
        data:JSON.stringify({
            data: data.data, per_page: data.per_page, total: data.total,
            page: data.page, total_pages: data.total_pages, support: data.support
        }),
        beforeSend: function () {
            $("#table-id").hide();
            $("#footer-id").hide();
            $("#loader-id").show(); $("#loader-div").css("margin-top", "30%");
        },
        success: function (response) {
            Swal.fire(
                'Good job!',
                'You sent the page data!',
                'success'
              )
        },
        complete: function () {
            $("#loader-id").hide(); $("#loader-div").css("margin-top", "0");        
            $("#table-id").show();
            $("#footer-id").show();
        },
        error: function(response){
            if(response.statusCode == 500){
                Swal.fire({
                    title: 'Error!',
                    text: 'Oops! sorry, its all about us',
                    icon: 'error',
                    confirmButtonText: 'Cool'
                  })
            }
            else{
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                })
            }
        }

    });

}