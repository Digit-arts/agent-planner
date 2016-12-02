var app = angular.module('agent_planner');
app.controller('appController', ['$scope', 'accountService', 'assignmentService', '$uibModal', 'uiCalendarConfig', '$timeout', 'NgTableParams', '$q','contractService','$state',
    function ($scope, accountService, assignmentService, $uibModal, uiCalendarConfig, $timeout, ngTableParams, $q, contractService, $state) {
        var scope = this;

        scope.startDate = [];

        scope.app = {
            home_link: 'app.home',
            title: 'Agent Planner'
        };

        $scope.$watch(function () {
            return accountService.getLoggedInUser();
        }, function () {
            scope.user = accountService.getLoggedInUser();
        });




        scope.events = [
            {
                events: function (start, end, timezone, callback) {
                    assignmentService.getAssignmentsByDate(start.toISOString(), end.toISOString(), function (response) {
                        var events = response.map(function (r) {
                            return {
                                id: r.id,
                                start: r.startDateTime,
                                end: r.endDateTime,
                                title: "Employee Code: " + r.employee.employeeCode + "\r\nAssignment Type: " + r.assignmentType.typeName + "\r\nContract Id: " + r.contractId,
                                assignment: r
                            };
                        });

                        scope.assignmentTable = new ngTableParams(
                        {
                            count: 5
                        },
                        {
                            counts: [5, 10, 25, 50],
                            getData: function () {
                                return $q(function (resolve) {
                                    assignmentService.getAssignmentsByDate(start.format(), end.format(), function (response) {
                                        resolve(response);
                                    });
                                });
                            }
                        });

                        callback(events);
                    });
                }
            }
        ];



        
        





        scope.uiConfig = {
            calendar: {
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,basicDay'
                },
                navLinks: true, // can click day/week names to navigate views
                editable: false,
                eventLimit: false,
                eventClick: function (date, jsEvent, view) {
                    //debugger;

                    scope.editAssignment(date.assignment);
                }
            },

        };

        scope.editAssignment = function (assignment) {
            contractService.getContract(assignment.contractId, function(response) {
                assignment.contract = response;
                $uibModal.open({
                    animation: true,
                    templateUrl: "/App/views/assignment/view-assignment.html",
                    controller: "editAssignmentModalController as editAssignmentModalController",
                    resolve: { assignment: assignment }
                });
            });
        };

        scope.refreshCalender = function() {
            $timeout(function() {
                if (uiCalendarConfig.calendars['assignment_calender']) {
                    uiCalendarConfig.calendars['assignment_calender'].fullCalendar('render');
                }
            }, 0);

        };

        scope.logout = function() {
            accountService.deleteToken();
            $state.go("login");
        };
    }
]);


