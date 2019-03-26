let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});


$(document).ready(function () {

    var limit = 2;
    $('input.form-check-input').on('change', function (evt) {
        if ($(this).siblings(':checked').length >= limit) {
            this.checked = false;
        }
    });


    $('#create').click(function () {
        var counter = 1;
        $('.cc-selector-2 input:checked').each(function () {
            localStorage.setItem(`IconId${counter}`, $(this).attr('value'));
            counter++;
        });
       SendIcons();
    })

  

})

// // Send Icons to Clients
// function SendIcons(){
//     var icon1 = localStorage.getItem("IconId1");
//     var icon2 = localStorage.getItem("IconId2");
//     connection.invoke("SendIconId", icon1, icon2).catch(function (err) {
//         return console.error(err.toString());
//     });
// }
