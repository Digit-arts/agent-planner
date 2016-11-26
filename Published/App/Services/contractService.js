var app = angular.module('agent_planner');

app.service('contractService', [
    'http', function (http) {
        return {
            getContracts: function (siteId, pageSize, pageNumber, onSuccess) {
                http.get("/api/contract/list/" + siteId + "/" + pageSize + "/" + pageNumber, {}, onSuccess);
            },
            deleteContract: function (id, onSuccess) {
                http.delete("/api/contract/" + id, {}, onSuccess);
            },
            addContract: function (model, onSuccess) {
                http.post("/api/contract", model, onSuccess);
            },
            getContract: function (contractId, onSuccess) {
                http.get("/api/contract/" + contractId, {}, onSuccess);
            },
            updateContract: function(contractId, model, onSuccess) {
                http.put("/api/contract/" + contractId, model, onSuccess);
            },
            createInvoice: function(contractId, onSuccess) {
                http.get("/api/contract/createinvoice/" + contractId, {}, onSuccess);
            }

        }
    }
]);