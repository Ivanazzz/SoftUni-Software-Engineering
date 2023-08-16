function solve(input) {
    const commands = {
        StopForFuel: stopForFuel,
        Overtaking: overtaking,
        EngineFail: engineFail,
    };

    const riders = [];

    const numberOfRiders = Number(input.shift());
    
    for (let index = 0; index < numberOfRiders; index++) {
        const lineTokens = input.shift().split('|');
        const name = lineTokens[0];
        const fuelCapacity = Number(lineTokens[1]);
        const position = Number(lineTokens[2]);

        const rider = {
            name,
            fuelCapacity,
            position,
        };

        riders.push(rider);
    }

    let [command, ...tokens] = input.shift().split(' - ');

    while (command !== 'Finish') {
        commands[command](...tokens);

        [command, ...tokens] = input.shift().split(' - ');
    }

    riders.forEach((rider) => {
        console.log(rider.name);
        console.log(`  Final position: ${rider.position}`);
    });

    function stopForFuel(riderName, minFuel, changedPosition) {
        const riderIndex = riders.findIndex((rider) => rider.name === riderName);
        const rider = riders[riderIndex];

        if (rider.fuelCapacity < Number(minFuel)) {
            rider.position = Number(changedPosition);
            console.log(`${riderName} stopped to refuel but lost his position, now he is ${changedPosition}.`);
        } else {
            console.log(`${riderName} does not need to stop for fuel!`);
        }
    }

    function overtaking(rider1Name, rider2Name) {
        const rider1Index = riders.findIndex((rider) => rider.name === rider1Name);
        const rider2Index = riders.findIndex((rider) => rider.name === rider2Name);

        const rider1Position = riders[rider1Index].position;
        const rider2Position = riders[rider2Index].position;

        if (rider1Position < rider2Position) {
            riders[rider1Index].position = rider2Position;
            riders[rider2Index].position = rider1Position;

            console.log(`${rider1Name} overtook ${rider2Name}!`);
        }
    }

    function engineFail(riderName, lapsLeft) {
        const riderIndex = riders.findIndex((rider) => rider.name === riderName);
        riders.splice(riderIndex, 1);

        console.log(`${riderName} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
    }
}

solve(([
    "3",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|2",
    "Jorge Lorenzo|80|3",
    "StopForFuel - Valentino Rossi - 50 - 1",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"
]));

solve(([
    "4",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|3",
    "Jorge Lorenzo|80|4",
    "Johann Zarco|80|2",
    "StopForFuel - Johann Zarco - 90 - 5",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"
]));