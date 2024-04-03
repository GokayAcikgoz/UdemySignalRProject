var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:7052/SignalRHub").build();
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var spam = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` :${messae} - ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);

});



connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("sendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});