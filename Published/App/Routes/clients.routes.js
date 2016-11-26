app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('clients', {
                url: "/clients",
                templateUrl: "/app/views/common/app.html",
                controller: 'appController as appController',
                'abstract': true
            })
            .state('clients.new', {
                url: "/new",
                templateUrl: "/app/views/client/add-client.html",
                controller: 'clientController as clientController'
            })
            .state('clients.edit', {
                url: "/edit/:clientId",
                templateUrl: "/app/views/client/edit-client.html",
                controller: 'clientController as clientController'
            })
            .state('clients.list', {
                url: "/clients-list",
                templateUrl: "/app/views/client/clients-list.html",
                controller: 'clientController as clientController'
            });
    }]);