app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('sites.contracts', {
                url: "/contracts/:siteId",
                template: "<ui-view</ui-view>"
            })
            .state('sites.contracts.list', {
                url: "/list",
                templateUrl: "/app/views/contracts/contracts-list.html",
                controller: 'contractController as contractController'
            })
            .state('sites.contracts.edit', {
                url: "/edit/:contractId",
                templateUrl: "/app/views/contracts/edit-contract.html",
                controller: 'contractController as contractController'
            })
            .state('sites.contracts.new', {
                url: "/new/:siteId",
                templateUrl: "/app/views/contracts/add-contract.html",
                controller: 'contractController as contractController'
            })
            .state('sites.contracts.assignedList', {
                url: "/assignedContracts/:contractId",
                templateUrl: "/app/views/assignment/assignment-list.html",
                controller: 'assignmentController as assignmentController'
            });
    }]);