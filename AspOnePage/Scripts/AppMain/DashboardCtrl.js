(function () {
    'use strict';

    

    angular
        .module('App')
        .config(function ($routeProvider) {
            var DIR = '/Content/Templates/dashboard_';
            $routeProvider
                .when("/", {
                    templateUrl: DIR + 'main.html',
                    controller: 'MainCtrl',
                })
                .when("/settings", {
                    templateUrl: DIR + 'settings.html',
                    controller: 'SettingsCtrl',
                })
                .when("/users", {
                    templateUrl: DIR + 'users.html',
                    controller: 'UsersCtrl',
                })

        })
        .controller('DashboardCtrl', function ($scope) {

        })
        .controller('MainCtrl', function ($scope) {
            $scope.Chart1Data = [20, 200, 150, 10, 0, 300];
            $scope.Chart1Lables = ["1", "2", "3", "4", "5", "6"];
        })
        .controller('UsersCtrl', function ($scope) {

        })
        .controller('SettingsCtrl', function ($scope) {

        });

})();
