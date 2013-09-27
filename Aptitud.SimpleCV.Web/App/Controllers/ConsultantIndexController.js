app.controller('ConsultantIndexController', function ($scope, ConsultantService) {

    init();

    function init() {
        $scope.consultants = ConsultantService.getConsultants();
    }
});

//function ConsultantIndexController($scope, ConsultantService) {
//    $scope.consultants = ConsultantService.getConsultants();
//}
