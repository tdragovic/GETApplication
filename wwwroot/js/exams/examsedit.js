
let clickedOptionIndexEditForm;
let clickedOptionSubjectIdEditForm;
let gradeEditForm;
let dateEditForm;


let indexOk = true;
let subjectOk = true;
let gradeOk = true;

clickedOptionIndexEditForm = document.getElementById("selectedIndexNumberEditForm").value;
clickedOptionSubjectIdEditForm = document.getElementById("selectedSubjectIdEditForm").value;
gradeEditForm = document.getElementById("numberGradeEditForm").value;
dateEditForm = document.getElementById("datetimeExamDateEditForm").value;

document.getElementById("selectedIndexNumberEditForm").addEventListener("change", event => {
    clickedOptionIndexEditForm = event.target.value;
    if (clickedOptionIndexEditForm == '') {
        document.getElementById('indexDanger').innerHTML = "Not a valid value";
        indexOk = false;
    } else {
        document.getElementById('indexDanger').innerHTML = "";
        indexOk = true;
    }
    checkIfAllOk();
    console.log(clickedOptionIndexEditForm);
});

document.getElementById("selectedSubjectIdEditForm").addEventListener("change", event => {
    clickedOptionSubjectIdEditForm = event.target.value;
    if (clickedOptionSubjectIdEditForm == '') {
        document.getElementById('subjectDanger').innerHTML = "Not a valid value";
        subjectOk = false;
    } else {
        document.getElementById('subjectDanger').innerHTML = "";
        subjectOk = true;
    }
    checkIfAllOk();
    console.log(clickedOptionSubjectIdEditForm);
});

document.getElementById("numberGradeEditForm").addEventListener("change", event => {
    gradeEditForm = event.target.value;
    if (gradeEditForm < 5) {
        gradeEditForm = 5;
        event.target.value = 5;
        gradeOk = true;
    } else if (gradeEditForm > 10) {
        gradeEditForm = 10;
        event.target.value = 10;
        gradeOk = true;
    }
    checkIfAllOk();
    console.log(gradeEditForm);
});

document.getElementById("datetimeExamDateEditForm").addEventListener("change", event => {
    dateEditForm = event.target.value;
    console.log(dateEditForm);

    let id = document.getElementById("examIdEditForm").value;


    let userDataEditForm = {
        IspitId: parseInt(id),
        BrojIndeksa: clickedOptionIndexEditForm,
        PredmetId: parseInt(clickedOptionSubjectIdEditForm),
        Ocena: parseInt(gradeEditForm),
        DatumPolaganja: dateEditForm

    };
    checkIfAllOk();
    console.log(JSON.stringify(userDataEditForm));

});

function checkIfAllOk() {
    if (indexOk && subjectOk && gradeOk) {
        document.getElementById('btnUpdateExam').disabled = false;
    } else {
        document.getElementById('btnUpdateExam').disabled = true;
    }
}

document.getElementById("btnUpdateExam").addEventListener("click", event => {

    let id = document.getElementById("examIdEditForm").value;

    let userDataEditForm = {
        IspitId: parseFloat(id),
        BrojIndeksa: clickedOptionIndexEditForm,
        PredmetId: parseFloat(clickedOptionSubjectIdEditForm),
        Ocena: parseFloat(gradeEditForm),
        DatumPolaganja: dateEditForm
    };

    console.log(JSON.stringify(userDataEditForm));
    $.ajax({
        type: "POST",
        url: "/Exam/Edit",
        data: JSON.stringify(userDataEditForm),
        contentType: "application/json",
        success: function (response) {
            connection.invoke("GetExams").catch(err => console.log(err.toString())).then(() => {
                window.location.href = '../';
            });
            //console.log(response);
        },
        failure: function (response) {
            //alert(response.data);
        },
        error: function (response) {
            //alert(response.data);
        }
    });

});

