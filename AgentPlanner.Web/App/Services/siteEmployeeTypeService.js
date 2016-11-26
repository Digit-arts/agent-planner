var app = angular.module('agent_planner');

app.service('siteEmployeeTypeService', [
    'http', function (http) {
        return {
            saveSiteEmployeeTypes: function (siteId, model, onSuccess) {
                http.post("/api/site/employeetypes/" + siteId, model, onSuccess);
            },
             getSiteEmployeeTypes: function (siteId, onSuccess) {
                 http.get("/api/site/employeetypes/" + siteId, {}, onSuccess);
            }
        }
    }
]);