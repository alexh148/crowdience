$("#startGame").click(function (event) {
    event.preventDefault()
    console.log("Hello Saule")
    // $(location).attr('href', '/Host')
    var data = {
        inProgress: true,
    };
    console.log(data)

    fetch("/api/Game", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    }).then(response => response)


});
