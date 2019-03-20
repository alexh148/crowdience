"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$(document).ready(function () {
    // Chart variables
    var answerOneVotes = localStorage.getItem("answerOneVotes");
    var answerTwoVotes = localStorage.getItem("answerTwoVotes");
    console.log(answerOneVotes);
    console.log(answerTwoVotes);
    document.getElementById("answerOneFinalCounter").innerHTML = answerOneVotes
    document.getElementById("answerTwoFinalCounter").innerHTML = answerTwoVotes;
    var groomName = localStorage.getItem("groomname");
    var groomVote = localStorage.getItem("groom");
    var brideName = localStorage.getItem("bridename");
    var brideVote = localStorage.getItem("bride");
    document.getElementById("groom").innherHTML = groomName;
    document.getElementById("groomVote").innherHTML = groomVote;
    document.getElementById("bride").innherHTML = brideName;
    document.getElementById("brideVote").innherHTML = brideVote;


    // Chart
    Chart.defaults.global.defaultFontColor = "white";
    var ctx = document.getElementById("bar-chart-horizontal");
    ctx.height = 120;
    var myChart = new Chart(ctx, {
        type: "horizontalBar",
        data: {
            labels: ["Him", "Her"],
            datasets: [{
                backgroundColor: ["#3e95cd", "#8e5ea2"],
                data: [answerOneVotes, answerTwoVotes]
            }]
        },
        options: {
            legend: {
                display: false
            },
            title: {
                display: true,
                scaleStartValue: 0
            },
            scales: {
                xAxes: [{
                    gridLines: {
                        color: "#262626"
                    },
                    stacked: true,
                    ticks: {
                        min: 0 // minimum value
                    }
                }],
                yAxes: [{
                    categoryPercentage: 1.0,
                    barPercentage: 1.0,
                    gridLines: {
                        color: "#262626"
                    }
                }]
            }
        }
    });
})