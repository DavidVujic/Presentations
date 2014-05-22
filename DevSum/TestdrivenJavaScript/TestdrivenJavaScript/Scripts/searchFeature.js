var searchFeature = (function () {

	var $;

	var initialize = function (framework) {
		$ = framework;
	};

	var doSearch = function (query, callback) {

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
		searchFor: doSearch
	};
}());