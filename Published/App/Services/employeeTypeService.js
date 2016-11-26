var app = angular.module('agent_planner');

app.service('employeeTypeService', [
    'http', function (http) {
        return {
            getEmployeeTypes: function (onSuccess) {
                http.get("/api/employeeType/all/", {}, onSuccess);
            }
        }
    }
]);