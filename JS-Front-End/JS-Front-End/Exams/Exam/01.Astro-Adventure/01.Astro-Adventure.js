function solve(input) {
    const commands = {
        Explore: explore,
        Refuel: refuel,
        Breathe: breathe,
    };

    const maxEnergy = 200;
    const maxOxygen = 100;

    const team = [];

    const numberOfAstronauts = Number(input.shift());
    
    for (let index = 0; index < numberOfAstronauts; index++) {
        const lineTokens = input.shift().split(' ');
        const name = lineTokens[0];
        const oxygen = Number(lineTokens[1]);
        const energy = Number(lineTokens[2]);

        const astronaut = {
            name,
            oxygen,
            energy,
        };

        team.push(astronaut);
    }

    let [command, ...tokens] = input.shift().split(' - ');

    while (command !== 'End') {
        commands[command](...tokens);

        [command, ...tokens] = input.shift().split(' - ');
    }

    team.forEach((astronaut) => {
        console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygen}, Energy: ${astronaut.energy}`);
    });

    function explore(astronautName, energyNeeded) {
        const astronautIndex = team.findIndex((astronaut) => astronaut.name === astronautName);
        const astronaut = team[astronautIndex];

        if (astronaut.energy < energyNeeded) {
            console.log(`${astronautName} does not have enough energy to explore!`);
        } else {
            astronaut.energy -= energyNeeded;
            console.log(`${astronautName} has successfully explored a new area and now has ${astronaut.energy} energy!`);
        }
    }

    function refuel(astronautName, amountStr) {
        const amount= Number(amountStr);
        const astronautIndex = team.findIndex((astronaut) => astronaut.name === astronautName);
        const astronaut = team[astronautIndex];

        let refueldEnergy = 0;
        if (astronaut.energy + amount <= maxEnergy) {
            refueldEnergy = amount;
            astronaut.energy += amount;
        } else {
            refueldEnergy = maxEnergy - astronaut.energy;
            astronaut.energy = maxEnergy;
        }
        
        console.log(`${astronautName} refueled their energy by ${refueldEnergy}!`);
    }

    function breathe(astronautName, amountStr) {
        const amount= Number(amountStr);
        const astronautIndex = team.findIndex((astronaut) => astronaut.name === astronautName);
        const astronaut = team[astronautIndex];

        let refueldOxygen = 0;
        if (astronaut.oxygen + amount <= maxOxygen) {
            refueldOxygen = amount;
            astronaut.oxygen += amount;
        } else {
            refueldOxygen = maxOxygen - astronaut.oxygen;
            astronaut.oxygen = maxOxygen;
        }
        
        console.log(`${astronautName} took a breath and recovered ${refueldOxygen} oxygen!`);
    }
}

solve([  
    '3',
    'John 50 120',
    'Kate 80 180',
    'Rob 70 150',
    'Explore - John - 50',
    'Refuel - Kate - 30',
    'Breathe - Rob - 20',
    'End'
]);

solve([    
    '4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'Refuel - Dave - 40',
    'Explore - Bob - 40',
    'Breathe - Charlie - 30',
    'Explore - Alice - 40',
    'End'
]);