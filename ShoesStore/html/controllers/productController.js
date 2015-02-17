storeApp.controller("productController", ['$scope', '$http', '$routeParams', 'GetProducts', 'ProductManager',
	function($scope, $http, $routeParams, GetProducts, ProductManager) {

		var products = GetProducts.query({gender: $routeParams.gender, category: $routeParams.category}, function() {
			$scope.products = products;
		});

		$scope.orderProduct = function(id, price) {
			var product = {};
			product.id = id;
			
			ProductManager.addProductToCart(id, price);
			ProductManager.incrementNumOfProducts();
		};
}]);