'use strict';

var connection = new signalR.HubConnectionBuilder().withUrl('/pollHub').build();
var coupleCounter = 1;

// connection.start().catch(function (err) {
//   return console.error(err.toString());
// });
// Start Connection and Update All Player Screens
connection
	.start()
	.catch(function(err) {
		return console.error(err.toString());
	})
	.then(function() {
		var question = document.getElementById('questionTitle').innerHTML;
		console.log(question);
		connection.invoke('SendQuestion', question).catch(function(err) {
			return console.error(err.toString());
		});
	});

connection.on('ReceiveCoupleVote', function(couple, message, myResponseId, myResponseVal) {
	localStorage.setItem(`couplename${coupleCounter}`, couple);
	localStorage.setItem(`myResponseId${coupleCounter}`, myResponseVal);
	coupleCounter++;
});

connection.on('ReceiveMessage', function(user, myResponseId, myResponseVal) {
	var pollResultMsg = user + " voted for '" + myResponseVal + "'.";

	var ulPoll = document.getElementById('messagesList');
	var liPollResult = document.createElement('li');
	liPollResult.textContent = pollResultMsg;

	ulPoll.insertBefore(liPollResult, ulPoll.childNodes[0]);

	// Increment Counter
	console.log(myResponseId + 'Counter');
	var counter = document.getElementById(myResponseId + 'Counter').innerHTML;
	counter++;
	var counterTwo = $(`#${myResponseId}FormCounter`).val();
	counterTwo++;
	console.log(`#${myResponseId}Counter`);
	$(`#${myResponseId}FormCounter`).val(counterTwo);
	document.getElementById(myResponseId + 'Counter').innerHTML = counter;
	addData(myChart);
});

Chart.defaults.global.defaultFontColor = 'white';
var ctx = document.getElementById('bar-chart-horizontal');
ctx.height = 120;
var myChart = new Chart(ctx, {
	type: 'horizontalBar',
	data: {
		labels: [ 'Him', 'Her' ],
		datasets: [
			{
				backgroundColor: [ '#3e95cd', '#8e5ea2' ],
				data: [ 0, 0 ]
			}
		]
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
			xAxes: [
				{
					gridLines: {
						color: '#262626'
					},
					stacked: true,
					ticks: {
						min: 0 // minimum value
					}
				}
			],
			yAxes: [
				{
					categoryPercentage: 1.0,
					barPercentage: 1.0,
					gridLines: {
						color: '#262626'
					}
				}
			]
		}
	}
});

function addData(myChart) {
	console.log('Add Data Called');
	myChart.data.datasets[0].data = [
		document.getElementById('answerOneCounter').innerHTML,
		document.getElementById('answerTwoCounter').innerHTML
	];
	myChart.update();
}
