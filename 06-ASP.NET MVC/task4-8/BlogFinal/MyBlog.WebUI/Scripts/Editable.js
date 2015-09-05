window.addEvent('domready', function () {
    $('textarea-1').mooEditable();

    // Post submit
    $('theForm').addEvent('submit', function (e) {
        //alert($('textarea-1').value);
        return true;
    });
});
