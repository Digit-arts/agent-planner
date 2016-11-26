var app = angular.module('agent_planner');

app.config([
    'NotificationProvider', '$httpProvider', 'blockUIConfig', function (notificationProvider, $httpProvider,blockUIConfig) {
        notificationProvider.setOptions({
            delay: 10000,
            startTop: 20,
            startRight: 10,
            verticalSpacing: 20,
            horizontalSpacing: 20,
            positionX: 'right',
            positionY: 'top'
        });

        $httpProvider.interceptors.push('httpInterceptorService');
        var ignoreUrls = [
            '/api/employee/codecheck',
            '/api/customer/codecheck',
            '/api/site/codecheck'
        ];
        blockUIConfig.requestFilter = function (config) {
            // If the request starts with '/api/quote' ...
            var toReturn = true;

            ignoreUrls.forEach(function(url) {
                if (config.url.indexOf(url) >= 0) {
                    toReturn = false;
                }
            });
            return toReturn;
        };
    }
]);