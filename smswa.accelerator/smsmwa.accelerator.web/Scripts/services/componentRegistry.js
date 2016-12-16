define([
    'knockout',
    'lodash',
    'text!components/validation.html',
    // the following explicit references are required for the optimiser - without this requireJs will not pick up the modules as being dependencies as they are only loaded at runtime
    'components/Person/person-list-page',
    'components/Person/person-detail-page',
    'components/Person/person-address-add',
    'components/Person/person-contact-add'
],

function (ko, _, validationTemplate) {
    'use strict';

    var _components = [
        'Person/person-list-page',
        'Person/person-detail-page',
        'Person/person-address-add',
        'Person/person-contact-add'
    ];

    //template only components are html snippets with no viewmodel
    var _templateOnlyComponents = [
        { name: 'empty', config: { template: '<p>This is the empty component</p>' } },
        { name: 'validation', config: { template: validationTemplate } }
    ];

    return {
        register: _registerAllComponents
    };


    function _registerAllComponents() {

        var componentConfigs = _getAllComponents();

        console.log('registering ' + componentConfigs.length + ' components ...');
        _.each(componentConfigs, function (component) {
            console.log('    registering ' + component.name);
            ko.components.register(component.name, component.config);
        });

        console.log('registered ' + componentConfigs.length + ' components');
    }


    function _getAllComponents() {
        var all = _.map(_components, function (name) {
            var parts = name.split('/');
            var componentName = parts[parts.length - 1];
            return { name: componentName, config: { require: 'components/' + name } };
        });
        all = all.concat(_templateOnlyComponents);
        return all;
    }

});
