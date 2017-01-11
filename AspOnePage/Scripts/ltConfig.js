(function () {
    'use strict';

    angular.module('ltConfig', [
        'ngMaterial'
    ]).config(function ($mdThemingProvider) {
        $mdThemingProvider.theme('default')
            .primaryPalette('indigo')
            .accentPalette('light-blue');
    });
        
})();