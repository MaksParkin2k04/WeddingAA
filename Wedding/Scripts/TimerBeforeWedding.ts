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
            } else {
                if (refreshIntervalId) {
                    clearInterval(refreshIntervalId);
                }
            }

        }, 1000);
    } catch (e) { }
});