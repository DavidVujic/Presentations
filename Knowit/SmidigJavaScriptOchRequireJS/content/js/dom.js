/*global define: true */

define(['jquery'], function ($){
	'use strict';
 
    var appendHiddenField = function (name, value, selector) {
        $(selector).append('<input type="hidden" name="' + name + '" value="' + value + '" data-element-added />');
    };

    var removeChildren = function (selector) {
        $(selector).children('[data-element-added]').remove();
    };
    
    return {
       	appendHidden: appendHiddenField,
        empty: removeChildren
    };
});
