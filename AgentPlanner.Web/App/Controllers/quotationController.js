angular.module('agent_planner')
    .controller('quotationController', [
        '$stateParams',
        'billingFrequencyTypeService',
        'contractTypeService',
        '$uibModal',
        'clientService',
        'quotationService',
        'notificationService',
        function ($stateParams, billingFrequencyTypeService, contractTypeService, $uibModal, clientService, quotationService, notificationService) {
            var scope = this;
            scope.$stateParams = $stateParams;
            scope.minStartDate = moment();
            scope.quotation = {
                duration:{},
                billingRate:0
            };

            var getBillingFrequencyTypes = function() {
                billingFrequencyTypeService.getBillingFrequencyTypes(function(response) {
                    scope.billingFrequencyTypes = response;
                    scope.quotation.billingFrequencyId = 1;
                });
            };

            var getContractTypes = function() {
                contractTypeService.getContractTypes(function(response) {
                    scope.contractTypes = response;
                });
            };

            scope.dateRangeOptions = {
                eventHandlers: {
                    'apply.daterangepicker': function(ev, picker) {
                        scope.quotation.hoursPerDay = [];
                    }
                }
            };

            scope.initNewQuotation = function() {
                getBillingFrequencyTypes();
                getContractTypes();
            };

            scope.addQuotation = function () {
                scope.quotation.siteId = $stateParams.siteId;
                scope.quotation.clientId = scope.selectedClient.id;
                scope.quotation.startDate = scope.quotation.duration.startDate.format();
                scope.quotation.endDate = scope.quotation.duration.endDate.format();
                scope.quotation.totalCost = scope.quotation.totalHours * scope.quotation.billingRate;
                quotationService.addQuotation(scope.quotation, function(response) {
                    notificationService.success('Quotation created successfully');
                    scope.quotation.id = response;
                });
            };

            scope.takeHoursInput = function (form) {
                $uibModal.open({
                    templateUrl: '/app/views/dialogs/QuotationHoursPerDay.html',
                    animate: true,
                    resolve: {
                        quotation: function() {
                            return scope.quotation;
                        }
                    },
                    controller: ['quotation', '$scope', function (quotation, $scope) {
                        $scope.quotation = quotation;
                        $scope.dates = moment().range(quotation.duration.startDate, quotation.duration.endDate).toArray('days').map(function(d) {
                            return {
                                date: d.format("DD/MM/YYYY"),
                                hours: 10
                            };
                        });

                        $scope.save = function() {
                            $scope.$close($scope.dates);
                        }
                    }]
                }).result.then(function (hoursPerDay) {
                    scope.quotation.hoursPerDay = angular.toJson(hoursPerDay);
                    scope.quotation.totalHours = 0;
                    hoursPerDay.forEach(function (d) {
                        scope.quotation.totalHours += d.hours;
                    });
                });
            };

            scope.getClients = function(term) {
                if (term === '' || term == undefined) return;
                clientService.searchClient(term, function (response) {
                    scope.clients = response;
                });
            };

            scope.onClientSelect = function(item) {
                if (item == undefined)return;
                scope.quotation.billingRate = item.hourlyRate;

            };

            scope.getAllQuotationsBySite = function() {
                quotationService.getAllBySite($stateParams.siteId, function(response) {
                    scope.quotations = response;
                });
            };

            scope.export = function(id) {
                window.location.href = "/api/quotation/export/" + id;
            }
        }
    ]);