"use strict";

// Defines Hub
let connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Opens Connection to Hub
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Get votes from html and display Graph
$(document).ready(function () {
    // Populated by Razor Page and C# database.
    var answerOneVotes = $('#answerOneFinalCounter').html();
    var answerTwoVotes = $('#answerTwoFinalCounter').html();

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