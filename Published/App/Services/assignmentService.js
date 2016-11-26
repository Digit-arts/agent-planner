var app = angular.module('agent_planner');

app.service('assignmentService', [
    'http', function (http) {
        return {
            saveAssignment: function (model, onSuccess) {
                http.post("/api/assignment/", model, onSuccess);
            },
            getAssignments: function(contractId, pageSize, pageNumber, onSuccess) {
                http.get("/api/assignment/list/" + contractId + "/" + pageSize + "/" + pageNumber, {}, onSuccess);
            },
            updateAssignment: function (assignmentId, model, onSuccess) {
                http.put("/api/assignment/" + assignmentId, model, onSuccess);
            },
            deleteAssignment: function(id, onSuccess) {
                http.delete("/api/assignment/" + id, {}, onSuccess);
            },
            isCodeExisting: function(code, onSuccess) {
                http.get("/api/assignment/codecheck/" + code, {}, onSuccess);
            },
            getAssignmentsByDate: function(startDate, endDate, onSuccess) {
                http.get("/api/assignment/list", {
                    startDate: startDate,
                    endDate: endDate
                }, onSuccess);
            }
        }
    }
]);