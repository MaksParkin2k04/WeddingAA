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