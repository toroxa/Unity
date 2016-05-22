AppLLV.factory('VendaFactory', ['$http',
  function ($http) {
      return {
          getVenda: function (VendaId) {
              return $http.get(config.apiBaseUrl + '/venda/carregar/' + VendaId);
          }
      };
  }]);