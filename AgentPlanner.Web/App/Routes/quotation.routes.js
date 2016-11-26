app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('sites.quotations', {
                url: "/quotations/:siteId",
                template: "<ui-view</ui-view>"
            })
            .state('sites.quotations.list', {
                url: "/list",
                templateUrl: '/app/views/quotation/list.html',
                controller: 'quotationController as quotationController'
            })
            .state('sites.quotations.new', {
                url: "/new",
                templateUrl: '/app/views/quotation/new.html',
                controller: 'quotationController as quotationController'
            });
    }]);