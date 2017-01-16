(function () {
    'use strict';

    angular
        .module('lt-angular')
        .factory('ltBestTours', ltBestTours);

    ltBestTours.$inject = ['$http'];

    function ltBestTours($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }
})();