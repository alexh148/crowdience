
$(document).ready(function () {

    var limit = 2;
    $('input.form-check-input').on('change', function(evt) {
    if($(this).siblings(':checked').length >= limit) {
         this.checked = false;
         }
    });


    $('#create').click(function(){
        var selected = [];
        $('.cc-selector-2 input:checked').each(function() {
               selected.push($(this).attr('value'));
        });
        console.log(selected);
    })


})
