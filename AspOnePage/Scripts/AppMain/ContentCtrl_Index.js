(function () {
    'use strict';

    var tours_api = 'http://luxtour.online/api/tour';

    angular
        .module('App')
        .controller('HomeCtrl', function ($scope, $ltBestTour, $http) {

            /* Cities */
            $scope.AvaliableCities = [];
            $scope.LoadCities = function () {
                $http.get('/api/cities')
                    .then(function (r) {
                        $scope.AvaliableCities = r.data;
                    });
            };
            $scope.newCity = function (text) {
                var city = {
                    title: text,
                    value: text.toLowerCase(),
                    id: -1,
                    language: 'ru',
                }
                $scope.AvaliableCities.push(city);

                $scope.CitySelected = city;
            };
            $scope.ChangeCity = function (city) {
                if (city === undefined || city === null)
                {
                    $scope.user.city = "";
                }
                else
                {
                    $scope.user.city = city.value;
                }
            };

            /* User */
            $scope.user = {
                name: "",
                city: "",
                message: "",
                email: '',
                complited: false,
                isReady: function () {
                    var u = $scope.user;
                    if (u.name !== "" && u.city !== "" && u.message !== "" &&u.email !== '')
                        return true;
                    return false;
                },
            };
            $scope.SendMessage = function () {
                if (!$scope.user.isReady)
                    return;

                $scope.user.complited = true;

                //$http.post('/api/sendMessage', $scope.user)
                //    .success(function (r) {
                        
                //    })
                //    .error(function (r) {

                //    });
            };

            /* Init methods */
            $scope.LoadCities();

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
        .controller('HotelCtrl', function ($scope, $ltHotels, $mdDialog, $http) {

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

    angular.module('App')
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
