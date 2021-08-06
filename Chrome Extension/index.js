var page_number = 1;
var page1_data = FitchPageData(1);
var page2_data = FitchPageData(2);
 $(document).ready(async function () {
    $("#loader-id").hide();

    //get pages data
    
    page1_data = await FitchPageData(1);
    page2_data = await FitchPageData(2);
    // import data into table body
    FillTable(page1_data.data);
  });

async function FitchPageData(page_number){
    return await $.ajax({
                        url: "https://reqres.in/api/users?page=" + page_number,
                        "method": "GET",
                        "datatype": "json",
                        success: function (data) {
                            return data.data;
                    }
    });
}

function FillTable(data){
    $("#table-body-id").html("");
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

$( "#prev-button" ).click(function() {
    if(page_number == 2){
        FillTable(page1_data.data);
        page_number = 1;
    }
});

$( "#next-button" ).click(function() {
    if(page_number == 1){
        FillTable(page2_data.data);
        page_number = 2;
    }
});
// on click sync button -> send data to localhost
$( "#sync-button-id" ).click(function() {
    SendPageDataToLocalhost();
});

function SendPageDataToLocalhost(){
    PostToLocalhost(page1_data);
    PostToLocalhost(page2_data);
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
            $("#card-id").hide();
            $("#footer-id").hide();
            $("#loader-id").show(); $("#loader-div").css("margin-top", "30%");
        },
        success: function (response) {
            Swal.fire(
                'Good job!',
                'You sent the pages data!',
                'success'
              )
        },
        complete: function () {
            $("#loader-id").hide(); $("#loader-div").css("margin-top", "0");        
            $("#card-id").show();
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