"use strict";
console.log(localStorage.getItem("questions"))
var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.on("ReceiveUser", function(user) {
    var joinedUser = user + " joined the game!";
    var ulUsers = document.getElementById("joinedUsers");
    var liUser = document.createElement("li");
    liUser.textContent = joinedUser;
    
    ulUsers.insertBefore(liUser, ulUsers.childNodes[0]);
  });

connection.on("ReceiveCouple", function(user) {
    var joinedCouple = user + " joined the game!";
    var ulCouple = document.getElementById("joinedCouple");
    var liCouple = document.createElement("li");
    liCouple.textContent = joinedCouple;
    
    ulCouple.insertBefore(liCouple, ulCouple.childNodes[0]);
  });

$( "#start" ).click(function(event) {
  event.preventDefault()
  $(location).attr('href', '/Host/Results')

})

connection.start().catch(function(err) {
  return console.error(err.toString());
});

