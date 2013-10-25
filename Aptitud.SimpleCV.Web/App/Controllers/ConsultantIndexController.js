app.controller('ConsultantIndexController', function ($scope, ConsultantService) {

    init();

    function init() {
        $scope.consultants = ConsultantService.getConsultants();

        $scope.createNewProfile = function(newConsult) {
            ConsultantService.create(newConsult, function(location) {
                $("#newConsult").modal("hide");
                console.log("Controller - Create - Success - location:" + location);
            });
        };

        $scope.removeProfile = function (id) {
            console.log("remove: " + id);
            ConsultantService.remove(id, function () {
                console.log("Controller - Remove - id:" + id);
                $scope.consultants = ConsultantService.getConsultants();
            });
        };

    }
});
