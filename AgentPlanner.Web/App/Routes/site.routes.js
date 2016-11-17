app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('sites', {
                url: "/sites",
                templateUrl: "/app/views/common/app.html",
                controller: 'appController as appController',
                'abstract': true
            })
            .state('sites.new', {
                url: "/new",
                templateUrl: "/app/views/site/add-site.html",
                controller: 'siteController as siteController'
            })
             .state('sites.edit', {
                 url: "/edit/:siteId",
                 templateUrl: "/app/views/site/edit-site.html",
                 controller: 'siteController as siteController'
             })
            .state('sites.list', {
                url: "/sites-list",
                templateUrl: "/app/views/site/sites-list.html",
                controller: 'siteController as siteController'
            });
    }]);