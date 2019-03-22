$( "#create" ).click(function(event) {
    event.preventDefault()
    console.log("Hello Saule")
    // Change to C#, save to DB?
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
    localStorage.setItem("questions", JSON.stringify(qArray));
    $(location).attr('href', '/Host/lobby')
});
