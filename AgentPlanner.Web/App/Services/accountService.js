var app = angular.module('agent_planner');

app.service('accountService', [
    'http', '$sessionStorage', function (http, $sessionStorage) {
        return {
            setToken:function(token) {
                $sessionStorage.token = token;
            },
            deleteToken: function() {
                delete $sessionStorage.token;
            },
            setLoggedInUser: function (user) {
                $sessionStorage.user = user;
            },
            getLoggedInUser: function () {
                return $sessionStorage.user;
            },
            getAccountInfo: function (onSuccess) {
                http.get("/api/account/info", {}, onSuccess);
            },
            login: function (email, password, onSuccess, onError) {
                var data = "grant_type=password&username=" + email + "&password=" + password;
                http.post("/token", data, onSuccess, onError, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
            }
        }
    }
]);