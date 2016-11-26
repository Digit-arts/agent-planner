var app = angular.module('agent_planner');

app.service('paymentMethodService', [
    'http', function (http) {
        return {
            getPaymentMethods: function (onSuccess) {
                http.get("/api/paymentMethod/list/", {}, onSuccess);
            },
            get: function(paymentMethodId, onSuccess) {
                http.get("/api/paymentMethod/" + paymentMethodId, {}, onSuccess);
            }
        }
    }
]);