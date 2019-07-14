(function () {
    'use strict';

    angular
        .module('app.controllers')
        .controller("indexController", indexController)

    indexController.$inject = ['$scope', '$rootScope', '$filter', 'indexService', 'ngTableParams'];

    function indexController($scope, $rootScope, $filter, indexService, ngTableParams) {
        $scope.appName = 'MasGlobal Hands On - Ever Alonso Torres Galeano - Front end';

        $scope.searching = false;
        $scope.data = null;

        $scope.search =
            {
                employeeId: null
            };

        $scope.getById = getById;
        function getById() {

            
            $scope.search.employeeId = isNaN($scope.search.employeeId)  ? '' : $scope.search.employeeId;
            $scope.dataTable = new ngTableParams({
                page: 1, // show first page
                count: 10000,
                sorting: {
                    'EmployeeId': 'asc' // initial sorting
                }
            }, {
                    total: 0,
                    counts: 10000, //prevent showing page size buttons
                    getData: function ($defer, params) {

                        var sortColumn = Object.keys(params.sorting())[0];
                        var sortDirection = params.sorting()[sortColumn];
                        $scope.searching = true;


                        indexService.EmployeeGetById($scope.search.employeeId == '' ? 0 : $scope.search.employeeId).then(function (result) {
                            var resultList = new Array();
                            if (result != null && result !="") {
                                resultList.push(result)
                            }
                            $scope.data = resultList;
                            params.total($scope.data.length);

                            $scope.searching = false;
                            $scope.data = params.sorting() ? $filter('orderBy')($scope.data, params.orderBy()) : $scope.data;
                            $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                            $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                            $defer.resolve($scope.data);
                        });
                        $scope.searching = false;
                    }
                });

        }


        $scope.getAll = getAll;
        function getAll() {
            $scope.dataTable = new ngTableParams({
                page: 1, // show first page
                count: 10000,
                sorting: {
                    'EmployeeId': 'asc' // initial sorting
                }
            }, {
                    total: 0,
                    counts: 10000, //prevent showing page size buttons
                    getData: function ($defer, params) {

                        var sortColumn = Object.keys(params.sorting())[0];
                        var sortDirection = params.sorting()[sortColumn];

                        $scope.searching = true;


                        indexService.EmployeeGetAll().then(function (result) {

                            $scope.data = result;
                            params.total($scope.data.length);

                            $scope.searching = false;
                            $scope.data = params.sorting() ? $filter('orderBy')($scope.data, params.orderBy()) : $scope.data;
                            $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                            $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                            $defer.resolve($scope.data);
                        });
                        $scope.searching = false;
                    }
                });
        }
        /* Initialize*/

        function Initialize() {

            $scope.dataTable = new ngTableParams({
                page: 0, // show first page
                count: 10000,
                sorting: {
                    'EmployeeId': 'asc' // initial sorting
                }
            }, {
                    total: 0,
                    counts: 10000, //prevent showing page size buttons
                    getData: function ($defer, params) {

                        var sortColumn = Object.keys(params.sorting())[0];
                        var sortDirection = params.sorting()[sortColumn];
                        var searchParams = {
                            orderBy: sortColumn + (sortDirection == 'asc' ? '' : ' DESC'),
                            pageNumber: params.page(),
                            employeeId: $scope.search.employeeId
                        };
                        $scope.searching = true;


                        //indexService.EmployeeGetAll().then(function (result) {

                        $scope.data = new Array();
                        params.total($scope.data.length);

                        $scope.searching = false;
                        $scope.data = params.sorting() ? $filter('orderBy')($scope.data, params.orderBy()) : $scope.data;
                        $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                        $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                        $defer.resolve($scope.data);
                        //});
                        $scope.searching = false;
                    }
                });



        }


        Initialize();

    }

})();
