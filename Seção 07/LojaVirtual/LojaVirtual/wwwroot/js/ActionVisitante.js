$(document).ready(function () {
    MoverScrollOrdenacao();
    MudarOrdenacao();
});

function MoverScrollOrdenacao() {
    var hash = window.location.hash;

    //Verifica se existe o fragmento (#) na url da página
    var existeHash = hash != null && hash.length > 0 && hash == "#posicao-produto"

    if (existeHash) {
        window.scrollBy(0, 515);
    }
}

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
        var urlComParametros = url + "?pagina" + pagina + "&pesquisa=" + pesquisa + "&ordenacao=" + ordenacao + "#posicao-produto";
        //alert(urlComParametros);
        //URL - /Home/Index?pagina=&pesquisa=&ordenacao=
        window.location.href = urlComParametros;
    });
}