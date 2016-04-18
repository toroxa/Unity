AppLLV.directive("navigation", ['$compile', function ($compile) {

    return {
        restrict: 'E',
        replace: true,
        scope: {
            menu: '='
        },
        templateUrl: 'scripts/app/view/Navigation.html',
        compile: function (el) {
            var contents = el.contents().remove();
            return function (scope, el) {
                $compile(contents)(scope, function (clone) {
                    el.append(clone);
                });
            };
        }
    };

}]);