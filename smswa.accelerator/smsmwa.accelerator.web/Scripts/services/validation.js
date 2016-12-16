define(['lodash'], function(_) {
    var Item = function (fieldValue, fieldName) {
        var self = this;
        self.context = {
            value: fieldValue,
            name: fieldName
        };
        self.validating = false;
        self.validators = [];
        self.warnings = [];
        self.isEnabled = true;
        return self;
    };

    Item.prototype.validate = function() {
        var self = this;
        if (!self.isEnabled)
            return true;
        self.validating =true;
        self.warnings = [];

        self.warnings = _.chain(self.validators)
            .map(function (validator) {
                var warning = validator(self.context);
                return warning;
            })
            .reject(function(warning) {
                return warning === null;
            })
            .value();

        self.validating = false;
        return self.warnings.length;
    };

    Item.prototype.addValidator = function (validator) {
        var self = this;
        self.validators.push(validator);
        return self;
    };

    Item.prototype.disable = function () {
        var self = this;
        self.isEnabled(false);
    };

    Item.prototype.enable = function () {
        var self = this;
        self.isEnabled(true);
    };

    function resolveValue(value) {
        if (_.isFunction) {
            return value();
        }
        return value;
    }

    Item.prototype.addRequiredFieldValidator = function (message) {
        var that = this;
        var validator = function (context) {
            if (!resolveValue(context.value)) {
                return message || 'Please provide a value for ' + context.name;
            }
            return null;
        };
        that.validators.push(validator);
        return that;
    };

    var Validation = function () {
        var self = this;
        self.validating = false;
        self.items = [];
        self.subValidations = [];
        self.warnings = [];
        return self;
    };

    Validation.prototype.createItem = function (fieldValue, fieldName) {
        var self = this;
        var item = new Item(fieldValue, fieldName);
        self.items.push(item);
        return item;
    };

    Validation.prototype.addSubValidation = function (validation) {
        var self = this;
        self.subValidations.push(validation);
        return self;
    };

    Validation.prototype.removeSubValidation = function (validation) {
        var self = this;
        self.subValidations = _.filter(self.subValidations, function(value) {
            return value !== validation;
        });
        return self;
    };


    Validation.prototype.validate = function () {
        var self = this;
        self.validating = true;
        var warnings = [];

        self.warnings = _
            .chain(self.items)
            .union(self.subValidations)
            .map(function(item) {
                item.validate();
                return item.warnings;
            })
            .flatten()
            .reject(function(item) {
                return item === null;
            })
            .value();

        self.validating = false;
        return self.warnings.length === 0;
    };

    Validation.prototype.clear = function () {
        var that = this;
        that.warnings = [];
        _.each(that.items, function (item) {
            item.warnings = [];
        });
    };

    return Validation;

})