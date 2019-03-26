$(document).ready(function () {
    updateResultIcons();

})

// Updates Result Icons
function updateResultIcons() {
	var icon1 = localStorage.getItem("IconId1")
	var icon2 = localStorage.getItem("IconId2")
	$('#q1a1Icon').html(`<label class="votecard-cc ${icon1}" for="${icon1}2"></label>`);
	$('#q1a2Icon').html(`<label class="votecard-cc ${icon2}" for="${icon1}2"></label>`);
	$('#q2a1Icon').html(`<label class="votecard-cc ${icon1}" for="${icon1}2"></label>`);
	$('#q2a2Icon').html(`<label class="votecard-cc ${icon2}" for="${icon1}2"></label>`);
	$('#q3a1Icon').html(`<label class="votecard-cc ${icon1}" for="${icon1}2"></label>`);
	$('#q3a2Icon').html(`<label class="votecard-cc ${icon2}" for="${icon1}2"></label>`);
	$('#q4a1Icon').html(`<label class="votecard-cc ${icon1}" for="${icon1}2"></label>`);
	$('#q4a2Icon').html(`<label class="votecard-cc ${icon2}" for="${icon1}2"></label>`);
	$('#q5a1Icon').html(`<label class="votecard-cc ${icon1}" for="${icon1}2"></label>`);
	$('#q5a2Icon').html(`<label class="votecard-cc ${icon2}" for="${icon1}2"></label>`);
}

//Charts
Chart.defaults.global.defaultFontColor = "white";
var ctx1 = $('#bc1')[0];
var ctx2 = $('#bc2')[0];
var ctx3 = $('#bc3')[0];
var ctx4 = $('#bc4')[0];
var ctx5 = $('#bc5')[0];

for (var i = 1; i <= 5; i++) {
  var myChart = new Chart(window["ctx" + i], {
    type: "horizontalBar",
    data: {
      labels: ["Him", "Her"],
      datasets: [
        {
          backgroundColor: ["#3e95cd", "#8e5ea2"],
          // Acquires data from Counters, increments with loop
          data: [$(`#q${i}a1`).html(), $(`#q${i}a2`).html()]
        }
      ]
    },
    options: {
      legend: { display: false },
      title: {
        display: true,
        scaleStartValue: 0
      },
      scales: {
        xAxes: [
          {
            gridLines: {
              color: "#262626"
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
              color: "#262626"
            },
            // Hides YAxis Labels
            ticks: {
              display: false
          }
          }
        ]
      }
    }
  });
}