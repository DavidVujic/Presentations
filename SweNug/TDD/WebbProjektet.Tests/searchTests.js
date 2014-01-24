/// <reference path="../webbprojektet/scripts/searchapp.js" />
/// <reference path="qunit/qunit-1.13.0.js" />

test('search feature with ajax', function () {
	expect(1);

	// arrange
	var query = 'swenug';
	var expectedResult = { data: ['hello', 'hello world'] };

	var fakeJquery = {
		ajax: function (settings) {
			settings.success(expectedResult);
		}
	};

	// act
	searchApp.init(fakeJquery);

	searchApp.searchFor(query, function (result) {
		// assert
		ok(result);
	});


});