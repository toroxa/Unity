AppLLV.controller('GerenciaParametroCtrl', ['$scope', '$http', 'modalService', '$routeParams', function ($scope, $http, modalService, $routeParams) {
    this.name = "GerenciaParametroCtrl";
    this.params = $routeParams;

    var vm = this;

    vm.editRow = function editRow(grid, row) {
        //$modal.open({
        //    templateUrl: 'edit-parametro-modal.html',
        //    controller: ['$modalInstance', 'grid', 'row', function RowEditCtrl($modalInstance, grid, row) {
        //        var vm = this;

        //        //vm.schema = ParametroSchema;
        //        vm.entity = angular.copy(row.entity);
        //        //vm.form = [
        //        //  'Chave',
        //        //  'Valor',
        //        //];

        //        vm.save = save;

        //        function save() {
        //            // Copy row values over
        //            row.entity = angular.extend(row.entity, vm.entity);
        //            $modalInstance.close(row.entity);
        //        }
        //    }],
        //    controllerAs: 'vm',
        //    resolve: {
        //        grid: function () { return grid; },
        //        row: function () { return row; }
        //    }
        //});
        //console.log(row);
        modalService.show('Titulo', 'Aqui vai a mensagem', 'lg', function () {
            alert('Sucesso!');
        });
    }

    vm.gridOptions = {
        columnDefs: [
          { field: 'edit', name: '', cellTemplate: 'scripts/app/view/edit-button.html', width: 40 },
          { name: 'chave' },
          { name: 'valor' },
        ]
    };

    $http.get(config.apiBaseUrl + '/parametro/listar')
    .success(function (result) {
        if (result.ok) {
            vm.gridOptions.data = result.data;
        } else {
            console.error(result.errors);
        }
    }).error(function (data, status, headers, config) {
        console.error(status + ", " + data);
    });
}]);