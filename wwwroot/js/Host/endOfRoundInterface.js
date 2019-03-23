"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});


$(document).ready(function () {
    // $("#nextQuestion").click(function () {
    //     console.log("Next question clicked!");
    //     var question = document.getElementById("questionTitle").innerHTML;
    //     console.log(question);
    //     connection.invoke("SendQuestion", question).catch(function (err) {
    //         return console.error(err.toString());
    //     });
    // })
    // Old Way!
    // var answerOneVotes = localStorage.getItem("answerOneVotes");
    // var answerTwoVotes = localStorage.getItem("answerTwoVotes");
    // console.log(answerOneVotes);
    // console.log(answerTwoVotes);
    // document.getElementById("answerOneFinalCounter").innerHTML = answerOneVotes
    // document.getElementById("answerTwoFinalCounter").innerHTML = answerTwoVotes;

    // Old Way!
    var answerOneVotes = document.getElementById("answerOneFinalCounter").innerHTML;
    var answerTwoVotes = document.getElementById("answerTwoFinalCounter").innerHTML;
    // var groomName = localStorage.getItem("couplename1")
    // var groomVote = localStorage.getItem("myResponseId1");
    // var brideName = localStorage.getItem("couplename2");
    // var brideVote = localStorage.getItem("myResponseId2");
    // document.getElementById("groom").innerHTML = groomName;
    // document.getElementById("groomVote").innerHTML = groomVote;
    // document.getElementById("bride").innerHTML = brideName;
    // document.getElementById("brideVote").innerHTML = brideVote;

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