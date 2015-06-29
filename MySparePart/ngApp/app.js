(function () {

    angular.module('PartApp', [ 'ngResource','ngRoute', 'ui.bootstrap'])
        .constant('PART_API', '/api/parts/:id')
        .config(function ($routeProvider, $locationProvider, $resourceProvider) {
            $routeProvider
            .when('/', {
                controller: 'PartListController',
                templateUrl: '/ngPartials/listParts.html',
                controllerAs: 'main'
            })
                .when('/addPart', {
                    controller: 'PartListController',
                    templateUrl: '/ngPartials/addPart.html',
                    controllerAs: 'main'
                })

                //.when('/deletePart/:id', {
                //    controller: 'PartDeleteController',
                //    templateUrl: '/ngPartials/deletePart.html',
                //    controllerAs: 'main'
                //})
                //.when('/editPart/:id', {
                //    controller: 'PartEditController',
                //    templateUrl: '/Partials/editPart.html',
                //    controllerAs: 'main'
                //})
                //.when('/loginPage', {
                //    controller: 'LoginController',
                //    templateUrl: '/Partials/loginPage.html',
                //    controllerAs: 'main'
                //})

            .otherwise({ redirectTo: '/' });

            $locationProvider.html5Mode(true);


        });

})();