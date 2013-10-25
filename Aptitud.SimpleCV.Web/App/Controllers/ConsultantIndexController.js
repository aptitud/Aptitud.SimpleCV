app.controller('ConsultantIndexController', function ($scope, ConsultantService) {

    init();

    function init() {
        $scope.consultants = ConsultantService.getConsultants();

        $scope.createNewProfile = function(newConsult) {
            ConsultantService.create(newConsult, function(profile) {
                $("#newConsult").modal("hide");
                $scope.consultants.push(profile);
            });
        };

        $scope.removeProfile = function (id) {
            console.log("remove: " + id);
            ConsultantService.remove(id, function () {
                $scope.consultants = ConsultantService.getConsultants();
            });
        };

    }
});
