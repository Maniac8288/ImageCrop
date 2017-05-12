require(['knockout', 'Components/CropImage/CropImage'], function (ko) {
    // Обрезка фотографий
"use strict";
    ko.components.register('crop-image', {
        viewModel: Components.CropImage,
        template: { require: "text!Components/CropImage/template/template.html" }
    });

    ko.applyBindings();

});
