/// <reference path="PegarProjetos.js" />
function PegarProjetos() {

    var idCliente = $("#Cliente_Codigo").val();

    $.ajax({
        url: '/OS/PegarProjetos',
        data: { id: idCliente },
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            var json = $.parseJSON(data);

            $('#Projeto_Codigo').empty();
            $('#Projeto_Codigo').append("<option value='null' selected=true>Selecione um valor</option>")
            $.each(json, function (k, item) {

                $('#Projeto_Codigo')
                      .append($("<option value='" + item.Codigo + "'>" + item.Descricao + "</option>"));
            });
        },
        error: function () {
            alert('Ocorreu um erro durante o processamento')
        }
    });
}