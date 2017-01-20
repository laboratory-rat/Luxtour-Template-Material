(function () {
    'use strict';

    angular
        .module('App',
        [
            'ngRoute',
            'ngMaterial',
            'ltConfig',
            'chart.js',
            'angularSmoothscroll',
            'jkAngularCarousel',
            'ngSanitize',
        ])

        .controller("HeaderCtrl",[ '$scope', '$mdDialog',  function ($scope, $mdDialog) {
            $scope.title = 123;
            $scope.originatorEv;


            $scope.OpenMenu = function ($mdOpenMenu, ev) {
                $scope.originatorEv = ev;
                $mdOpenMenu(ev);
            };

            $scope.Init = function () {
                //console.log("Init");
            }
        }])



        
})();