/* global: jQuery */

var devbank = (function ($) {
	'use strict';

	var formSel = null;
	var targetSel = null;

	var isUser = function(user) {
		if (!user || !user.firstName || !user.lastName) {
			return false;
		}

		return true;
	};

	var updateView = function(user) {
		var output = '';

		if (isUser(user)) {
			output = user.firstName + ' ' + user.lastName;
		}

		$(targetSel).text(output);
	};

	var post = function(elm) {
		var url = $(elm).attr('action');

		var data = $(elm).serialize();

		return $.post(url, data);
	};

	var addListener = function () {

		$(formSel).on('submit', function (e) {
			e.preventDefault();

			var promise = post(this);

			promise.then(updateView);
		});
	};

	var hijackForm = function(formSelector, targetSelector) {
		formSel = formSelector;
		targetSel = targetSelector;

		addListener();
	};

	return {
		hijack: hijackForm
	};

}(jQuery));