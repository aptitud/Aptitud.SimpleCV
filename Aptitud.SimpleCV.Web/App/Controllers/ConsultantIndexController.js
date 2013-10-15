app.controller('ConsultantIndexController', function ($scope, ConsultantService) {

    init();

    function init() {
        $scope.consultants = ConsultantService.getConsultants();

        $scope.createNewProfile = function(newConsult) {
            ConsultantService.create(newConsult, function() {
                $("#newConsult").modal("hide");
                
            });
        };
    }
});

//function ConsultantIndexController($scope, ConsultantService) {
//    $scope.consultants = ConsultantService.getConsultants();
//}
