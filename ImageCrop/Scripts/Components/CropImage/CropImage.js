var Components = Components || {};
(function () {
    Components.CropImage = function (params) {
        var self = this;
        this.CorX = ko.observable();
        this.CorY = ko.observable();
        this.CorW = ko.observable();
        this.CorH = ko.observable();
        this.File = $("#uploadFile");
        this.File.bind({
            change: function () {
                self.CorX(0);
                self.CorY(0);
                self.CorW(0);
                self.CorH(0);
             self.displayFiles(this.files);
                $('#cropbox').Jcrop({
                    onSelect: self.updateCoords.bind(self)
                }, function () {
                    jcrop_api = this;
                });
            }
        });
        return this;
    };
    /**
    * Определяем конструктор
    */
    Components.CropImage.prototype.constructor = Components.CropImage;
    // Создание      изображений
    Components.CropImage.prototype.displayFiles = function (files) {
        $.each(files, function (i, file) {
            // Создание Картинки
            var Image = $('#Image');
            Image.empty();
            var img = $('<img/>').appendTo(Image);
            img.attr('id', 'cropbox');
            // Создаем объект FileReader и по завершении чтения файла, отображаем файл
            var reader = new FileReader();
            reader.onload = (function (aImg) {
                return function (e) {
                    aImg.attr('src', e.target.result);
                };
            })(img);
            // Чтение данных из объекта file
            reader.readAsDataURL(file);
        });
    }
    ///Получение кординат
        Components.CropImage.prototype.updateCoords = function (c) {
        this.CorX(c.x);
        this.CorY(c.y);
        this.CorW(c.w);
        this.CorH(c.h);
        };
    /// Отправка данных на сервер
    Components.CropImage.prototype.Send = function () {
        files = document.getElementById('uploadFile').files;
        var formData = new FormData();
        formData.append("file", files[0]);
        formData.append("CorX", this.CorX());
        formData.append("CorY", this.CorY());
        formData.append("CorW", this.CorW());
        formData.append("CorH", this.CorH());
        $.ajax({
            type: "POST",
            url: UrlUploadFile,
            contentType: false,
            processData: false,
            data: formData,
            success: function (result) {
                alert(result);
                $("#Image").empty();
                $("#uploadFile").val("");
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    }
})();
// Константа для отправки изображение на сервер
const UrlUploadFile = '/CropImage/Crop'

