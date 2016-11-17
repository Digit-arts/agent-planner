var app = angular.module('agent_planner');

app.service('contractTypeService', [
    'http', function (http) {
        return {
            getContractTypes: function (onSuccess) {
                http.get("/api/contractType/all/", {}, onSuccess);
            }
        }
    }
]);