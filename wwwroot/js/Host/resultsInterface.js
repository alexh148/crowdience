"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var coupleCounter = 1;

Chart.defaults.global.defaultFontColor = "white";
var ctx = document.getElementById("bar-chart-horizontal");
ctx.height = 120;
var myChart = new Chart(ctx, {
  type: "horizontalBar",
  data: {
    labels: ["Him", "Her"],
    datasets: [{
      backgroundColor: ["#3e95cd", "#8e5ea2"],
      data: [0, 0]
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

connection.on("ReceiveQuestion", function (question) {
  console.log(question);
  document.getElementById("questionTitle").innerHTML = question;
  document.getElementById("answerOneCounter").innerHTML = 0;
  document.getElementById("answerTwoCounter").innerHTML = 0;
  document.getElementById("messagesList").innerHTML = "";
  addData(myChart);
});

connection.on("ReceiveMessage", function (
  user,
  message,
  myResponseId,
  myResponseVal
) {
  // alert("myResponseId=" + myResponseId + ",myResponseVal=" + myResponseVal);
  var msg = message
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
  // var encodedMsg = user + " says " + msg;
  var pollResultMsg = user + " voted for '" + myResponseVal + "'.";

  // var liMessage = document.createElement("li");
  // liMessage.textContent = encodedMsg;
  // document.getElementById("messagesList").appendChild(liMessage);

  var ulPoll = document.getElementById("messagesList");
  var liPollResult = document.createElement("li");
  liPollResult.textContent = pollResultMsg;

  // append to top
  ulPoll.insertBefore(liPollResult, ulPoll.childNodes[0]);

  // append to end
  // document.getElementById("messagesList").appendChild(liPollResult);


  // Increment Counter
  console.log(myResponseId + "Counter")
  var counter = document.getElementById(myResponseId + "Counter").innerHTML;
  counter++;
  document.getElementById(myResponseId + "Counter").innerHTML = counter;
  addData(myChart);
});

function addData(myChart) {
  console.log("Add Data Called");
  myChart.data.datasets[0].data = [
    document.getElementById("answerOneCounter").innerHTML,
    document.getElementById("answerTwoCounter").innerHTML
  ];
  myChart.update();
}

connection.start().catch(function (err) {
  return console.error(err.toString());
});

connection.on("ReceiveCoupleVote", function (couple, message, myResponseId, myResponseVal) {
  localStorage.setItem(`couplename${coupleCounter}`, couple)
  localStorage.setItem(`myResponseId${coupleCounter}`, myResponseVal)
  coupleCounter++;
})
