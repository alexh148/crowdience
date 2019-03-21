$( "#create" ).click(function(event) {
    event.preventDefault()
    console.log("Hello Saule")
    var qArray = [
        document.getElementById("q1").value,
        document.getElementById("q2").value,
        document.getElementById("q3").value,
        document.getElementById("q4").value,
        document.getElementById("q5").value,
        document.getElementById("q6").value,
        document.getElementById("q7").value,
        document.getElementById("q8").value,
        document.getElementById("q9").value,
        document.getElementById("q10").value
    ]
    console.log(qArray);
    localStorage.setItem("questions", JSON.stringify(qArray));
    console.log(localStorage.getItem("questions"))
    $(location).attr('href', '/Host/lobby')
});
