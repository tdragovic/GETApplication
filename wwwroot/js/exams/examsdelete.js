document.getElementById("btnDeleteExam").addEventListener("click", event => {

    let examId = document.getElementById("examId").value;

    $.ajax({
        type: "POST",
        url: "/Exam/Delete/" + examId,
        data: {},
        contentType: "application/json",
        success: function (response) {
            connection.invoke("GetExams").catch(err => console.log(err.toString())).then(() => {
                window.location.href = '../';
            });
            //console.log(response);
        },
        failure: function (response) {
           // alert(response);
        },
        error: function (response) {
            //alert(response);
        }
    });

});