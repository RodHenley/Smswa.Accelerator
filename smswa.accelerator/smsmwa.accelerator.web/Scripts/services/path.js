define(['lodash'], function(_) {
    
    function module() {

        function last() {
            var path = window.location.pathname;
            var list = path.split("/");
            return _.last(list);
        }

        return {
            last: last
        }

    }

    return new module();

});