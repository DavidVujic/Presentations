/// <reference path="_references.js" />

// module is used to group your unit tests
module('search tests');

test('search feature with ajax', function () {

	// use expect to keep the control over how many asserts you expect in this unit test
	expect(1);

	var expectedResult = {
		data: ['hello', 'hello world']
	};

	var fakeJquery = {
		ajax: function (settings) {
			settings.success(expectedResult);
		}
	};

	searchFeature.init(fakeJquery);

	searchFeature.searchFor('hello', function (result) {

		deepEqual(result, expectedResult);

	});

});