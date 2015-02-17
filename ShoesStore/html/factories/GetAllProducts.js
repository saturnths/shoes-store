storeApp.factory("GetAllProducts", function($resource) {
	return $resource(
		'/api/product',
		{'query': {method: 'GET', isArray: false}}
	);
});