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
                .when("/users/add", {
                    templateUrl: DIR + 'add_user.html',
                    controller: 'AddUserCtrl',
                })

        })
        .controller('DashboardCtrl', function ($scope) {

        })
        .controller('MainCtrl', function ($scope) {
            $scope.Chart1Data = [20, 200, 150, 10, 0, 300];
            $scope.Chart1Lables = ["1", "2", "3", "4", "5", "6"];
        })
        .controller('UsersCtrl', function ($scope) {
            $scope.data = [
                {
                    email: 'oleg.timofeev20@gmail.com',
                    firstName: 'Oleg',
                    secondName: 'Timofeev',
                    tel: '0508837161',
                },
                {
                    email: 'oleg@gmail.com',
                    firstName: 'One',
                    secondName: 'Two',
                    tel: '0508837161',
                },
                {
                    email: 'timofeev20@gmail.com',
                    firstName: 'OlegGG',
                    secondName: 'Timo',
                    tel: '0508837161',
                },
                {
                    email: 'oleg.timofeev20@gmailssss.com',
                    firstName: 'OOOleg',
                    secondName: 'TTTimofeev',
                    tel: '0508837161',
                },

            ];

            $scope.attr = {
                email: '',
                firstName: '',
                secondName: '',
                tel: '',

                clear: function () {
                    $scope.attr.email = '';
                    $scope.attr.firstName = '';
                    $scope.attr.secondName = '';
                    $scope.attr.tel = '';
                }
            }

            $scope.search = function (item) {
                var a = $scope.attr;

                if (a.firstName !== '' && item.firstName.toLowerCase().indexOf(a.firstName.toLowerCase()) === -1)
                    return false;

                if (a.secondName !== '' && item.secondName.toLowerCase().indexOf(a.secondName.toLowerCase()) === -1)
                    return false;

                if (a.tel !== '' && item.tel.toLowerCase().indexOf(a.tel.toLowerCase()) === -1)
                    return false;

                if (a.email !== '' && item.email.toLowerCase().indexOf(a.email.toLowerCase()) === -1)
                    return false;

                return true;
            }
        })
        .controller('AddUserCtrl', function ($scope, $http, $window)
        {
            $scope.data = {
                firstName: '',
                secondName: '',
                email: '',
                tel: '',
                birthday: '',
                birthdayTmp: '',

                password: '',
                confirm: '',

                sendEmail: true,
                generatePassword: false,

                isAgent: true,
                isManager: false,
                isAdministrator: false,

                waiting: false,

                ready: function () {
                    var x = $scope.data;
                    if (x.firstName === '' || x.secondName === '' || x.email === ''
                        || x.tel === '' || x.password === '' || x.confirm === '' )
                        return false;

                    if (x.password !== x.confirm)
                        return false;

                    if (x.isAgent === false && x.isManager === false && x.isAdministrator === false)
                        return false;

                    return true;
                }
            };

            $scope.Push = function ()
            {
                if (!$scope.data.ready())
                    return;

                $scope.data.waiting = true;

                $http.put('/api/user', $scope.data)
                    .success(function (r)
                    {
                        if (r === 'success')
                            $window.location = '#/users';
                        else
                            console.debug(r);

                        $scope.data.waiting = false;
                    })
                    .error(function (r) {
                        console.debug('Error');
                        console.debug(r);

                        $scope.data.waiting = false;
                    })
            }

        })
        .controller('SettingsCtrl', function ($scope) {

        });

})();
