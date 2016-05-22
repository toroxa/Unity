﻿AppLLV.config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $locationProvider) {

      //Aqui vão as URLs das Views do MVC
      $routeProvider.when(config.baseRoute + '/', {
          templateUrl: '/Home/Home',
          caseInsensitiveMatch: true
      }).when(config.baseRoute + '/parametro', {
          templateUrl: '/Home/Parametro',
          caseInsensitiveMatch: true
      }).when(config.baseRoute + '/os', {
          templateUrl: '/OrdemServico/Index',
          caseInsensitiveMatch: true
      }).when(config.baseRoute + '/venda-rapida', {
          templateUrl: '/VendaRapida/Index',
          caseInsensitiveMatch: true
      }).otherwise({
          redirectTo: '/'
      });

      //$.getScript('/path/to/imported/script.js', function () {
      //    // script is now loaded and executed.
      //    // put your dependent JS here.
      //});

      // Specify HTML5 mode (using the History APIs) or HashBang syntax.
      $locationProvider.html5Mode(false);//.hashPrefix('!');
  }]);