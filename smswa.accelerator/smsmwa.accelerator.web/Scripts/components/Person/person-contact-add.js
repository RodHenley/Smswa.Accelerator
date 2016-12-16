define(['knockout', 'text!./person-contact-add.html', 'komapping', 'api', 'reference', 'models/addContact'],
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

            this.referenceTypes = [reference.contactTypes.WorkEmail, reference.contactTypes.PersonalEmail, reference.contactTypes.WorkPhone, reference.contactTypes.PersonalPhone];
            this.selectedType = ko.observable();

            function post() {
                if (!self.model.validation.validate()) {
                    alert(self.model.validation.warnings[0]);
                    return;
                }

                var data = ko.mapping.fromJS(self.data);
                data.contactTypeId = ko.unwrap(self.selectedType).id;
                api.post('/person/addcontact/' + self.id, data)
                    .done(function(result) {
                        self.posted(true);
                    });
            }

            
        }


    });
