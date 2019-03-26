'use strict';

// Defines Hub
var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();

// Open Connection, then Sends Question and Listen for Votes
$(document).ready(function () {
	connection
	.start()
	.catch(function (err) {
		return console.error(err.toString());
	})
	.then(function () {
		sendQuestionToClients();
	})
	.then(function() {
		listenForVotes();
	})
});

// Sends Question To All Clients
function sendQuestionToClients() {
	console.log("Sending Question");
	var question = $('#questionTitle').html();
	console.log(`${question} send`);
	connection.invoke('SendQuestion', question).catch(function (err) {
		return console.error(err.toString());
	});
}
// Listens for Votes, lists users, increments counters and adds data to graph
function listenForVotes() {
	console.log("Listening for Votes");
	connection.on('ReceiveMessage', function (user, myResponseId, myResponseVal) {
		// Add Users to Voting List
		listVoters(user, myResponseVal);
		// Increment Span Counter
		incrementSpanCounter(myResponseId);
		// Increment Form
		incrementFormCounter(myResponseId);
		// Update Chart
		addData(myChart);
	});
}

// HELPER: Lists player names and votes in list.
function listVoters(user, myResponseVal) {
	var userAndVote = user + " voted for '" + myResponseVal + "'.";
	$('#messagesList').prepend(`<li>${userAndVote}</li>`);
}

// HELPER: Increments Span Counters, visible, needed for Display
function incrementSpanCounter(myResponseId) {
	var counter = $(`#${myResponseId}Counter`).html();
	counter++;
	$(`#${myResponseId}Counter`).html(counter);
}

// HELPER: Increments Form Counters, hidden, needed for Database
function incrementFormCounter(myResponseId) {
	var counter = $(`#${myResponseId}FormCounter`).val();
	counter++;
	$(`#${myResponseId}FormCounter`).val(counter);
}

// Chart Builder, referenced by myChart.
Chart.defaults.global.defaultFontColor = 'white';
var ctx = document.getElementById('bar-chart-horizontal');
ctx.height = 120;
var myChart = new Chart(ctx, {
	type: 'horizontalBar',
	data: {
		labels: ['Him', 'Her'],
		datasets: [{
			backgroundColor: ['#3e95cd', '#8e5ea2'],
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
					color: '#262626'
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
					color: '#262626'
				}
			}]
		}
	}
});

// HELPER: Adds data to Chart
function addData(myChart) {
	myChart.data.datasets[0].data = [
		$('#answerOneCounter').html(),
		$('#answerTwoCounter').html()
		// document.getElementById('answerOneCounter').innerHTML,
		// document.getElementById('answerTwoCounter').innerHTML
	];
	myChart.update();
}