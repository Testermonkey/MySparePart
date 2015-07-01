(function () {

    angular.module('PartApp').controller('PartListController', function ($location, PartService, $modal) {

        var self = this;

        self.parts = PartService.getParts();

        //create new part - trying doing this in a modal 
        // look for AddPartController
        //self.addPart = function () {
        //    PartService.addPart(self.newPart)
        //    .then(function () {
        //        $location.path('/');
        //    });
        //};

        // Removes all parts from database where IsDeleted is true
        self.dbPartsRemove = function () {
            PartService.removeIsDeleted(parts)
                .then(function () {
                    $location.path('/');
                });
        };

        // key up search for the main page
        self.filterParts = function (parts) {
            if (!self.search) {
                return true;
            };
            return part.name.toLowerCase().startsWith(self.search.toLowerCase()) || part.partNumber.toLowerCase().startsWith(self.search.toLowerCase());
        };

        //start the details modal with new DetailViewModalController
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
        };


        //start the addPart modal with new AddPartController
        self.addPart = function () {
            $modal.open({
                animation: true,
                templateUrl: '/ngPartials/baseAddModal.html',
                controller: 'AddPartController',
                controllerAs: 'addModal'
                //size: size,
                //resolve: {
                //    id: function () {
                //        return id;
                //    }
                //}

            });
        };
    });

    angular.module('PartApp').controller('AddPartController', function ($location, PartService, $modalInstance) {
        var self = this;
        self.template = '/ngPartials/addPartModal.html'

        self.savePart = function () {
            PartService.addPart(self.newPart)
            .then(function () {
                $modalInstance.dismiss('cancel');
            });
        };

        //currently unused
        self.ok = function () {
            $modalInstance.close('close');
        };
        //modal cancel with no action
        self.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    angular.module('PartApp').controller('DetailViewModalController', function ($location, PartService, $modalInstance, id) {
        var self = this;
        self.part = PartService.getPart(id);
        self.template = '/ngPartials/modalDetails.html'

        //actions

        //currently unused
        self.ok = function () {
            $modalInstance.close('close');
        };
        //modal cancel with no action
        self.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        //edit Part
        self.save = function () {
            PartService.editPart(self.part)
            .then(function () {
                $modalInstance.dismiss('cancel');
            });
        };

        //client delete action - Sets IsDeleted && IsHidden to true
        self.deleteYes = function () {
            PartService.clientDeletePart(self.part)
            .then(function () {
                $modalInstance.dismiss('cancel');
            });
        };

        self.adminPartDeleteYes = function () {
            PartServie.deletePart(self.part.id)
            .then(function () {
                $modalInstance.dismiss('cancel');
            });
        };

        //links to partaials
        self.edit = function () {
            self.template = '/ngPartials/editPart.html';
        };
        self.details = function () {
            self.template = '/ngPartials/modalDetails.html'
        };
        self.deletePart = function () {
            self.template = '/ngPartials/deletePart.html'
        };
        self.request = function () {
            self.template = '/ngpartials/requestPart.html'
        };
        self.adminPartDelete = function () {
            self.template = "/ngPartials/adminPartDelete.html"
        };


    });
})();