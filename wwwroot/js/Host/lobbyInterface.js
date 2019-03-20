"use strict";
console.log(localStorage.getItem("questions"))
var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.on("ReceiveUser", function(user) {
    var joinedUser = user + " joined the game!";
    var ulUsers = document.getElementById("joinedUsers");
    var liUser = document.createElement("li");
    liUser.textContent = joinedUser;
    
  
    // append to top
    ulUsers.insertBefore(liUser, ulUsers.childNodes[0]);
  });

$( "#start" ).click(function(event) {
  event.preventDefault()
  $(location).attr('href', '/Host/Results')

//   var question = localStorage.getItem("questions");
//   console.log(question)
//   connection.invoke("SendQuestion", question).catch(function (err) {
//     return console.error(err.toString());
// });
})

connection.start().catch(function(err) {
  return console.error(err.toString());
});

