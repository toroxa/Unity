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

      //Aqui é o Modal
      $scope.items = ['item1', 'item2', 'item3'];

      $scope.animationsEnabled = true;

      $scope.open = function (size) {

          var modalInstance = $uibModal.open({
              animation: $scope.animationsEnabled,
              templateUrl: 'myModalContent.html',
              controller: 'ModalInstanceCtrl',
              size: size,
              resolve: {
                  items: function () {
                      return $scope.items;
                  }
              }
          });

          modalInstance.result.then(function (selectedItem) {
              $scope.selected = selectedItem;
          }, function () {
              $log.info('Modal dismissed at: ' + new Date());
          });
      };

      $scope.toggleAnimation = function () {
          $scope.animationsEnabled = !$scope.animationsEnabled;
      };
  }]);