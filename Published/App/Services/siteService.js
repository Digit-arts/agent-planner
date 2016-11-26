var app = angular.module('agent_planner');

app.service('siteService', [
    'http', function (http) {
        return {
            saveSite: function (model, onSuccess) {
                http.post("/api/site", model, onSuccess);
            },
            updateSite: function (siteId, model, onSuccess) {
                http.put("/api/site/" + siteId, model, onSuccess);
            },
            getSites: function (pageSize, pageNumber, onSuccess) {
                http.get("/api/site/list/" + pageSize + "/" + pageNumber, {}, onSuccess);
            },
            deleteSite: function (id, onSuccess) {
                http.delete("/api/site/" + id, {}, onSuccess);
            },
            isCodeExisting: function (code, onSuccess) {
                http.get("/api/site/codecheck/" + code, {}, onSuccess);
            },
            get: function (siteId, onSuccess) {
            http.get("/api/site/" + siteId, {}, onSuccess);
        }
        }
    }
]);