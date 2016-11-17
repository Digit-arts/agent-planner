var app = angular.module('agent_planner');

app.service('clientService', [
    'http', function (http) {
        return {
            saveClient: function (model, onSuccess) {
                http.post("/api/client", model, onSuccess);
            },
            updateClient: function(clientId, model, onSuccess) {
                http.put("/api/client/" + clientId, model, onSuccess);
            },
            getClients: function (pageSize, pageNumber,onSuccess) {
                http.get("/api/client/list/"+pageSize + "/"+pageNumber, {}, onSuccess);
            },
            searchClient: function (searchTerm,onSuccess) {
                http.post("/api/client/search?searchTerm="+searchTerm, {}, onSuccess);
            },
            deleteClient: function (id, onSuccess) {
                http.delete("/api/client/" + id, {}, onSuccess);
            },
            get: function (clientId, onSuccess) {
                http.get("/api/client/" + clientId, {}, onSuccess);
            },
            isCodeExisting: function (code, onSuccess) {
                http.get("/api/client/codecheck/" + code, {}, onSuccess);
            }
        }
    }
]);