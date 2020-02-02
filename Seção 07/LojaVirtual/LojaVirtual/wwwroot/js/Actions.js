$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Atenção: ao confirmar, a aplicação irá prosseguir com essa operação");

        if (!resultado)
            e.preventDefault();
    });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });

    AjaxUploadImagemProduto();
});

function AjaxUploadImagemProduto() {
    $(".img-upload").click(function () {
        $(this).parent().parent().find(".input-file").click();
    });
    $(".btn-imagem-excluir").click(function () {
        var CampoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");
        var BtnExcluir = $(this).parent().find(".btn-imagem-excluir");
        var InputFile = $(this).parent().parent().find(".input-file");

        $.ajax({
            type: "GET",
            url: "/Colaborador/Imagem/Excluir?caminho=" + CampoHidden.val(),
            error: function () {
                //alert("Erro no envio do arquivo");
            },
            success: function (data) {
                Imagem.attr("src", "/img/imagem-padrao.png");
                BtnExcluir.addClass("btn-ocultar");
                CampoHidden.val("");
                InputFile.val("");
            }
        });
    });

    $(".input-file").change(function () {

        //Formulário de dados via Javascrip
        var binario = $(this)[0].files[0]; //Para obter o binário do arquivo.
        var formulario = new FormData();

        //O "file" do parâmetro deve ser o mesmo nome do parâmetro do método no controller.
        formulario.append("file", binario);

        var CampoHidden = $(this).parent().find("input[name=imagem]");
        var Imagem = $(this).parent().find(".img-upload");
        var BtnExcluir = $(this).parent().find(".btn-imagem-excluir");

        //Exibe a imagem de carregamento.
        Imagem.attr("src", "/img/load.gif");
        Imagem.addClass("thumb");

        //Requisição Ajax enviado ao Formulário
        $.ajax({
            type: "POST",
            url: "/Colaborador/Imagem/Armazenar",
            data: formulario,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro no envio do arquivo");
                Imagem.attr("src", "/img/imagem-padrao.png");
                Imagem.removeClass("thumb");
            },
            success: function (data) {
                //alert("Arquivo enviado com sucesso no caminho:" + data.caminho);
                var caminho = data.caminho;
                Imagem.attr("src", caminho);
                Imagem.removeClass("thumb");
                CampoHidden.val(caminho);
                BtnExcluir.removeClass("btn-ocultar");
            }

        });
    });
}