require.config({
    baseUrl: '/Scripts',
    paths: {
        text: '../node_modules/requirejs-text/text',
        es6: '../node_modules/requirejs-babel/es6',
        babel: '../node_modules/requirejs-babel/babel-5.8.34.min',
        react: '../node_modules/react/dist/react',
        reactDOM: '../node_modules/react-dom/dist/react-dom',
        redux: '../node_modules/redux/dist/redux',
        reduxthunk: '../node_modules/redux-thunk/dist/redux-thunk',
        reactredux: '../node_modules/react-redux/dist/react-redux',
        fetch: '../node_modules/whatwg-fetch/fetch',
        bootstrap: '../node_modules/boostrap/dist/js/bootstrap',
        jquery: '../node_modules/jquery/dist/jquery',
        lodash: '../node_modules/lodash/lodash',
        api: 'services/api',
        path: 'services/path',
        reference: 'services/reference'
    },
    shim: {
        bootstrap: {
            deps: ["jquery"]
        }
    },
    waitSeconds: 15
});
