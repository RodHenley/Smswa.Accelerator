require.config({
    baseUrl: '/Scripts',
    paths: {
        text: '../node_modules/requirejs-text/text',
        knockout: '../node_modules/knockout/build/output/knockout-latest',
        komapping: '../node_modules/knockout-mapping/dist/knockout.mapping',
        bootstrap: '../node_modules/boostrap/dist/js/bootstrap',
        jquery: '../node_modules/jquery/dist/jquery',
        lodash: '../node_modules/lodash/lodash',
        api: 'services/api',
        path: 'services/path',
        reference: 'services/reference',
        validation: 'services/validation'
    },
    shim: {
        bootstrap: {
            deps: ["jquery"]
        }
    },
    waitSeconds: 15
});
