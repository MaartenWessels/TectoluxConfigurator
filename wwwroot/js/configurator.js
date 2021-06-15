var form = document.getElementById('form');
form.addEventListener('change', function () {
    var formData = new FormData(form);
    axios({
        method: 'post',
        url: '/Configurator/GetRoofLight',
        data: formData
    }).then(function (response) {
        document.getElementById('totalprice').innerHTML = response.data.totalPrice;
        document.getElementById('glassLi').innerHTML = 'Glas: ' + response.data.selectedGlassOption.description;
        document.getElementById('blindsLi').innerHTML = 'Zonwering: ' + response.data.selectedBlindsOption.description;
        document.getElementById('lengthLi').innerHTML = 'Lengte: ' + response.data.length + 'mm';
        document.getElementById('widthLi').innerHTML = 'Breedte: ' + response.data.width + 'mm';
        document.getElementById('amountLi').innerHTML = 'Aantal: ' + response.data.amount;
        var price = document.getElementById('price')
        price.innerHTML = response.data.itemPrice;
        var imageUrl = document.getElementById('img');
        imageUrl.src = '/images/' + response.data.imageUrl;
    });
});
var step1 = document.getElementById('step-1');
var step2 = document.getElementById('step-2');
function toggleStep() {
    step1.classList.toggle('display-none');
    step2.classList.toggle('display-none');
}