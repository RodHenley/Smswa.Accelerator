define([], function () {
    'use strict';

    function module() {

        this.addressTypes = {
            Unknown: { id: 0, display: '' },
            Home: { id: 1, display: 'Home' },
            Postal: { id: 2, display: 'Postal' },
            Work: { id: 3, display: 'Work' }
        };

        this.contactTypes = {
            Unknown: { id: 0, display: '' },
            WorkEmail: { id: 1, display: 'Work Email' },
            PersonalEmail: { id: 2, display: 'Personal Email' },
            WorkPhone: { id: 3, display: 'Work Phone' },
            PersonalPhone: { id: 4, display: 'Personal Phone' }
        };

    }

    return new module();
})