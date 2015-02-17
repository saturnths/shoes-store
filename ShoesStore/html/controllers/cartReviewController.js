storeApp.controller("cartReviewController", ['$scope', '$http', '$routeParams', 'ProductManager', 'GetAllProducts',
	function($scope, $http, $routeParams, ProductManager, GetAllProducts) {
		$scope.cartReviewNumofProducts = ProductManager.getNumOfProducts();
		var productsInCartWithIds = ProductManager.getProductsInCart();
		$scope.productsInCart = [];
		$scope.numOfProducts = ProductManager.getNumOfProducts();
		$scope.totalCost = ProductManager.getTotalCost();
		
		var products = GetAllProducts.query({}, function() {
			for (var i=0; i<productsInCartWithIds.length; i++) {
				for (var j=0; j<products.length; j++) {
					if (productsInCartWithIds[i] == products[j].ShoeId) {
						var product = {};
						product.Name = products[j].Name;
						product.ShoeId = products[j].ShoeId;
						product.Description = products[j].Description;
						product.Price = products[j].Price
						product.Checked = false;
						$scope.productsInCart.push(product);
					}
				}
			}
		});

		$scope.removeProduct = function(product, id) {
			$scope.productsInCart.splice($scope.productsInCart.indexOf(product), 1);
			ProductManager.removeProduct(product);
			ProductManager.decrementNumOfProducts();
			
			// get updated values:
			$scope.numOfProducts = ProductManager.getNumOfProducts();
			$scope.totalCost = ProductManager.getTotalCost();
		};

}]);