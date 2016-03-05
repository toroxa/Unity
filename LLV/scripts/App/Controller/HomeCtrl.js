AppLLV.controller('HomeCtrl', ['$scope', '$http', 'modalService', function ($scope, $http, modalService) {
    var vm = this;

    vm.open = function () {
        modalService.show('Titulo', 'Aqui vai a mensagem', 'lg', function () {
            alert('Sucesso!');
        });
    };
}]);