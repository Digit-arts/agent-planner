var app = angular.module('agent_planner');

app.service('employeeService', [
    'http', function (http) {
        return {
            saveEmployee: function (model, onSuccess) {
                http.post("/api/employee", model, onSuccess);
            },
            updateEmployee: function (employeeId, model, onSuccess) {
                http.put("/api/employee/" + employeeId, model, onSuccess);
            },
            getEmployees: function (pageSize, pageNumber, onSuccess) {
                http.get("/api/employee/list/" + pageSize + "/" + pageNumber, {}, onSuccess);
            },
            deleteEmployee: function (id, onSuccess) {
                http.delete("/api/employee/" + id, {}, onSuccess);
            },
            get: function (employeeId, onSuccess) {
                http.get("/api/employee/" + employeeId, {}, onSuccess);
            },
            isCodeExisting: function (code, onSuccess) {
                http.get("/api/employee/codecheck/" + code, {}, onSuccess);
            },
            searchEmployee: function (searchTerm,onSuccess) {
            http.post("/api/employee/search?searchTerm="+searchTerm, {}, onSuccess);
        }
        }
    }
]);