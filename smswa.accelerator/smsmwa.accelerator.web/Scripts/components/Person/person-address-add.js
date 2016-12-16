define(['knockout', 'text!./person-address-add.html', 'komapping', 'api', 'reference', 'models/addAddress'],
    function (ko, template, komapping, api, reference, model) {
        'use strict';

        ViewModel.prototype.dispose = function () {
            //cleanup if necessary, called when removed from the ko binding context
        };

        return {
            viewModel: ViewModel,
            template: template
        };

        function ViewModel(params) {
            var self = this;
            this.params = params;
            this.id = params.data.id;
            this.posted = ko.observable(false);
            this.save = post;

            this.model = new model();

            this.data = this.model.boundModel;

            this.referenceTypes = [reference.addressTypes.Home, reference.addressTypes.Postal, reference.addressTypes.Work];
            this.selectedType = ko.observable();

            function post() {
                if (!self.model.validation.validate()) {
                    alert(self.model.validation.warnings[0]);
                    return;
                }

                var data = ko.mapping.fromJS(self.data);
                data.addressTypeId = ko.unwrap(self.selectedType).id;
                api.post('/person/addaddress/' + self.id, data)
                    .done(function(result) {
                        self.posted(true);
                    });
            }

            
        }


    });
