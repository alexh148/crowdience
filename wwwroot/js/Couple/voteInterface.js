'use strict';

// Defines Hub
let connection = new signalR.HubConnectionBuilder().withUrl('/pollHub').build();

// Opens Connection to Hub
connection.start().catch(function(err) {
	return console.error(err.toString());
});

// When Document loads listen for Question from Host
// When Vote is clicked send Vote to Host
$(document).ready(function() {
	receiveQuestionFromHost();
	receiveIconsFromHost();
	receiveReturnToLobby();
	$('#vote').on('click', function() {
		// event.preventDefault();
		connection.invoke('SendCoupleVote').catch(function(err) {
			return console.error(err.toString());
		});
	});
	$('#username').val(sessionStorage.getItem('username'));
});

// Listen for Question from Host
function receiveQuestionFromHost() {
	connection.on('ReceiveQuestion', function(question) {
		$('#questionTitle').html(question);
	});
}

// Listen for Icons from Host
function receiveIconsFromHost() {
	console.log('Receiving Icons');
	connection.on('ReceiveIconId', function(icon1, icon2) {
		$('#answerOne').html(`<input id="${icon1}2" type="radio" name="CoupleAnswer" value="${icon1}" />
        <label class="drinkcard-cc ${icon1}" for="${icon1}2"></label>`);
		$('#answerTwo').html(`<input id="${icon2}2" type="radio" name="CoupleAnswer" value="${icon2}" />
        <label class="drinkcard-cc ${icon2}" for="${icon2}2"></label>`);
	});
}

// Listen for Return to Lobby
function receiveReturnToLobby() {
	connection.on('ReceiveReturnToLobby', function() {
		console.log('RecievedReturnToLobby');
		sessionStorage.clear();
		$(location).attr('href', '/Couple/Lobby');
	});
}
