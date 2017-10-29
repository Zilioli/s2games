function iniciar() {

    $.ajax({
        type: "GET",
        url: "Home/Listar",
        dataType: "html",
        error: function (xhr, status, error) {
            alert(status);
        },
        success: function (json) {
            $("#div-main").html(json);
        }
    });
}

$(document).on("click", "#btnIncluir", function (e) {

    $("#divModal").html("<div class='modal' id='modalUpdate'></div>");
    $("#modalUpdate").load("Home/EmprestarGame", "{}", function () {
        $("#modalUpdate").modal();
    })

});

function Salvar() {

    var codigoGame = $("#cboGames").val();
    var codigoAmigo = $("#cboAmigos").val();

    if (codigoAmigo == 0 || codigoGame == 0) {
        alert("É necessário informar o Jogo e o Amigo.");
        return false;
    }

    var data = JSON.stringify({ codigoGame: codigoGame, codigoAmigo: codigoAmigo });

    $.ajax({
        type: "POST",
        url: "Home/Emprestar",
        data: data,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (xhr, status, error) {
            alert(status);
        },
        success: function (json) {
            iniciar();
            $("#modalUpdate").modal('hide');
        }
    });
}

function devolver(codigoAmigo, codigoGame) {

    if (!confirm("Deseja realizar devoução?"))
        return false;

    var data = JSON.stringify({ codigoAmigo: codigoAmigo, codigoGame: codigoGame });

    $.ajax({
        type: "POST",
        url: "Home/Devolver",
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        error: function (xhr, status, error) {
            alert(status);
        },
        success: function (json) {
            iniciar();
        }
    });
}