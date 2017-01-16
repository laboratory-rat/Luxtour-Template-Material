(function () {
    'use strict';

    angular
        .module('App',
        [
            'ngMaterial',
            'ltConfig',
            'ngRoute',
            'angular-carousel',
            'angularSmoothscroll',
            'ngSanitize'
        ])

        .controller("HeaderCtrl", function ($scope, $mdDialog) {
            $scope.title = 123;
            $scope.originatorEv;


            $scope.OpenMenu = function ($mdOpenMenu, ev) {
                $scope.originatorEv = ev;
                $mdOpenMenu(ev);
            };

            $scope.Init = function () {
                //console.log("Init");
            }
        })

        .controller("FabCtrl", function ($scope, $window) {
            $scope.UpScrollVisible = false;
            $scope.IsFabOpen = false;

            angular.element($window).bind("scroll", function () {

                var offset = this.pageYOffset;

                if ((offset > 500 && !$scope.UpScrollVisible) || (offset <= 500 && $scope.UpScrollVisible))
                {
                    $scope.UpScrollVisible = !$scope.UpScrollVisible;

                    $scope.IsFabOpen = false;
                }

                $scope.$apply();
            });
        });

        
})();