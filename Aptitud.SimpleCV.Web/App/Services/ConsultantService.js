﻿app.service('ConsultantService', function ($resource, $http) {
    this.getConsultants = function() {


        var queryDescriptor;
        queryDescriptor = {
            method: 'GET',
            isArray: true
        };
        var consultants = $resource('/api/consultants', {}, { query: queryDescriptor }).query();

        return consultants;
    };

    this.create = function (newConsult, success) {
        $http.post("/api/commands/createprofile", newConsult)
            .success(function (data, status, headers, config) {
                var profile = $resource(headers("location"), {}).get();
                success(profile);
            });
    };

    this.remove = function (id, success) {
        $resource("/api/commands/removeprofile/:id", { id:'@id' })
            .delete(
                { id: id },
                function () {
                    success(id);
                });
    };
});

