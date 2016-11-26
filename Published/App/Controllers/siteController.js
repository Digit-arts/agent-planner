var app = angular.module('agent_planner');
app.controller('siteController', ['siteService', 'notificationService', 'NgTableParams', '$q', 'clientService', 'employeeTypeService', 'siteEmployeeTypeService', '$state', '$stateParams',
    function (siteService, notificationService, ngTableParams, $q, clientService, employeeTypeService, siteEmployeeTypeService, $state, $stateParams) {
        var scope = this;

        scope.$stateParams = $stateParams;

        scope.viewby = 10;
        scope.currentPage = 4;
        scope.itemsPerPage = scope.viewby;
        scope.maxSize = 5; //Number of pager buttons to show

        scope.saveSite = function (form) {
            scope.site.clientId = scope.selectedClient.id;
            scope.site.siteEmployeeTypes = scope.site.selectedEmployeeTypesIds.map(function (id) {
                return { employeeTypeId: id };
            });
            siteService.saveSite(scope.site, function (response) {
                notificationService.success("Site created successfully");               
            });
        }


        scope.getSites = function () {
            siteService.getSites(scope.itemsPerPage, scope.currentPage, function (response) {
                scope.sites = response.siteViewModels;
                scope.totalItems = response.siteCount;
            });
        }
        scope.getClients = function (searchItem) {
            if (searchItem == '' || searchItem == undefined)return;
            clientService.searchClient(searchItem, function (response) {
                scope.clients = response;
            });
        }
        scope.siteTable = new ngTableParams(
            {
                count: 5
            },
            {
                counts: [5, 10, 25, 50],
                getData: function (params) {
                    return $q(function (resolve) {
                        siteService.getSites(params.count(), params.page(), function (response) {
                            resolve(response.siteViewModels);
                            params.total(response.employeeCount);
                        });
                    });
                }
            });

        scope.deleteSite = function (site) {
            var del = function () {
                siteService.deleteSite(site.id, function () {
                    notificationService.success("Site deleted successfully");
                    scope.siteTable.reload();
                });
            }
            notificationService.showConfirmationDialog('Confirm delete', 'Are you sure you want to delete this site?', 'info', del);
        }

        scope.getSite = function (siteId) {
            siteService.get(siteId, function (response) {
                scope.site = response;
                scope.getSiteClient(response.clientId);
                scope.getSelectedEmployeeTypes(siteId);
            });
        };

        scope.updateSite = function () {
            scope.site.clientId = scope.selectedClient.id;

            scope.site.siteEmployeeTypes = scope.site.selectedEmployeeTypesIds.map(function (id) {
                return { employeeTypeId: id };
            });

            siteService.updateSite($stateParams.siteId, scope.site, function (response) {
                notificationService.success("Site updated");
                $state.go("sites.list");
            });
        };

        scope.getSiteClient = function(clientId) {
            clientService.get(clientId, function(response) {
                scope.selectedClient = response;
            });
        };

        scope.validateCode = function (code) {
            return $q(function (resolve, reject) {
                siteService.isCodeExisting(code, function (response) {
                    if (response === false) {
                        resolve();
                        return;
                    }
                    reject();
                });
            });
        };


        scope.getEmployeeTypes = function() {
            employeeTypeService.getEmployeeTypes(function(response) {
                scope.employeeTypes = response;
            });
        };


        scope.getSelectedEmployeeTypes = function(siteId) {
            siteEmployeeTypeService.getSiteEmployeeTypes(siteId, function(response) {
                scope.site.selectedEmployeeTypesIds = response.map(function (i) {
                    return { id: i.employeeTypeId, name: i.employeeTypeViewModel.name }
                });
            });
        }
    }
]);