var app = angular.module('agent_planner');
app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/login");

        $stateProvider
            .state('login', {
                url: "/login",
                templateUrl: "/app/views/account/login.html",
                controller: 'accountController as accountController'
            });
    }]);