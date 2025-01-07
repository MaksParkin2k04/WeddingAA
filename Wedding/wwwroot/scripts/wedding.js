
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
                    }
                    else {
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
document.addEventListener("DOMContentLoaded", () => {
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder');
    const alert = (title, message, type) => {
        const wrapper = document.createElement('div');
        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible" role="alert">`,
            `    <p>${title}</p>`,
            `    <div>${message}</div>`,
            '    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
            '</div>'
        ].join('');
        alertPlaceholder.append(wrapper);
    };
});
document.addEventListener("DOMContentLoaded", () => {
    const mapFrame = document.getElementById("mapFrame");
    if (mapFrame) {
        const mapFrames = document.querySelectorAll("a[href^='https://yandex.ru/map-widget/v1/']");
        if (mapFrames && mapFrames.length > 0) {
            mapFrame.setAttribute("src", mapFrames[0].getAttribute("href"));
            for (let i = 0; i < mapFrames.length; i++) {
                let element = mapFrames[i];
                element.addEventListener("click", (e) => {
                    e.preventDefault();
                    e.stopPropagation();
                    mapFrame.setAttribute("src", element.getAttribute("href"));
                });
            }
        }
    }
});
document.addEventListener("DOMContentLoaded", (e) => {
    try {
        const viewElement = document.getElementById("timer-before-wedding");
        const dateTime = new Date(viewElement.getAttribute("data-datetime"));
        const dayMC = 86400000;
        const hourMC = 3600000;
        const minuteMC = 60000;
        const secondMC = 1000;
        const refreshIntervalId = setInterval(() => {
            const curentDateTime = new Date(dateTime.getTime() - new Date().getTime());
            if (curentDateTime.getTime() > 0) {
                document.getElementById('day').innerText = Math.trunc(curentDateTime.getTime() / dayMC).toString();
                document.getElementById('hour').innerText = Math.trunc((curentDateTime.getTime() % dayMC) / hourMC).toString();
                document.getElementById('minutes').innerText = Math.trunc((curentDateTime.getTime() % dayMC % hourMC) / minuteMC).toString();
                document.getElementById('second').innerText = Math.trunc((curentDateTime.getTime() % dayMC % hourMC % minuteMC) / secondMC).toString();
            }
            else {
                if (refreshIntervalId) {
                    clearInterval(refreshIntervalId);
                }
            }
        }, 1000);
    }
    catch (e) { }
});
//# sourceMappingURL=wedding.js.map