app.config([
    '$stateProvider', '$urlRouterProvider', function ($stateProvider) {

        $stateProvider
            .state('sites.invoices', {
                url: "/invoices/:siteId",
                template: "<ui-view</ui-view>"
            })
            .state('sites.invoices.list', {
                url: "/list",
                templateUrl: '/app/views/invoice/list.html',
                controller: 'invoiceController as invoiceController'
            });
    }]);