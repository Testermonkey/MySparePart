(function () {

    angular.module('PartApp').factory('PartService', function ($resource, PART_API, $http) {

        var Part = $resource(PART_API);

        
        var _getParts = function () {               // Get all Parts
            return Part.query();
        };

        var _getPart = function (id) {              // Get single part from id
            return Part.get({ id: id })
        };

        var _addPart = function (part) {            // Create new Part
            var newPart = new Part(part);
            return newPart.$save();
        };

        var _editPart = function (part) {           // Edit sleected part
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
            $http.get("/api/parts/removeIsDeleted")
                .success(function (data) { alert(data)})
                .error(function(){alert("fail")});


           // alert("fail");
          // return parts.$save;
        };
     

        return {
            addPart: _addPart,
            getParts: _getParts,
            getPart: _getPart,
            addPart: _addPart,
            editPart: _editPart,
            removeIsDeleted: _removeIsDeleted,      // drop all IsDeleted == true  **admin utility**
            deletePart: _deletePart,                // drop one part from DB  **admin utility**
            clientDeletePart: _clientDeletePart    // set IsHidden and Isdeleted == true

            
        };
    });

})();