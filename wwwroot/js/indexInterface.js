$("#startGame").click(function (event) {
    event.preventDefault()
    let uid = document.getElementById("uid").value;
    localStorage.setItem("uid", uid);
    // $(location).attr('href', '/Host')
    var data = {
        inProgress: true,
        uniqueId: uid
    };

    console.log(uid)
    console.log(data)

    fetch("/api/Game", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    }).then(response => response)

});
