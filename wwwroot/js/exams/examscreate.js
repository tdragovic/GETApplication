let clickedOptionIndex;
let clickedOptionSubjectId;
let grade;
let dateExam;

let indexOk = false;
let subjectOk = false;
let gradeOk = false;
let dateExamOk = false;
document.getElementById('btnSaveExam').disabled = true;

document.getElementById("selectedIndexNumber").addEventListener("change", event => {
    clickedOptionIndex = event.target.value;
    if (clickedOptionIndex == '') {
        document.getElementById('indexDanger').innerHTML = "Not a valid value";
        indexOk = false;
    } else {
        document.getElementById('indexDanger').innerHTML = "";
        indexOk = true;
    } 
    checkIfAllOk();
    console.log(clickedOptionIndex);
});

document.getElementById("selectedSubjectId").addEventListener("change", event => {
    clickedOptionSubjectId = event.target.value;
    if (clickedOptionSubjectId == '') {
        document.getElementById('subjectDanger').innerHTML = "Not a valid value";
        subjectOk = false;
    } else {
        document.getElementById('subjectDanger').innerHTML = "";
        subjectOk = true;
    }
    checkIfAllOk();
    console.log(clickedOptionSubjectId);
});

document.getElementById("numberGrade").addEventListener("change", event => {
    grade = event.target.value;
    if (grade < 5) {
        grade = 5;
        event.target.value = 5;
    } else if (grade > 10) {
        grade = 10;
        event.target.value = 10;
    }
    gradeOk = true;
    checkIfAllOk();
});

function checkIfAllOk() {
    if (indexOk && subjectOk && gradeOk && dateExamOk) {
        document.getElementById('btnSaveExam').disabled = false;
    } else {
        document.getElementById('btnSaveExam').disabled = true;
    }
}

//document.getElementById("selectedIndexNumber").addEventListener("change", event => {
//    clickedOptionIndex = event.target.value;
//    console.log(clickedOptionIndex);
//});

//document.getElementById("selectedSubjectId").addEventListener("change", event => {
//    clickedOptionSubjectId = event.target.value;
//    console.log(clickedOptionSubjectId);
//});

document.getElementById("datetimeExamDate").addEventListener("change", event => {
    dateExam = event.target.value;
    dateExamOk = true;
    checkIfAllOk();
    console.log(dateExam);
});

//document.getElementById("numberGrade").addEventListener("change", event => {
//    grade = event.target.value;
//    console.log(grade);
//});

document.getElementById("btnSaveExam").addEventListener("click", event => {

    let data = {
        BrojIndeksa: clickedOptionIndex,
        PredmetId: parseFloat(clickedOptionSubjectId),
        Ocena: parseFloat(grade),
        DatumPolaganja: dateExam,
    };

    let url = "/Exam/Create";
    console.log(JSON.stringify(data));

    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            connection.invoke("GetExams").catch(err => console.log(err.toString())).then(() => {
                window.location.href = './';
            });
        },
        failure: function (response) {
            //console.log(response);
            //alert('f', (response));
        },
        error: function (response) {
            //console.log(response);
            //alert((response));
        }
    });
});