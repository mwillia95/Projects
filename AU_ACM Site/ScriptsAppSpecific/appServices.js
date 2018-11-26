angular.module("app").factory("AppServices", [
    '$http', function ($http) {
        return {
            //EventController functions
            getEvents: function () {
                return $http.get("api/AU_ACM_Site/events/getEvents", {
                    cache: true
                });
            }
        };
    }]);