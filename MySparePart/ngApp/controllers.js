(function () {
    
    angular.module('PartApp').controller('PartListController', function ($location, UserService, PartService, $modal) {

        var self = this;
        self.parts = PartService.getParts();
      //  self.User = UserService.getUser();

        // key up search for the main page - not implimented
        self.filterParts = function (parts) {
            if (!self.search) {
                return true;
            };
            return part.name.toLowerCase().startsWith(self.search.toLowerCase()) || part.partNumber.toLowerCase().startsWith(self.search.toLowerCase());
        };

        // 
        self.isAdmin = function () {
            return sessionStorage.getItem('isAdmin')
        };


        //start the login modal with new LoginController
        self.showLogin = function () {
            $modal.open({
                animation: true,
                templateUrl: '/ngPartials/baseModal.html',
                controller: 'LoginController',
                controllerAs: 'modal',
            })
        };

        //start the login modal with new RegisterController
        self.showRegister = function () {
            $modal.open({
                animation: true,
                templateUrl: '/ngPartials/baseModal.html',
                controller: 'RegisterController',
                controllerAs: 'modal',
            })
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
            });
        };

        //start the adminPartsDelete modal with new DeletePartsController
        // Removes all parts from database where IsDeleted is true
        self.adminPartsDelete = function (parts) {
            $modal.open({
                animation: true,
                templateUrl: '/ngPartials/baseDeleteModal.html',
                controller: 'DeletePartsController',
                controllerAs: 'deleteModal',
                resolve: {
                    //parts: function () {
                    //    return parts;
                    //}
                }
            });
        };
    });

    angular.module('PartApp').controller('LoginController', function (UserService, $location, $http, $modal, $modalInstance) {
        var self = this;
        self.template = '/ngPartials/login.html'

        //modal cancel with no action
        self.cancel = function () {
            $modalInstance.close('close');
        };

        self.registerPage = function () {
            $modalInstance.close('close')
            //move to RegisterController
            $modal.open({
                animation: true,
                templateUrl: '/ngPartials/baseModal.html',
                controller: 'RegisterController',
                controllerAs: 'modal',
            });
        };

        self.login = function () {
            //creates the data string to pass to post
            if ((self.login.email != null) && (self.login.password != null)// dont attempt with empty fields
                && (self.template == '/ngPartials/login.html')) {  // dont appempt if we have left login
                self.message = "";
                UserService.login(self.login);  // passes modal.login.email & password
                    setTimeout(function(){
                        if (sessionStorage.getItem('userToken')) {
                            self.message = "Login successful!";
                            setTimeout(function () {
                                self.ok();
                            }, 1000);
                                $modalInstance.dismiss('cancel');
                           
                        }else{
                            self.message = "Authentication failed Please reinput valid credentials.";
                        }
                    }, 3000)
                }
            };
        });

    angular.module('PartApp').controller('RegisterController', function ($location, $http, UserService, $modal, $modalInstance) {

        var self = this;
        self.template = '/ngPartials/register.html';

        //modal cancel with no action
        self.cancel = function () {
            $modalInstance.close('close');
        };

        self.register = function () {
            if (self.template != '/ngPartials/register.html') {
                self.template = '/ngPartials/register.html';
            } else {
                //call off to Services - createUser
                UserService.createUser(self.newUser)
                .then(function () {
                    $modalInstance.dismiss('cancel');
                });
            };
            $location.path('/');
        };
    });

    angular.module('PartApp').controller('MenuController', function ($location, UserService, $http) {
        var self = this;
        self.showLogin = function () {
            return sessionStorage.getItem('userToken');
        };

        self.logout = function () {
            UserService.logout();
            $location.path('/');
        };
    });

    angular.module('PartApp').controller('DeletePartsController', function ($location, PartService, $modalInstance) {
        var self = this;
        self.parts = PartService.getParts();
        self.template = '/ngPartials/adminPartsDelete.html'

        self.deleteYes = function () {
            PartService.removeIsDeleted()
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

    angular.module('PartApp').controller('AddPartController', function ($location, PartService, $modalInstance) {
        var self = this;
        self.template = '/ngPartials/addPartModal.html'

        self.savePart = function () {
            PartService.addPart(self.part)
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

    angular.module('PartApp').controller('DetailViewModalController', function ($location, PartService, PartRequestService, $modal, $modalInstance, id) {
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
            PartService.deletePart(self.part.id)
            .then(function () {
                $modalInstance.dismiss('cancel');
            });
        };

        self.savePartRequest = function () {
            var model = {};
            model.itemId = self.part.id;
            model.ownerEmail = self.part.ownerEmail;

            PartRequestService.addPartRequest(model)

            .then(function () {
                $modalInstance.dismiss('cancel');
            });
        };

        //links to templates
        self.login = function () {
            self.template = '/ngPartials/login.html'
        };

        self.register = function () {
            self.template = '/ngPartials/register.html'
        };

        self.edit = function () {
            self.template = '/ngPartials/editPart.html';
        };
        self.details = function () {
            self.template = '/ngPartials/modalDetails.html';
        };
        self.deletePart = function () {
            self.template = '/ngPartials/deletePart.html';
        };
        self.request = function () {
            self.template = '/ngPartials/requestPart.html';
        };

        self.adminPartDelete = function () {
            self.template = "/ngPartials/adminPartDelete.html";
        };
    });

})();