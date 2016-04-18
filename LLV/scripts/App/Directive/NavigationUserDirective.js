﻿AppLLV.directive("navigationUser", ['$compile', function ($compile) {

    return {
        restrict: 'E',
        replace: true,
        scope: {
            usuario: '='
        },
        templateUrl: 'scripts/app/view/NavigationUser.html',
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