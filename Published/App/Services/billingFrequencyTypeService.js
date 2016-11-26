var app = angular.module('agent_planner');

app.service('billingFrequencyTypeService', [
    'http', function (http) {
        return {
            getBillingFrequencyTypes: function (onSuccess) {
                http.get("/api/billingFrequencyType/all/", {}, onSuccess);
            }
        }
    }
]);