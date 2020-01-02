$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var resultado = confirm("Atenção: ao confirmar, a aplicação irá prosseguir com essa operação");

        if (!resultado)
            e.preventDefault();
    });
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
});