(function () {
    'use strict';

    var tours_api = 'http://luxtour.online/api/tour';

    angular
        .module('App')
        .controller('HomeCtrl', ContentCtrl_Index);

    function ContentCtrl_Index($scope, $http) {
        $scope.title = 'ContentCtrl_Index';

        $scope.ToursData = null;

        $scope.SliderData = [
            { src: 'http://d1g4jc1lxwrbex.cloudfront.net/images/clouds1024.png' },
            { src: 'http://d1g4jc1lxwrbex.cloudfront.net/images/clouds1024.png' },
            { src: 'http://d1g4jc1lxwrbex.cloudfront.net/images/clouds1024.png' },
            { src: 'http://d1g4jc1lxwrbex.cloudfront.net/images/clouds1024.png' },
        ];

        $scope.LoadTours = function (page = 1, count = 10) {
            var src = tours_api + '?page=' + page + '&count=' + count + '&language=uk';

            $http.get(src)
                .success(function (r) {

                    console.log(r)
                    console.log($scope.SliderData);

                    if (r !== undefined) {
                        $scope.ToursData = r;
                    }
                })
                .error(function (r) {
                    console.log('Error');
                    console.log(r);
                });
        };

        // Init

        $scope.LoadTours();

    }
})();
