
document.addEventListener("DOMContentLoaded", () => {
    const audioPlayerElement = document.getElementById("audio-player-element");
    let playing = false;

    if (audioPlayerElement) {
        const url = audioPlayerElement.getAttribute("href");
        const playClass = audioPlayerElement.getAttribute("data-play-class");

        if (url) {

            const player = new Audio(url);
            player.preload = "auto";
            player.addEventListener('ended', function () {
                playing = false;
            });

            if (audioPlayerElement) {
                audioPlayerElement.addEventListener("click", (e) => {
                    e.stopPropagation();
                    e.preventDefault();

                    if (playing) {
                        player.pause();
                        if (playClass) {
                            audioPlayerElement.classList.remove(playClass);
                        }
                    } else {
                        player.play();
                        if (playClass) {
                            audioPlayerElement.classList.add(playClass);
                        }
                    }

                    playing = !playing;
                });
            }
        }
    }
});