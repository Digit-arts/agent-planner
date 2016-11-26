var app = angular.module('agent_planner');

app.controller('assignmentController', [
    'assignmentService', 'notificationService', '$state', '$stateParams', 'NgTableParams', '$q', '$uibModal', 
    function (assignmentService, notificationService, $state, $stateParams, ngTableParams, $q, $uibModal) {
        var scope = this;
        scope.$stateParams = $stateParams;
        scope.assignmentTable = new ngTableParams(
        {
            count: 5
        },
        {
            counts: [5, 10, 25, 50],
            getData: function (params) {
                return $q(function (resolve) {
                    assignmentService.getAssignments($stateParams.contractId, params.count(), params.page(), function (response) {
                        resolve(response.assignments);
                        params.total(response.assignmentCount);
                    });
                });
            }
        });



        scope.deleteAssignment = function(assignment) {
            var del = function () {
                assignmentService.deleteAssignment(assignment.id, function () {
                    notificationService.success("Employee Unassigned successfully");
                    scope.assignmentTable.reload();
                });
            }
            notificationService.showConfirmationDialog('Confirm Unassign', 'Are you sure you want to unassign this employee?', 'info', del);

        }


        scope.editAssignment = function(assignment) {
            
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/App/views/assignment/edit-assignment.html",
                controller: "editAssignmentModalController as editAssignmentModalController",
                resolve: { assignment: assignment }
            });

            modalInstance.result.then(function () {
                scope.assignmentTable.reload();
                notificationService.success("Contract assignment updated");
            });

        }

    }
]);



app.controller('editAssignmentModalController', [
    '$uibModalInstance', "$scope", "employeeService", "assignmentTypeService", "contractService", "assignmentService", "siteService", "assignment",
    function ($uibModalInstance, $scope, employeeService, assignmentTypeService, contractService, assignmentService, siteService, assignment) {
        var scope = this;
        scope.minAssignmentStartDate = assignment.contract.startDate;
        scope.maxAssignmentStartDate = assignment.contract.endDate;

        scope.assignment = assignment;
        scope.assignment.duration = {
            startDate: assignment.startDateTime,
            endDate: assignment.endDateTime
        };

        

        scope.datePickerOptions = {
            showDropdowns: true,
            timePicker: true,
            locale: {
                format: 'MM/DD/YYYY h:mm A'
            }
        };

        assignmentTypeService.getAssignmentTypes(function (response) {
            scope.assignmentTypes = response;
        });

        

        scope.selectedEmployee = assignment.employee;
        
        scope.modifyAssignment = function () {
            scope.assignment.employeeId = scope.selectedEmployee.id;
            scope.assignment.startDateTime = scope.assignment.duration.startDate.format();
            scope.assignment.endDateTime = scope.assignment.duration.endDate.format();
            assignmentService.updateAssignment(assignment.id, scope.assignment, function (response) {
                $uibModalInstance.close();
            });
        }

        scope.cancel = function () {
            $uibModalInstance.dismiss("cancel");
        };


        scope.getEmployees = function (searchItem) {
            if (searchItem == null || searchItem == '') return;
            employeeService.searchEmployee(searchItem, assignment.contract.siteId, function (response) {
                scope.employees = response;
            });
        }


    }

]);