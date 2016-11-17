var app = angular.module('agent_planner');

app.controller('contractController', [
    'contractService', 'notificationService', '$state', '$stateParams', 'NgTableParams', '$q', 'billingFrequencyTypeService', 'assignmentTypeService', 'contractTypeService', 'employeeService', '$timeout', '$uibModal',
    function (contractService, notificationService, $state, $stateParams, ngTableParams, $q, billingFrequencyTypeService, assignmentTypeService, contractTypeService, employeeService, $timeout, $uibModal) {
        var scope = this;
        scope.$stateParams = $stateParams;
        scope.minContractStartDate = moment();
        scope.contractTable = new ngTableParams(
        {
            count: 5
        },
        {
            counts: [5, 10, 25, 50],
            getData: function (params) {
                return $q(function (resolve) {
                    contractService.getContracts($stateParams.siteId, params.count(), params.page(), function (response) {
                        resolve(response.contractViewModel);
                        params.total(response.contractCount);
                    });
                });
            }
        });

        scope.updateContract = function () {
            contractService.updateContract($stateParams.contractId, scope.contract, function (response) {
                notificationService.success("Contract updated");
                $state.go('sites.contracts.list', { 'siteId': $stateParams.siteId });

            });
        };
        scope.getContract = function () {
            contractService.getContract($stateParams.contractId, function (response) {
                scope.contract = response;
            });
            scope.getBillingFrequencyTypes();
            scope.getContractTypes();
            scope.getAssignmentTypes();
        };
        scope.getBillingFrequencyTypes = function () {
            billingFrequencyTypeService.getBillingFrequencyTypes(function (response) {
                scope.billingFrequencyTypes = response;
            });
        }
        scope.getContractTypes = function () {
            contractTypeService.getContractTypes(function (response) {
                scope.contractTypes = response;
            });
        }
        scope.datePickerOptions = {
            singleDatePicker: true,
            showDropdowns: true
        };
        scope.getAssignmentTypes = function () {
            assignmentTypeService.getAssignmentTypes(function (response) {
                scope.assignmentTypes = response;
            });
        }
        scope.addContract = function (form) {
            scope.contract.siteId = $stateParams.siteId;
            contractService.addContract(scope.contract, function (response) {
                scope.contract = {};
                form.$setPristine();
                notificationService.success("Contract created successfully");
                $state.go('sites.contracts.list', { 'siteId': $stateParams.siteId });
            });
        }

        scope.deleteContract = function (contract) {
            var del = function () {
                contractService.deleteContract(contract.id, function () {
                    notificationService.success("Contract deleted successfully");
                    scope.contractTable.reload();
                });
            }
            notificationService.showConfirmationDialog('Confirm delete', 'Are you sure you want to delete this contract?', 'info', del);
        }



        scope.assignToEmployee = function (contract) {

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/App/views/contracts/assign-to-employee.html",
                controller: "assignmentModalController as assignmentModalController",
                resolve: { contract: contract }
            });

            modalInstance.result.then(function () {
                notificationService.success("Contract assigned");
            });
        }

    }
]);


app.controller('assignmentModalController', [
    '$uibModalInstance', "$scope", "employeeService", "assignmentTypeService", "assignmentService", "contract",
    function ($uibModalInstance, $scope, employeeService, assignmentTypeService, assignmentService, contract) {
        var scope = this;
        scope.minAssignmentStartDate = contract.startDate;
        scope.maxAssignmentStartDate = contract.endDate;
        scope.assignment = {
            duration: {}
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

        scope.assign = function () {
            scope.assignment.employeeId = scope.selectedEmployee.id;
            scope.assignment.contractId = contract.id;
            scope.assignment.startDateTime = scope.assignment.duration.startDate.format();
            scope.assignment.endDateTime = scope.assignment.duration.endDate.format();
            assignmentService.saveAssignment(scope.assignment, function (response) {
                $uibModalInstance.close();
            });
        }

        scope.cancel = function () {
            $uibModalInstance.dismiss("cancel");
        };


        scope.getEmployees = function (searchItem) {
            if (searchItem == null || searchItem == '') return;
            employeeService.searchEmployee(searchItem, function (response) {
                scope.employees = response;
            });
        }


    }

]);