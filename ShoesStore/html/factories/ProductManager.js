storeApp.factory("ProductManager", function($rootScope) {
	var manager = {};
	
	manager.numOfProducts = 0;
	manager.productsInCart = [];
	manager.totalCost = 0;
	
	manager.addProductToCart = function(id, price) {
		manager.productsInCart.push(id);
		manager.totalCost += price;
	};
	
	manager.getProductsInCart = function() {
		return manager.productsInCart;
	};
	
	manager.removeProduct = function(product) {
		manager.productsInCart.splice(manager.productsInCart.indexOf(product), 1);
		manager.totalCost -= product.Price;
	}
	
	manager.incrementNumOfProducts = function($scope) {
		manager.numOfProducts++;
		$rootScope.$broadcast("numOfProductsUpdated");
	};
	
	manager.decrementNumOfProducts = function($scope) {
		manager.numOfProducts--;
		$rootScope.$broadcast("numOfProductsUpdated");
	};
	
	manager.getNumOfProducts = function() {
		return manager.numOfProducts;
	};
	
	manager.getTotalCost = function() {
		return manager.totalCost;
	};
	
	manager.resetProducts = function() {
		manager.productsInCart = [];
		manager.numOfProducts = 0;
		manager.totalCost = 0;
		$rootScope.$broadcast("numOfProductsUpdated");
	}
	
	return manager;
});