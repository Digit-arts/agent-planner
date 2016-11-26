'use strict';
angular.module('agent_planner').factory('httpInterceptorService', ['$q', '$injector', '$location', '$sessionStorage',
    function ($q, $injector, $location, $sessionStorage) {

        var authInterceptorServiceFactory = {};

        var request = function (config) {

            config.headers = config.headers || {};

            var authData = $sessionStorage.token;
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.access_token;
            }
            config.headers['X-Requested-With'] = 'XMLHttpRequest';
            return config;
        }

        var responseError = function (rejection) {
            if (rejection.status === 401) {
                delete $sessionStorage.token;
                $location.path('/login');
            }
            return $q.reject(rejection);
        }

        authInterceptorServiceFactory.request = request;
        authInterceptorServiceFactory.responseError = responseError;

        return authInterceptorServiceFactory;
    }]);