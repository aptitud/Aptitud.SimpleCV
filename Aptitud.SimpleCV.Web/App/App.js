var app = angular.module('simpleCV', ['ngResource']);

//This configures the routes and associates each route with a view and a controller
app.config(function ($routeProvider) {
    $routeProvider
        .when('/consultants',
            {
                controller: 'ConsultantIndexController',
                templateUrl: './Views/Consultant/index.html'
            })
        .when('/sales',
            {
                templateUrl: './Views/Sales/index.html'
            })

        .otherwise({ redirectTo: '/consultants' });
});