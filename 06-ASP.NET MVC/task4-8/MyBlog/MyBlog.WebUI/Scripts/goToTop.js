window.onload = function () {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = '/Scripts/jquery-1.8.2.min.js';
    document.getElementsByTagName('head')[0].appendChild(script);

}
goToTop = function () {
    $('body,html').animate({ scrollTop: 0 }, 400);
}