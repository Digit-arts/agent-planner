angular.module('agent_planner').service('http', ['$http', 'notificationService', function ($http, notificationService) {

    return {
        get: function (url, data, success, error) {
            $http.get(url, { params: data })
                .success(function (response) {
                    if (success) {
                        success(response);
                    }
                })
                .error(function (err) {
                    if (error) {
                        error(err);
                        return;
                    }
                    var msg = 'An unknown error occured';
                    if (err && err.exceptionMessage) {
                        msg = err.exceptionMessage;
                    }
                    else if (err && err.error_description) {
                        msg = err.error_description;
                    }
                    notificationService.error(msg);
                });
        },
        post: function (url, data, success, error, header) {
            $http.post(url, data, header || {})
                .success(function (response) {
                    if (success) {
                        success(response);
                    }
                })
                .error(function (err) {
                    if (error) {
                        error(err);
                        return;
                    }
                    var msg = 'An unknown error occured';
                    if (err && err.exceptionMessage) {
                        msg = err.exceptionMessage;
                    }
                    else if (err && err.error_description) {
                        msg = err.error_description;
                    }
                    notificationService.error(msg);
                });

        },
        put: function (url, data, success, error) {
            $http.put(url, data)
                .success(function (response) {
                    if (success) {;
                        success(response);
                    }
                })
                .error(function (err) {
                    if (error) {
                        error(err);
                        return;
                    }
                    notificationService.error( err.exceptionMessage);
                });
        },
        delete: function (url, data, success, error) {
            $http.delete(url, { params: data })
                .success(function (response) {
                    if (success) {
                        success(response);
                    }
                })
                .error(function (err) {
                    if (error) {
                        error(err);
                        return;
                    }
                    notificationService.error( err.exceptionMessage);
                });
        }
    };

}]);