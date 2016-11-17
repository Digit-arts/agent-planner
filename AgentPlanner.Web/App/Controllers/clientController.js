var app = angular.module('agent_planner');
app.controller('clientController', ['clientService', 'notificationService', 'paymentMethodService', 'NgTableParams', '$q', '$state', '$stateParams',
    function (clientService, notificationService, paymentMethodService, ngTableParams, $q, $state, $stateParams) {
        var scope = this;
        scope.viewby = 10;
        scope.currentPage = 4;
        scope.itemsPerPage = scope.viewby;
        scope.maxSize = 5; //Number of pager buttons to show

        scope.selectedPaymentMethod = {};

        scope.$stateParams = $stateParams;

        scope.saveClient = function (form) {
            clientService.saveClient(scope.client, function (response) {
                scope.client = {};
                form.$setPristine();
                notificationService.success("Client created successfully");
            });
        }
        scope.getPaymentMethods = function () {
            paymentMethodService.getPaymentMethods(function (response) {
                scope.paymentMethods = response;
            });
        }
        scope.clientTable = new ngTableParams(
        {
            count: 5
        },
        {
            counts: [5, 10, 25, 50],
            getData: function (params) {
                return $q(function (resolve) {
                    clientService.getClients(params.count(), params.page(), function (response) {
                        resolve(response.clientViewModels);
                        params.total(response.clientCount);
                    });
                });
            }
        });
        scope.deleteClient = function (client) {
            var del = function () {
                clientService.deleteClient(client.id, function () {
                    notificationService.success("Client deleted successfully");
                    scope.clientTable.reload();
                });
            }
            notificationService.showConfirmationDialog('Confirm delete', 'Are you sure you want to delete this client?', 'info', del);
        }

        scope.getClient = function (clientId) {
            clientService.get(clientId, function (response) {
                scope.client = response;
                scope.getClientPaymentMethod(response.paymentMethodId);
                scope.getPaymentMethods();
            });

            
        };

        scope.updateClient = function () {
            clientService.updateClient($stateParams.clientId, scope.client, function (response) {
                notificationService.success("Client updated");
                $state.go("clients.list");
            });
        };

        scope.getClientPaymentMethod = function(paymentMethodId) {
            paymentMethodService.get(paymentMethodId, function(response) {
                scope.selectedPaymentMethod = response.name;
            });
        };

        scope.validateCode = function (code) {
            return $q(function (resolve, reject) {
                clientService.isCodeExisting(code, function (response) {
                    if (response === false) {
                        resolve();
                        return;
                    }
                    reject();
                });
            });
        };
    }
]);