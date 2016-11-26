app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('app', {
                url: "/app",
                templateUrl: "/app/views/common/app.html",
                controller: 'appController as appController',
                'abstract': true
            })
            .state('app.home', {
                url: "/home",
                templateUrl: "/app/views/home/index.html",
                controller: 'appController as appController'
            });
    }]);