﻿$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Atenção: ao confirmar, a aplicação irá prosseguir com essa operação");

        if (!resultado)
            e.preventDefault();
    });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });

    AjaxUploadImagemProduto();
})

function AjaxUploadImagemProduto() {
    $(".img-upload").click(function () {
        $(this).parent().find(".input-file").click();
    });

    $(".input-file").change(function () {
        //Formulário de dados via Javascrip
        var binario = $(this)[0].files[0]; //Para obter o binário do arquivo.
        var formulario = new FormData();

        //O "file" do parâmetro deve ser o mesmo nome do parâmetro do método no controller.
        formulario.append("file", binario);

        //Requisição Ajax enviado ao Formulário
        $.ajax({
            type: "POST",
            url: "/Colaborador/Imagem/Armazenar",
            data: formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro no envio do arquivo");
            },
            sucsesso: function (data) {
                alert("Arquivo enviado com sucesso!" + data.caminho);
            }

        });
    });
}