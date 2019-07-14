(function () {
    'use strict';

    angular
        .module('app.services')
        .factory('indexService', indexService);

    indexService.$inject = ['$http', '$q'];

    function indexService($http, $q) {
        var Global_ServiceApiBaseUrl = 'http://localhost:50350/'
        return {
            EmployeeGetAll: EmployeeGetAll,
            EmployeeGetById: EmployeeGetById,
        };

        function EmployeeGetAll() {
            var deferred = $q.defer();

            $http.get(Global_ServiceApiBaseUrl + 'api/Employee/GetAll')
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                        deferred.reject(error.msg);
                });

            return deferred.promise;
        }


        function EmployeeGetById(employeeId) {
            var deferred = $q.defer();

            $http.get(Global_ServiceApiBaseUrl + 'api/Employee/GetById?employeeId=' + employeeId)
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (error) {
                    deferred.reject(error.msg);
                });

            return deferred.promise;
        }





    };
})();