var app = angular.module('agent_planner');

app.service('assignmentTypeService', [
    'http', function (http) {
        return {
            getAssignmentTypes: function (onSuccess) {
                http.get("/api/assignmentType/all/", {}, onSuccess);
            }
        }
    }
]);