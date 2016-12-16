define(['knockout', 'validation'], function (ko, validation) {

    var model = function() {
        
        this.model = {
            line1: '',
            line2: '',
            suburb: '',
            postcode: '',
            state: '',
            country: ''
        }
        this.boundModel = ko.mapping.fromJS(this.model);
        
        this.validation = new validation();
        this.line1Validator = this.validation
            .createItem(this.boundModel.line1, "Line 1")
            .addRequiredFieldValidator();

    }

    return model;
});