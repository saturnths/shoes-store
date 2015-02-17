var storeApp = angular.module("storeApp", ['ngRoute', 'ngResource']);

storeApp.config(['$routeProvider', function($routeProvider) {
	$routeProvider
		.when('/', {
			templateUrl: 'pages/main.html',
		})
		.when('/:gender/:category', {
			templateUrl: 'pages/products.html',
			controller: 'productController'
		})
		.when('/cart-review', {
			templateUrl: 'pages/cart/review.html',
			controller: 'cartReviewController'
		})
		.when('/cart-billing', {
			templateUrl: 'pages/cart/billing.html'
		})
		.when('/cart-order', {
			templateUrl: 'pages/cart/order.html'
		})
		.when('/cart-confirmation', {
			templateUrl: 'pages/cart/confirmation.html',
			controller: 'cartConfirmationController'
		});
}]);

function CategoryManager($scope, $http) {
	$http.get('/api/category')
	.success(function(data) {
		$scope.categories = {
			'men' : data[0].Categories,
			'women' : data[1].Categories
		};
	});
}