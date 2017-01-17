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

            return function (page = 1, count = 10, language = 'uk') {
                var query = HOST + '/api/tour?page=' + page + '&count=' + count + '&language=' + language;
                return $http.get(query);
            }
        })
        .factory('$ltHotels', function ($http) {
            return function (page = 1, count = 10, language = 'uk', sort = 'desc') {
                var query = HOST + '/api/hotel?page=' + page + '&count=' + count + '&language=' + language + '&sort=' + sort;
                return $http.get(query);
            }
        })
        .factory('$tourOrder', function () {
            return function (id, language = 'ru') {
                var query = HOST + '/' + language + '/Home/Order/' + id;
                return query;
            }
        })

        //Directives

        .directive('ltHotelRate', function () {
            return {
                restrict: 'AE',
                replace: true,
                scope: {
                    rate: '=',
                    size: '=',
                },
                link: function (scope, elem, attr) {
                    scope.Count = function () {
                        return new Array(scope.rate);
                    }
                },
                template: `
                    <div>
                        <md-icon ng-repeat='r in Count() track by $index' ng-style='{"font-size": size + "px", "line-height": size + "px"}' style='color: #FFEB3B' class='material-icons'>star_rate</md-icon>
                    </div> `,
            }
        })

})();