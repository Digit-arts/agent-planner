var app = angular.module('agent_planner');

app.service('invoiceService', [
    'http', function (http) {
        return {
            getInvoices: function (siteId, onSuccess) {
                http.get("/api/invoice/site/" + siteId, {}, onSuccess);
            }
            
        }
    }
]);