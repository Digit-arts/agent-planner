var app = angular.module('agent_planner');

app.config([
    '$translateProvider', function ($translateProvider) {
        $translateProvider.preferredLanguage('en');
        $translateProvider.fallbackLanguage('en');
    }
]);