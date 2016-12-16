define(['knockout', 'text!./person-list-page.html', 'api'],
    function (ko, template, api) {

        ViewModel.prototype.dispose = function() {
            //cleanup if necessary, called when removed from the ko binding context
        };

        return {
            viewModel: ViewModel,
            template: template
        }

        function ViewModel(params) {
            var that = this;
            this.params = params;

            load();

            this.loaded = ko.observable(false);

            function load() {
                api.get('/person/getlist')
                    .done(function (result) {
                        that.people = result.people;
                        that.loaded(true);
                    });
            }

        }

        
    });
