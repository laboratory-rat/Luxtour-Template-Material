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

                        for (var i = 0; i < r.length; i++) {
                            $scope.Tours.push(r[i]);
                        }

                        if (r.length === count) {
                            page++;
                            $scope.LoadTours(page, count, language);
                        }
                        else {
                            $scope.AllTours = true;
                        }
                    })
                    .error(function (r) { $scope.AllTours = true; });
            };

            $scope.Init = function () {
                if ($scope.isInited)
                    return;

                $scope.isInited = true;
                $scope.LoadTours(1, 2, 'ru');
            }

            //Init
        })
        .controller('HotelCtrl', function ($scope, $ltHotels, $mdDialog) {

            $scope.Data = [];
            $scope.AllLoaded = false;
            $scope.ErrorLoading = false;

            $scope.IsAvaliable = function (h) {
                if (h === undefined || h === null)
                    return '';

                for (var i = 0; i < h.apartments.length; i++) {
                    if (h.apartments[i].enabled === true) {
                        return "Есть свободные номера"
                    }
                }

                return "Нету свбодных мест";
            }

            $scope.Load = function (page = 1, count = 10, language = 'ru', sort = 'desc') {
                if ($scope.AllLoaded)
                    return;

                $ltHotels(page, count, language, sort)
                    .success(function (r) {
                        if (r === undefined)
                        {
                            $scope.AllLoaded = true;
                        }
                        else {
                            for (var i = 0; i < r.length; i++) {
                                $scope.Data.push(r[i]);
                            }

                            if (r.length < count)
                            {
                                $scope.AllLoaded = true;
                            }
                            else {
                                $scope.Load(page++, count, language, sort);
                            }
                        }
                    })
                    .error(function () { $scope.AllLoaded = true; $scope.ErrorLoading = true; });
            };

            // Dialog
            $scope.ShowDialog = function (ev, hotel) {

                $mdDialog.show({
                    controller: DialogController,
                    locals: {
                        Active: hotel,
                    },
                    templateUrl: '/Content/Templates/Template_HotelWindow.html',
                    parent: angular.element(document.body),
                    targetEvent: ev,
                    clickOutsideToClose: true,
                    fullscreen: true // Only for -xs, -sm breakpoints.
                })
                    .then(function (answer) {
                        //
                    }, function () {
                        //
                    });
            };

            //Init
            $scope.Init = function () {
                $scope.Load();
            };
        });

    //Dialog Ctrl
    function DialogController($scope, $mdDialog, Active) {
        $scope.Active = Active;

        function SetActive (h) {
            if (h !== undefined)
                $scope.Active = h;
        }

        $scope.hide = function () {
            $mdDialog.hide();
        };

        $scope.cancel = function () {
            $mdDialog.cancel();
        };

        $scope.answer = function (answer) {
            $mdDialog.hide(answer);
        };
    };

})();
