"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44330/examhub").build();

async function start() {
    try {
        await connection.start();
        getExams();
    } catch (err) {
        console.log(err);
        setTimeout(start, 44330);
    }
};

connection.onclose(start);

start().catch(err => console.log(err));

connection.on("ExamsChanged", list => {
    $('#tblExam').DataTable().destroy();
    refreshTable(list);
});

function getExams() {

    $.ajax({
        type: "POST",
        url: "/Exam/GetAllExams",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //console.log(response);
            refreshTable(response);
        },
        failure: function (response) {
            alert(response.data);
        },
        error: function (response) {
            alert(response.data);
        }
    });
}

function refreshTable(response) {
    $('#tblExam').DataTable({
        bRetrieve: true,
        bLengthChange: false,
        lengthMenu: [[5, 10, -1], [5, 10, "All"]],
        bFilter: false,
        bSort: false,
        bPaginate: false,
        bInfo: false,
        data: response,
        columns: [
            {
                'data': 'ispitId'
            },
            {
                'data': 'brojIndeksa',
            },
            {
                'data': 'student',
            },
            {
                'data': 'nazivPredmeta',
            },
            {
                'data': 'ocena',
            },
            {
                'data': function (data) {
                    let date = data.datumPolaganja.substring(0, 10);
                    return date;
                },
            },
            {
                'render': function (response, type, full, meta) { return '<a class="btn btn-info d-flex align-items-center justify-content-center" href="/Exam/Edit/' + full.ispitId + '">Edit <i class="fa fa-pencil-square-o ml-1" aria-hidden="true"></i> </a>'; }
            },
            {
                'render': function (response, type, full, meta) { return '<a class="btn btn-danger" href="/Exam/Delete/' + full.ispitId + '">Delete <i class="fa fa-trash-o" aria-hidden="true"></i> </a>'; }
            }
        ]
    });

}

