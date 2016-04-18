AppLLV.controller('OrdemServicoCtrl', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    this.name = "OrdemServicoCtrl";
    this.params = $routeParams;

    var os = this;

    os.gridOptions = {
        columnDefs: [
          { field: 'edit', name: '', cellTemplate: 'scripts/app/view/edit-button.html', width: 40 },
          { name: 'id' },
          { name: 'codigo' },
        ]
    };

    //$http.get(config.apiBaseUrl + '/os/listar')
    //.success(function (result) {
    //    if (result.ok) {
    //        os.gridOptions.data = result.data;
    //    } else {
    //        console.error(result.errors);
    //    }
    //}).error(function (data, status, headers, config) {
    //    console.error(status + ", " + data);
    //});
    $scope.disabled = undefined;
    $scope.person = {};
    $scope.people = [
      { name: 'Adam', email: 'adam@email.com', age: 10 },
      { name: 'Amalie', email: 'amalie@email.com', age: 12 },
      { name: 'Wladimir', email: 'wladimir@email.com', age: 30 },
      { name: 'Samantha', email: 'samantha@email.com', age: 31 },
      { name: 'Estefanía', email: 'estefanía@email.com', age: 16 },
      { name: 'Natasha', email: 'natasha@email.com', age: 54 },
      { name: 'Nicole', email: 'nicole@email.com', age: 43 },
      { name: 'Adrian', email: 'adrian@email.com', age: 21 }
    ];

    //$http.get(config.apiBaseUrl + '/pessoa/listar/1')
    //.success(function (result) {
    //    if (result.ok) {
    //        $scope.pessoas = result.data;
    //    } else {
    //        console.error(result.errors);
    //    }
    //}).error(function (data, status, headers, config) {
    //    console.error(status + ", " + data);
    //});
}]);