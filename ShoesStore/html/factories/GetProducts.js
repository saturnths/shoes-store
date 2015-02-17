storeApp.factory("GetProducts", function($resource) {
	return $resource(
		'/api/product?gender=:gender&category=:category',
		{'query': {method: 'GET', isArray: false}}
	);
});