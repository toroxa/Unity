AppLLV.controller('MainCtrl', ['$scope', '$http', '$route', '$routeParams', '$location', '$uibModal', '$log',
  function ($scope, $http, $route, $routeParams, $location, $uibModal, $log) {
      this.$route = $route;
      this.$location = $location;
      this.$routeParams = $routeParams;

      $scope.menus = [];
      //$scope.usuario = {};
      $scope.usuario = {};
      $scope.usuario.Nome = 'Vinicius de Siqueira Campos';

      $http.get(config.apiBaseUrl + '/acesso/listar-menus')
      .success(function (result) {
          if (result.ok) {
              $scope.menus = result.data;
          } else {
              console.error(result.errors);
          }
      }).error(function (data, status, headers, config) {
          console.error(status + ", " + data);
      });

      //$scope.usuario = config.usuario;
      //console.log($scope.usuario);

      $scope.isActive = function (viewLocation) {
          var path = $location.path().replace(config.baseRoute, '');
          if (viewLocation == '/') {
              return path === viewLocation;
          }
          return path.indexOf(viewLocation) !== -1;
      };
  }]);