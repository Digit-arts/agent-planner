var app = angular.module('agent_planner');
app.controller('employeeController', ['employeeService', 'employeeTypeService', 'notificationService', 'FileUploader', '$scope', '$sessionStorage', 'NgTableParams', '$q', '$state','$stateParams','blockUI',"$timeout",
    function (employeeService, employeeTypeService, notificationService, fileUploader, $scope, $sessionStorage, ngTableParams, $q, $state, $stateParams, blockUI, $timeout) {
        var scope = this;
        scope.$stateParams = $stateParams;


        scope.employee = $sessionStorage.employee || {
            profilePicture: 'http://icons.iconarchive.com/icons/paomedia/small-n-flat/1024/user-male-icon.png',
            dateOfBirth: moment()
        };

        
        scope.employeeTable = new ngTableParams(
        {
            count: 5
        },
        {
            counts:[5,10,25,50],
            getData: function(params) {
                return $q(function(resolve) {
                    employeeService.getEmployees(params.count(), params.page(), function (response) {
                        resolve(response.employees);
                        params.total(response.employeeCount);
                    });
                });
            }
        });

        scope.profilePictureUploader = new fileUploader({
            url: "/api/resource",
            autoUpload: true,
            removeAfterUpload: true,
            queueLimit: 1,
            onCompleteItem: function (file, response) {
                $scope.$apply(function () {
                    scope.employee.photoResouceId = response.id;
                    scope.employee.profilePicture = response.url;
                    scope.profilePictureUploader.clearQueue();
                });
                var myBlockUi = blockUI.instances.get('profile_picture');
                myBlockUi.stop();
            },
            onErrorItem: function () {
                notificationService.error('An error occurred during file upload');
            },
            onBeforeUploadItem: function() {
                var myBlockUi = blockUI.instances.get('profile_picture');
                myBlockUi.start();
            }
        });

        scope.getEmployeeTypes = function () {
            employeeTypeService.getEmployeeTypes(function (response) {
                scope.employeeTypes = response;
            });
        }

        $scope.$watch(function () {
            return scope.employee;
        }, function () {
            $sessionStorage.employee = scope.employee;
        });

        scope.employeeDateOfBirthOptions = {
            singleDatePicker: true,
            showDropdowns: true
        };
        scope.deleteEmployee=function(employee) {
            var del = function () {
                employeeService.deleteEmployee(employee.id, function () {
                    notificationService.success("Employee deleted successfully");
                    scope.employeeTable.reload();
                });
            }
            notificationService.showConfirmationDialog('Confirm delete', 'Are you sure you want to delete this employee?', 'info', del);
        }


        scope.saveEmployee = function (form) {
            employeeService.saveEmployee(scope.employee, function (response) {
                scope.employee = {
                    profilePicture: 'http://icons.iconarchive.com/icons/paomedia/small-n-flat/1024/user-male-icon.png'
                };
                form.$setPristine();
                notificationService.success("Employee created successfully");
            });
        };

        scope.getEmployee = function(employeeId) {
            employeeService.get(employeeId, function(response) {
                scope.employee = response;
                scope.employee.profilePicture = response.photo.url;
            });
        };

        

        scope.updateEmployee = function() {
            employeeService.updateEmployee($stateParams.employeeId, scope.employee, function(response) {
                notificationService.success("Employee updated");
                $state.go("employees.list");
            });
        };

       
        scope.validateCode = function (code) {
            return $q(function (resolve, reject) {
                employeeService.isCodeExisting(code, function (response) {
                    if (response === false) {
                        resolve();
                        return;
                    }
                    reject();
                });
            });
        };

    }
]);