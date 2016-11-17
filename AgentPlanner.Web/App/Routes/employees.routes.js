app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('employees', {
                url: "/employees",
                templateUrl: "/app/views/common/app.html",
                controller: 'appController as appController',
                'abstract': true
            })
            .state('employees.new', {
                url: "/new",
                templateUrl: "/app/views/employee/add-employee.html",
                controller: 'employeeController as employeeController'
            })
            .state('employees.edit', {
                url: "/edit/:employeeId",
                templateUrl: "/app/views/employee/edit-employee.html",
                controller: 'employeeController as employeeController'
            })
            .state('employees.list', {
                url: "/employees-list",
                templateUrl: "/app/views/employee/employees-list.html",
                controller: 'employeeController as employeeController'
            });
    }]);