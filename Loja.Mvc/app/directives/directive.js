
var app = angular.module('AngularAuthApp');

app.directive('validNumber', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }

            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }
                var clean = val.replace(/[^0-9]+/g, '');
                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });

            element.bind('keypress', function (event) {
                if (event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
});

app.directive('inputPrice', function () {
    return {
        restrict: 'EA',
        template: '<input name="{{inputName}}" ng-model="inputValue" />',
        scope: {
            inputValue: '=',
            inputName: '='
        },
        link: function (scope) {
            scope.$watch('inputValue', function (newValue, oldValue) {
                if (String(newValue).indexOf(',') != -1)
                    scope.inputValue = String(newValue).replace(',', '.');
                else {
                    var index_dot,
                        arr = String(newValue).split("");
                    if (arr.length === 0) return;
                    if (arr.length === 1 && (arr[0] == '-' || arr[0] === '.')) return;
                    if (arr.length === 2 && newValue === '-.') return;
                    if (isNaN(newValue) || ((index_dot = String(newValue).indexOf('.')) != -1 && String(newValue).length - index_dot > 3)) {
                        scope.inputValue = oldValue;
                    }
                }
            });
        }
    };
});


app.directive('ngFocus', ['$parse', function ($parse) {
    return function(scope, element, attr) {
        var fn = $parse(attr['ngFocus']);
        element.bind('focus', function(event) {
            scope.$apply(function() {
                fn(scope, { $event: event });
            });
        });
    };
}]);

app.directive('ngBlur', ['$parse', function ($parse) {
    return function(scope, element, attr) {
        var fn = $parse(attr['ngBlur']);
        element.bind('blur', function(event) {
            scope.$apply(function() {
                fn(scope, { $event: event });
            });
        });
    };
}]);
