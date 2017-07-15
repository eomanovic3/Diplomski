function ocisti() {

    document.getElementById('quantity1').textContent = '';
    document.getElementById('quantity1').value = '';
    document.getElementById('quantity1').innerText = '';
});
/* off-canvas sidebar toggle */
$('[data-toggle=offcanvas]').click(function () {
    $('.row-offcanvas').toggleClass('active');
    $('.collapse').toggleClass('in').toggleClass('hidden-xs').toggleClass('visible-xs');
});