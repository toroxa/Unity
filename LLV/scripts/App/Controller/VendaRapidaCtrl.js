AppLLV.controller('VendaRapidaCtrl', ['$scope', 'PessoaFactory', 'VendaFactory', function ($scope, PessoaFactory, VendaFactory) {

    var vr = this;

    $scope.CarregandoClientes = false;
    $scope.CarregaClientes = function () {

        $scope.CarregandoClientes = true;
        PessoaFactory.getClientes()
        .success(function (result) {
            if (result.ok) {
                var clientes = result.data;
                clientes.forEach(function (item) {
                    item.displayName = item.pessoaId + ' - ' + item.nome;
                });
                $scope.clientes = result.data;
            } else {
                console.error(result.errors);
            }
        }).error(function (data, status, headers, config) {
            console.error(status + ", " + data);
        }).finally(function (data, status, headers, config) {
            $scope.CarregandoClientes = false;
        });
    };

    $scope.CarregandoFuncionarios = false;
    $scope.CarregaFuncionarios = function () {

        $scope.CarregandoFuncionarios = true;
        PessoaFactory.getFuncionarios()
        .success(function (result) {
            if (result.ok) {
                var funcionarios = result.data;
                funcionarios.forEach(function (item) {
                    item.displayName = item.pessoaId + ' - ' + item.nome;
                });

                $scope.funcionarios = result.data;
            } else {
                console.error(result.errors);
            }
        }).error(function (data, status, headers, config) {
            console.error(status + ", " + data);
        }).finally(function (data, status, headers, config) {
            $scope.CarregandoFuncionarios = false;
        });
    };

    function disabled(data) {
        var date = data.date,
          mode = data.mode;
        return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
    }

    $scope.dateOptions = {
        dateDisabled: disabled,
        formatYear: 'yy',
        maxDate: new Date(2020, 5, 22),
        minDate: new Date(),
        startingDay: 1
    };

    $scope.formats = ['dd/MM/yyyy', 'dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];
    $scope.altInputFormats = ['M!/d!/yyyy'];

    $scope.popup1 = {
        opened: false
    };

    $scope.open1 = function () {
        $scope.popup1.opened = true;
    };

    $scope.CarregandoVenda = false;
    $scope.CarregaVenda = function (VendaId) {

        $scope.CarregandoVenda = true;
        VendaFactory.getVenda(VendaId)
        .success(function (result) {
            if (result.ok) {
                $scope.venda = result.data;

                //vr.gridOptions = {
                //    columnDefs: [
                //      { field: 'edit', name: '', cellTemplate: 'scripts/app/view/edit-button.html', width: 40 },
                //      { name: 'compraVendaId' },
                //      { name: 'tipoCompraVendaId' },
                //      { name: 'pessoaVendaId' },
                //      { name: 'pessoaCompraId' },
                //      { name: 'dataVenda' },
                //      { name: 'observacao' },
                //    ]
                //};

                //vr.gridOptions.data = result.data;
            } else {
                console.error(result.errors);
            }
        }).error(function (data, status, headers, config) {
            console.error(status + ", " + data);
        }).finally(function (data, status, headers, config) {
            $scope.CarregandoVenda = false;
        });
    };

    //Carrega sempre a primeira vez
    $scope.CarregaClientes();
    $scope.CarregaFuncionarios();
    $scope.CarregaVenda(1);
}]);