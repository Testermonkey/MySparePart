(function () {

    angular.module('PartApp').controller('PartListController', function ($location, PartService, $modal) {

        var self = this;

        self.parts = PartService.getParts();

        self.addPart = function () {
            PartService.addPart(self.newPart).then(function () {
                $location.path('/');
            });
        };

        self.filterParts = function (part) {
            if (!self.search) {
                return true;
            };
            return part.name.toLowerCase().startsWith(self.search.toLowerCase()) || part.partNumber.toLowerCase().startsWith(self.search.toLowerCase());
        };

        self.showDetails = function (id) {
            $modal.open({
                animation: true,
                templateUrl: '/ngPartials/baseModal.html',
                controller: 'DetailViewModalController',
                controllerAs: 'modal',
                //size: size,
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
        }
    });

    angular.module('PartApp').controller('DetailViewModalController', function ($location, PartService, $modalInstance, id) {
        var self = this;
        self.template = '/ngPartials/modalDetails.html'

        self.part = PartService.getPart(id);  //.then(function(a){
        //    debugger;
        //});
        self.ok = function () {
            $modalInstance.close('close');
        };
        self.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        self.edit = function () {
            self.template = '/ngPartials/editPart.html';
        }
    });
})();