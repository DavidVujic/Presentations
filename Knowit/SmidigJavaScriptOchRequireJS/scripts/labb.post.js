var labb = labb || {};

labb.post = (function () {
	'use strict';
    var $ = null;

    var submitForm = function (formSelector) {
        if (!$) {
            return;
        }

        var form = $(formSelector);
        var url = form.attr('action');
        var data = form.serialize();

        return $.post(url, data);
    };

    var initialize = function (jQuery) {
        $ = jQuery;
    };
    
    return {
        init: initialize,
        submit: submitForm
    };
}());