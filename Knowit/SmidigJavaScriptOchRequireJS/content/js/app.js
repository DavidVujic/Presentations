/*global requirejs:true, require:true */

requirejs.config({
	baseUrl: '/content/js',
	paths: {
		jquery: '/scripts/jquery'
	}
});

require(['jquery', 'dom', 'post'], function($, dom, post) {

	$(document).ready(function () {

		$('#submit-button').on('click', function (ev) {
			ev.preventDefault();
			
			dom.appendHidden('user-id', '123', '#labb-form');

			var promise = post.submit('#labb-form');

			promise.done(function (result) {
				console.log(result);
			});

			promise.always(function () {
				dom.empty('#labb-form');
			});

		});


	});

});



