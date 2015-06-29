(function () {

    angular.module('PartApp').factory('PartService', function ($resource, PART_API) {
        var Part = $resource(PART_API);

        var _getParts = function () {
            return Part.query();
        };

        var _getPart = function (id) {
            return Part.get({ id: id })
        };

        var _addPart = function (part) {
            var newPart = new Part(part);
            return newPart.$save();
        };

        var _editPart = function (part) {
            return part.$save();
        };

        var _deletePart = function (id) {
            return Part.remove({ id: id }).$promise;
        };

        return {
            getParts: _getParts,
            getPart: _getPart,
            addPart: _addPart,
            editPart: _editPart,
            deletePart: _deletePart
        };
    });



})();