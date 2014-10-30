/*global define: true */

define(['jquery'], function ($) {
	'use strict';
  
    var submitForm = function (formSelector) { 
        var form = $(formSelector);
        var url = form.attr('action');
        var data = form.serialize();

        return $.post(url, data);
    };
    return {
        submit: submitForm
    };
});