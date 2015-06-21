function createButton() {
    var products = document.getElementsByClassName("product_list");
    var element = document.createElement("DIV");
    element.setAttribute("class", "new");
    element.innerHTML = '<div id="close" type="submit" value=""/>';
    products.innerHTML = element;
    document.body.appendChild(element);
}

/*$(function createButton() {
    $('div').on('click', function createButton() {
        var r = $('<div class="square" onclick="createButton()"></div>');
        $("product_list").append(r);
    });
});*/

function myButton() {
    var element = ('<div class="new"><div id="close" type="submit" value=""/></div>');
    document.body.appendChild(element);
}