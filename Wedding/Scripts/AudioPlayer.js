document.addEventListener("DOMContentLoaded", function () {
    var button = document.getElementById("audio-player-button");
    var playing = false;
    var player = new Audio("/audio/98ff11a779ef4af68afd93e0a8b46b0f.mp3");
    player.preload = "auto";
    player.addEventListener('ended', function () {
        button.innerText = "Done";
        playing = false;
    });
    button.addEventListener("click", function () {
        if (playing) {
            player.pause();
        }
        else {
            player.play();
        }
        playing = !playing;
    });
});
//# sourceMappingURL=AudioPlayer.js.map