"use strict";

// Defines Hub
var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Opens Connection to Hub
connection.start().catch(function(err) {
  return console.error(err.toString());
});

// When Document loads listen for Connecting Users and Couple
// When Start is clicked Starts game on all Clients
$(document).ready(function () {
  recieveAndDisplayConnectingUsers()
  recieveAndDisplayConnectingCouple()

  $( "#start" ).click(function() {
    connection.invoke("StartGame").catch(function (err) {
      return console.error(err.toString());
    })
  })
  
})

// Listens for connecting users, displays them in list.
function recieveAndDisplayConnectingUsers() {
  connection.on("ReceiveUser", function(user) {
    var joinedUser = user + " joined the game!";
    $('#joinedUsers').prepend(`<li>${joinedUser}</li>`);
    // var ulUsers = document.getElementById("joinedUsers");
    // var liUser = document.createElement("li");
    // liUser.textContent = joinedUser;
    // ulUsers.insertBefore(liUser, ulUsers.childNodes[0]);
  });
}

// HELPER: Lists player names and votes in list.
function listVoters(user, myResponseVal) {
	var userAndVote = user + " voted for '" + myResponseVal + "'.";
	$('#messagesList').prepend(`<li>${userAndVote}</li>`);
}

// Listens for connecting couples, displays them in list.
function recieveAndDisplayConnectingCouple() {
  connection.on("ReceiveCouple", function(user) {
    var joinedCouple = user + " joined the game!";
    $('#joinedCouple').prepend(`<li>${joinedCouple}</li>`);
    // var ulCouple = document.getElementById("joinedCouple");
    // var liCouple = document.createElement("li");
    // liCouple.textContent = joinedCouple;
    
    // ulCouple.insertBefore(liCouple, ulCouple.childNodes[0]);
  });
}



