app.service('ConsultantService', function ($resource) {
    this.getConsultants = function () {
    

        var queryDescriptor;
        queryDescriptor = {
            method: 'GET',
            isArray: true
        };
        var consultants = $resource('/api/consultants', {}, { query: queryDescriptor } ).query();

        console.log('consultants' + consultants)
        return consultants;
    }
});

//    var consultants = [
//        { id: 1, firstName: 'Peter', lastName: 'Qwärnström', email: 'peter.qwarnstrom@aptitud.se' },
//        { id: 2, firstName: 'Håkan', lastName: 'Forss', email: 'hakan.forss@aptitud.se' },
//        { id: 3, firstName: 'David', lastName: 'Blomberg', email: 'david.blomberg@aptitud.se' }
//    ];
//});

//angular.module('simpleCV.services', ['ngResource'])
//app.factory('ConsultantService', function ($resource) {
//    var queryDescriptor;
//    queryDescriptor = {
//        method: 'GET',
//        isArray: true
//    };
//    var consultants = $resource('api/consultants', {
//    }, {
//        query: queryDescriptor
//    });
//    return consultants;
//});
