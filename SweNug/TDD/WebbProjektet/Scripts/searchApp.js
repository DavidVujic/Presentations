var searchApp = (function () {
	var $;
	var initialize = function (framework) {
		$ = framework;
	};

	var searchForQuery = function (query, callback) {
		$.ajax({
			url: '',
			data: { q: query },
			success: function (result) {
				callback(result);
			}
		});
	};

	return {
		init: initialize,
		searchFor: searchForQuery
	};
}());