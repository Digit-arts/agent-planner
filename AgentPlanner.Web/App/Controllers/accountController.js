var app = angular.module('agent_planner');

app.controller('accountController', [
    'accountService','notificationService','$state',
    function (accountService, notificationService, $state) {
        var scope = this;

        scope.login = function() {
            accountService.login(scope.account.email, scope.account.password, function(response) {
                accountService.setToken(response);
                accountService.getAccountInfo(function (response) {
                    accountService.setLoggedInUser(response);
                });
                notificationService.success("Logged in successfully");
                $state.go('app.home');
            }, function(error) {
                notificationService.error(error.error_description);
            });
        };
    }
]);