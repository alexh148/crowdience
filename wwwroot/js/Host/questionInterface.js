"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var counter = 0
var questions = localStorage.getItem("questions");
var questions = JSON.parse(questions);

$( "#nextQuestion" ).click(function(event) {
    event.preventDefault()
    console.log("Next question clicked");

    
    connection.invoke("SendQuestion", questions[counter]).catch(function (err) {
        return console.error(err.toString());
    });
    counter++;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});