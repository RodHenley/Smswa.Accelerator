define(['jquery'], function($) {
    'use strict';

    function module() {

        function get(path) {
            return $.getJSON(path);
        }

        function post(path, data) {
            return $.post(path, data);
        }

        return {
            get: get,
            post: post
        };

    }

    return new module();
});