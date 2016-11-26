angular.module('agent_planner')
    .service('quotationService', [
        'http', function(http) {
            return {
                addQuotation: function(model, success) {
                    http.post("/api/quotation/", model, success);
                },
                getAllBySite: function(siteId, success) {
                    http.get("/api/quotation/site/" + siteId, {}, success);
                }
            }
        }
    ]);