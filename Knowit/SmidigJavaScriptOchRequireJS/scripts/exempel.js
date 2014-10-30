
var minModul = (function () {
	var getMyName = function () {
		return 'hello world';
	};

	return {
		getName: getMyName
	};
}());

minModul.getName();