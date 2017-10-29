$(document).on("click", "#btnAlterar", function (e) {

    var id = $(this).attr("data-id");
    $("#divModal").html("<div class='modal' id='modalUpdate'></div>");
    $("#modalUpdate").load("Game/ManutencaoGames", id, function () {
        $("#modalUpdate").modal();
    })

});

$(document).on("click", "#btnIncluir", function (e) {

    $("#divModal").html("<div class='modal' id='modalUpdate'></div>");
    $("#modalUpdate").load("Game/ManutencaoGames", "{}", function () {
        $("#modalUpdate").modal();
    })

});

function iniciar() {

    $.ajax({
        type: "GET",
        url: "Game/ListarGames",
        dataType: "html",
        error: function (xhr, status, error) {
            alert(status);
        },
        success: function (json) {
            $("#div-main").html(json);
        }
    });
}

function excluir(codigo) {

    if (!confirm("Deseja realmente excluiro o registro"))
        return false;

    $.ajax({
        type: "GET",
        url: "Game/ExcluirGame",
        data: { codigo: codigo },
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

function Salvar() {
    var codigo = $("#hdnCodigo").val();
    var nome = $("#txtNome").val();
    var data = JSON.stringify({ codigo: codigo, nome: nome });

    $.ajax({
        type: "POST",
        url: "Game/Salvar",
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