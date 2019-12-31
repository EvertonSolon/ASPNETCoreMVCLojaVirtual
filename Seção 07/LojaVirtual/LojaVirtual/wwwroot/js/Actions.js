$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Atenção: ao confirmar, a aplicação irá prosseguir com essa operação");

        if (!resultado)
            e.preventDefault();
    });
});