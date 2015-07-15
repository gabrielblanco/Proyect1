function createButton() {
    var products = document.getElementsByClassName("product_list");
    var element = document.createElement("DIV");
    element.setAttribute("class", "new");
    element.innerHTML = '<div id="close" type="submit" value=""/>';
    products.innerHTML = element;
    document.body.appendChild(element);
}

function myButton() {
    var element = ('<div class="new"><div id="close" type="submit" value=""/></div>');
    document.body.appendChild(element);
}

/*$scope.onFileSelect = function (image) {
    console.log("image selected" + image);
    if (angular.isArray(image)) {
        image = image[0];
    }

    // This is how I handle file types in client side
    if (image.type !== 'image/png' && image.type !== 'image/jpeg') {
        alert('Only PNG and JPEG are accepted.');
        return;
    }

    $scope.uploadInProgress = true;
    $scope.uploadProgress = 0;

    $scope.upload = $upload.upload({
        url: '/upload/image',
        method: 'POST',
        file: image
    }).progress(function (event) {
        $scope.uploadProgress = Math.floor(event.loaded / event.total);
        $scope.$apply();
    }).success(function (data, status, headers, config) {
        $scope.uploadInProgress = false;
        // If you need uploaded file immediately 
        $scope.uploadedImage = JSON.parse(data);
    }).error(function (err) {
        $scope.uploadInProgress = false;
        console.log('Error uploading file: ' + err.message || err);
    });
};

window.onload = function () {
    var form = document.getElementById('uploadForm'),
        imageInput = document.getElementById('img1');

    form.onsubmit = function () {
        var isValid = /\.jpe?g$/i.test(imageInput.value);
        if (!isValid) {
            alert('Only jpg files allowed!');
        }

        return isValid;
    };
};*/