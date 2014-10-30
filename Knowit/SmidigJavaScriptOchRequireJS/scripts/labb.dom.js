var labb = labb || {};

labb.dom = (function () {
	'use strict';
    var $ = null;

    var appendHiddenField = function (name, value, selector) {
        $(selector).append('<input type="hidden" name="' + name + '" value="' + value + '" data-element-added />');
    };

    var removeChildren = function (selector) {
        $(selector).children('[data-element-added]').remove();
    };

    var initialize = function (jQuery) {
        $ = jQuery;
    };
    
    return {
        init: initialize,
        appendHidden: appendHiddenField,
        empty: removeChildren
    };
	
}());