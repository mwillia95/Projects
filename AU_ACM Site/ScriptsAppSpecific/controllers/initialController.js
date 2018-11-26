angular.module("app").controller("initialController", ['$scope', 'AppServices','uiCalendarConfig', function ($scope, appServices, uiCalendarConfig) {
    var self = this;

    $scope.SelectedEvent = null;
    var isFirstTime = true;

    $scope.eventItem = {};
    $scope.events = [];
    $scope.eventSources = [$scope.events];

    //Load calendar events from server
    $scope.loadEvents = function () {
        appServices.getEvents().then(function (response) {
            console.log(response.data);
            //$scope.events.slice(0, $scope.events.length);
            for (var i = 0; i < response.data.length; i++) {
                $scope.eventItem = {
                    title: response.data[i].Title,
                    description: response.data[i].Description,
                    start: new Date(Date.parse(response.data[i].StartTime)),
                    end: new Date(Date.parse(response.data[i].EndTime)),
                    stick: true
                };
                $scope.events.push($scope.eventItem);
            }
        });
    };

    $scope.loadEvents();
    console.log($scope.eventSources);

    //configure calendar
    $scope.uiConfig = {
        calendar: {
            height: 600,
            editable: true,
            displayEventTime: true,
            header: {
                left: 'month agendaWeek agendaDay',
                center: 'title',
                right: 'prev,next'
            },
            allDaySlot: false,
            eventClick: function (event) {
                $scope.SelectedEvent = event;
            },
            eventAfterAllRender: function () {
                if ($scope.events.length > 0 && isFirstTime) {
                    //focus first event
                    //uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
                    isFirstTime = false;
                }
            }

        }
    };
}]);