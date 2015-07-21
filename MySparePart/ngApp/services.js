(function () {

    angular.module('PartApp').factory('PartRequestService', function ($resource, PART_API, PARTREQUEST_API) {
        var PartRequest = $resource(PARTREQUEST_API)

        var _addPartRequest = function () {             // Create new PartRequest
            var newPartRequest = new PartRequest(partRequest);
            return newPartRequest.$save();
        };
        var _getPartRequests = function () {            //get all PartRequests
            return PartRequest.query();
        };

        var _getPartRequest = function (id) {           //get a single PartRequest by id
            return partRequest.get({ id: id })
        };

        var _editPartRequest = function (partRequest) {  // Edit sleected partRequest
            return partRequest.$save();
        };

        var _deletePartRequest = function (id) {           // drop one partRequest by id from DB  **admin utility**
            return PartRequest.remove({ id: id }).$promise;
        };

        return {
            addPartRequest: _addPartRequest,
            getPartRequests: _getPartRequests,
            getPartRequest: _getPartRequest,
            editPartRequest: _editPartRequest,
            deletePartRequest: _deletePartRequest, // drop one part from DB  **admin utility**
        };
    });

    angular.module('PartApp').factory('PartService', function ($resource, PART_API) {
        var Part = $resource(PART_API);

        var _addPart = function (part) {                // Create new Part
            var newPart = new Part(part);
            return newPart.$save();
        };

        var _getParts = function () {                   // Get all Parts
            return Part.query();
        };

        var _getPart = function (id) {                  // Get single part from id
            return Part.get({ id: id })
        };

        var _editPart = function (part) {               // Edit sleected part
            return part.$save();
        };

        var _clientDeletePart = function (part) {           // client delete only sets Ishidden && IsDeleted to true
            part.PartIsHidden = true;
            part.PartIsDeleted = true;
            return part.$save();
        };

        var _deletePart = function (id) {           // drop one part from DB  **admin utility**
            return Part.remove({ id: id }).$promise;
        };

        var _removeIsDeleted = function () {   // drop all IsDeleted == true  **admin utility**
            //$http.get("/api/parts/removeIsDeleted")
            //    .success(function (data) { alert(data)})
            //    .error(function(){alert("fail")});

            return Part.remove().$promise;
            // alert("fail");
            // return parts.$save;
        };

        return {
            addPart: _addPart,
            addPart: _addPart,
            getParts: _getParts,
            getPart: _getPart,
            editPart: _editPart,
            removeIsDeleted: _removeIsDeleted,      // drop all IsDeleted == true  **admin utility**
            deletePart: _deletePart,                // drop one part from DB  **admin utility**
            clientDeletePart: _clientDeletePart    // set IsHidden and Isdeleted == true
        };
    });

})();