// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

mobiscroll.setOptions({
    theme: 'ios',
    themeVariant: 'light'
});

mobiscroll.datepicker('#demo-mobile-picker-input', {
    controls: ['calendar']
});

var instance = mobiscroll.datepicker('#demo-mobile-picker-button', {
    controls: ['calendar'],
    showOnClick: false,
    showOnFocus: false
});

//instance.setVal(new Date(), true);

//mobiscroll.datepicker('#demo-mobile-picker-mobiscroll', {
//    controls: ['calendar']
//});

//mobiscroll.datepicker('#demo-mobile-picker-inline', {
//    controls: ['calendar'],
//    display: 'inline'
//});

//document
//    .getElementById('show-mobile-date-picker')
//    .addEventListener('click', function () {
//        instance.open();
//        return false;
//    });

