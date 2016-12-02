var app = angular.module('agent_planner');

app.controller('invoiceController', [
    'invoiceService', 'notificationService', '$state', '$stateParams', 
    function (invoiceService, notificationService, $state, $stateParams) {
        var scope = this;
        scope.$stateParams = $stateParams;
        scope.minContractStartDate = moment();

        scope.getAllInvoiceBySite = function () {
            invoiceService.getInvoices($stateParams.siteId, function (response) {
                scope.invoices = response;
            });
        };

        scope.export = function (id) {
            window.location.href = "/api/invoice/export/" + id;
        }
       
    }
]);

