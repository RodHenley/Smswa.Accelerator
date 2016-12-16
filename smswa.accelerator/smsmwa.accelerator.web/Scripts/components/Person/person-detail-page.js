define(['knockout', 'text!./person-detail-page.html', 'api'],
    function (ko, template, api) {
        'use strict';

        ViewModel.prototype.dispose = function () {
            //cleanup if necessary, called when removed from the ko binding context
        };


        return {
            viewModel: ViewModel,
            template: template
        };

        function ViewModel(params) {
            var x;
            var that = this;
            this.params = params;
            this.id = params.data.id;
            this.data = params.data;

            load();

            this.loaded = ko.observable(false);

            function load() {
                api.get('/person/getperson/' + that.id)
                    .done(function (result) {
                        that.person = result.person;
                        that.loaded(true);
                    });
            }

        }


    });
