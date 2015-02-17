storeApp.controller("cartOrderController", ['$scope', '$http', '$routeParams', 'ProductManager',
	function($scope, $http, $routeParams, ProductManager) {
		$scope.numOfProducts = ProductManager.getNumOfProducts();
		$scope.totalCost = ProductManager.getTotalCost();
}]);