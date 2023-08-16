// 1
const carWash = {
    soap: (cleanPercentage) => cleanPercentage + 10,
    water: (cleanPercentage) => cleanPercentage + cleanPercentage * 0.2,
    "vacuum cleaner": (cleanPercentage) => cleanPercentage + cleanPercentage * 0.25,
    mud: (cleanPercentage) => cleanPercentage - cleanPercentage * 0.1,
}

function washCar(commands) {
    let cleanPercentage = 0;

    for (let index = 0; index < commands.length; index++) {
        const command = commands[index];
        cleanPercentage = carWash[command](cleanPercentage);
    }

    console.log(`The car is ${cleanPercentage.toFixed(2)}% clean.`);
}

// 2
function washCar(commands) {
    let cleanPercentage = 0;

    for (let index = 0; index < commands.length; index++) {
        switch (commands[index]) {
            case "soap":
                cleanPercentage += 10;
                break;
            case "water":
                cleanPercentage += cleanPercentage * 0.2;
                break;
            case "vacuum cleaner":
                cleanPercentage += cleanPercentage * 0.25;
                break;
            case "mud":
                cleanPercentage -= cleanPercentage * 0.1;
        }
    }

    console.log(`The car is ${cleanPercentage.toFixed(2)}% clean.`);
}