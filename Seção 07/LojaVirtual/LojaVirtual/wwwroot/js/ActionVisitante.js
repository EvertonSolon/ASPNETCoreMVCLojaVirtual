$(document).ready(function () {
    MudarOrdenacao();
});

function MudarOrdenacao() {
    $('#ordenacao').change(function () {
        //TODO - Redirecionar para tela Home/Index passando as QueryStrings da ordenação e mantendo a página e a pesquisa.
        var pagina = 1;
        var pesquisa = "";
        var ordenacao = $(this).val();
        var queryString = new URLSearchParams(window.location.search);

        if (queryString.has("pagina")) {
            pagina = queryString.get("pagina");
        }

        if (queryString.has("pesquisa")) {
            pesquisa = queryString.get("pesquisa");
        }

        //alert("window.location.protocol = " + window.location.protocol);
        //alert("window.location.host = " + window.location.host);
        //alert("window.location.pathname = " + window.location.pathname);

        var url = window.location.protocol + "//" + window.location.host + window.location.pathname;
        var urlComParametros = url + "?pagina" + pagina + "&pesquisa=" + pesquisa + "&ordenacao=" + ordenacao + "#myCarousel";
        //alert(urlComParametros);
        //URL - /Home/Index?pagina=&pesquisa=&ordenacao=
        window.location.href = urlComParametros;
    });
}