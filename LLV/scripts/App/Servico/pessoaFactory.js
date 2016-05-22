AppLLV.factory('PessoaFactory', ['$http',
  function ($http) {
      return {
          getPessoas: function (grupoId) {
              return $http.get(config.apiBaseUrl + '/pessoa/listar/' + grupoId);
          },
          getClientes: function () {
              return $http.get(config.apiBaseUrl + '/pessoa/listar/1');//1 - Grupo de Clientes
          },
          getFuncionarios: function () {
              return $http.get(config.apiBaseUrl + '/pessoa/listar/2');//1 - Grupo de Funcionários
          },
      };
  }]);