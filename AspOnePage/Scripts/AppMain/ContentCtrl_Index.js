(function () {
    'use strict';

    var tours_api = 'http://luxtour.online/api/tour';

    angular
        .module('App')
        .controller('HomeCtrl', function ($scope, $ltBestTour) {
            $ltBestTour().success(function (r) {
                console.log(r);
            });
        })
        .controller('ToursCtrl', function ($scope, $ltBestTour, $tourOrder) {
            $scope.Tours = [];
            $scope.AllTours = false;
            $scope.Inited = false;

            $scope.ActiveTour = null;

            $scope.SetActive = function (tour = null) {
                if (tour !== undefined) {
                    $scope.ActiveTour = tour;
                }
            };

            $scope.GetTourOrderLink = function (id) {
                return $tourOrder(id);
            };

            $scope.LoadTours = function (page, count, language) {
                if ($scope.AllTours)
                    return;

                $ltBestTour(page, count, language)
                    .success(function (r) {
                        if (r === undefined && r === null) {
                            $scope.AllTours = true;
                            return;
                        }

                        console.log("Loading finished");
                        console.log(r);

                        for (var i = 0; i < r.length; i++){
                            $scope.Tours.push(r[i]);
                        }

                        if (r.length === count)
                        {
                            page++;
                            $scope.LoadTours(page, count, language);
                        }
                        else
                        {
                            $scope.AllTours = true;
                        }
                    })
                    .error(function (r) { $scope.AllTours = true; });
            };

            $scope.Init = function()
            {
                if ($scope.isInited)
                    return;

                $scope.isInited = true;
                $scope.LoadTours(1, 2, 'ru');
            }

            //Init
        });
})();
