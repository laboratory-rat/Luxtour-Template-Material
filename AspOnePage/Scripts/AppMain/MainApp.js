(function () {
    'use strict';

    angular
        .module('App',
        [
            'ngMaterial',
            'ltConfig',
            'ngRoute',
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

        .controller("FabCtrl", ['$scope', '$window', '$mdDialog', function ($scope, $window, $mdDialog) {
            $scope.UpScrollVisible = false;
            $scope.IsFabOpen = false;

            $scope.OpenMessageDialog = function (ev) {
                var confirm = $mdDialog.prompt()
                    .title('Оставте нам сообщение')
                    .textContent('Или коментарий')
                    .placeholder('Мне очень понравилось')
                    .ariaLabel('Comment')
                    .initialValue('')
                    .targetEvent(ev)
                    .ok('Ok')
                    .cancel('Не сейчас');

                $mdDialog.show(confirm).then(function (result) {
                    //
                }, function () {
                    //
                });
            };

            angular.element($window).bind("scroll", function () {

                var offset = this.pageYOffset;

                if ((offset > 500 && !$scope.UpScrollVisible) || (offset <= 500 && $scope.UpScrollVisible)) {
                    $scope.UpScrollVisible = !$scope.UpScrollVisible;

                    $scope.IsFabOpen = false;
                }

                $scope.$apply();
            })
        }]);

        
})();