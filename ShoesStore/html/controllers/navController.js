storeApp.controller("navController", ['$scope', '$http', '$routeParams', 'ProductManager',
	function($scope, $http, $routeParams, ProductManager) {
		$scope.numOfProducts = ProductManager.getNumOfProducts();
		
		$scope.$on("numOfProductsUpdated", function() {
			$scope.numOfProducts = ProductManager.getNumOfProducts();
		});
}]);