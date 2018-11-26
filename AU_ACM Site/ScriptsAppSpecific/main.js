angular.module("app", ["ngRoute", "ngAnimate", "ui.bootstrap", "ui.grid", "ui.grid.pagination", "ui.grid.selection", "ui.grid.resizeColumns", "ui.grid.moveColumns", "ui.calendar"]).config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "ViewsClient/home.html",
            controller: "homeController",
            controllerAs: "self"
        })
        .when("/events",
        {
            templateUrl: "ViewsClient/events.html",
            controller: "eventsController",
            controllerAs: "self"
        })
        .otherwise({
            redirectTo: "/"
        });

    $locationProvider.html5Mode({
        enabled: true,
        requiredBase: true
    });

}]);