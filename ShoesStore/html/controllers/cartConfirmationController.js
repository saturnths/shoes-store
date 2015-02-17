storeApp.controller("cartConfirmationController", ['$scope', '$http', '$routeParams', 'ProductManager',
	function($scope, $http, $routeParams, ProductManager) {
		$scope.reset = ProductManager.resetProducts();
}]);