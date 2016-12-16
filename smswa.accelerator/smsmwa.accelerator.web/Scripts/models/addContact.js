define(['knockout', 'validation'], function (ko, validation) {

    var model = function() {
        
        this.model = {
            value: ''
        }
        this.boundModel = ko.mapping.fromJS(this.model);
        
        this.validation = new validation();
        this.valueValidator = this.validation
            .createItem(this.boundModel.value, "Value")
            .addRequiredFieldValidator();

    }

    return model;
});