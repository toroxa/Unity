AppLLV.controller('MainCtrl', ['$scope', '$http', '$route', '$routeParams', '$location',
  function ($scope, $http, $route, $routeParams, $location) {
      this.$route = $route;
      this.$location = $location;
      this.$routeParams = $routeParams;

      $scope.menus = [];

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

      //$http.get(config.baseRoute + '/api/acesso-pegar-menus')
      //.success(function (data) {
      //    $scope.menus = data;
      //});

      $scope.isActive = function (viewLocation) {
          var path = $location.path().replace(config.baseRoute, '');
          if (viewLocation == '/') {
              return path === viewLocation;
          }
          return path.indexOf(viewLocation) !== -1;
      };
  }]);