(function () {
    'use strict';

    var HOST = 'http://luxtour.online';

    angular.module('ltConfig', [
        'ngMaterial'
    ])
        .config(function ($mdThemingProvider) {
            $mdThemingProvider.theme('default')
                .primaryPalette('indigo')
                .accentPalette('light-blue');
        })

        // Factories //

        .factory("$ltBestTour", function ($http) {

            return function (page = 1, count = 10, language = 'en') {
                if (page < 1)
                    page = 1;

                if (count < 1)
                    count = 10;

                var query = HOST + '/api/tour?page=' + page + '&count=' + count + '&language=' + language;

                return $http.get(query);
            }
        })
        .factory('$tourOrder', function () {
            return function (id, language = 'ru') {
                var query = HOST + '/' + language + '/Home/Order/' + id;
                return query;
            }
        })



})();