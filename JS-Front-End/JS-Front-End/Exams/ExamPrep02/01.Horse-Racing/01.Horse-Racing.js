function solve(input) {
    const commandTypes = {
        Retake: retake,
        Trouble: trouble,
        Rage: rage,
        Miracle: miracle,
    };

    const horses = input.shift().split('|');
    let line = input.shift();

    while (line !== 'Finish') {
        const [command, ...tokens] = line.split(' ');
        commandTypes[command](...tokens);

        line = input.shift();
    }

    console.log(horses.join('->'));
    console.log(`The winner is: ${horses.splice(-1)}`);
    
    function retake(overtakingHorse, overtakenHorse) {
        const indexOfOvertakingHorse = horses.indexOf(overtakingHorse);
        const indexOfOvertakenHorse = horses.indexOf(overtakenHorse);

        if (indexOfOvertakingHorse !== -1 
            && indexOfOvertakenHorse !== -1
            && indexOfOvertakingHorse < indexOfOvertakenHorse) {
                horses[indexOfOvertakingHorse] = overtakenHorse;
                horses[indexOfOvertakenHorse] = overtakingHorse;

            console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
        }
    }

    function trouble(horseName) {
        const indexOfTheTroubleHorse = horses.indexOf(horseName);

        if (indexOfTheTroubleHorse > 0 && indexOfTheTroubleHorse < horses.length) {
            const indexOfTheHorseBefore = indexOfTheTroubleHorse - 1;
            const nameOfTheHorseBefore = horses[indexOfTheHorseBefore];

            horses[indexOfTheTroubleHorse] = nameOfTheHorseBefore;
            horses[indexOfTheHorseBefore] = horseName;

            console.log(`Trouble for ${horseName} - drops one position.`);
        }
    }

    function rage(horseName) {
        const indexOfTheHorseToRage = horses.indexOf(horseName);
        
        for (let index = indexOfTheHorseToRage; index < indexOfTheHorseToRage + 2; index++) {
            const indexOfCurrentHorse = index;
            const indexOfNextHorse = index + 1;

            if (indexOfNextHorse < horses.length) {
                const nameOfNextHorse = horses[indexOfNextHorse];

                horses[indexOfCurrentHorse] = nameOfNextHorse;
                horses[indexOfNextHorse] = horseName;
            }
        }

        console.log(`${horseName} rages 2 positions ahead.`);
    }

    function miracle() {
        const removedHorse = horses.shift();
        horses.push(removedHorse);

        console.log(`What a miracle - ${removedHorse} becomes first.`);
    }
}

solve(([
    'Bella|Alexia|Sugar',
    'Retake Alexia Sugar',
    'Rage Bella',
    'Trouble Bella',
    'Finish'
]));

solve(([
    'Onyx|Domino|Sugar|Fiona',
    'Trouble Onyx',
    'Retake Onyx Sugar',
    'Rage Domino',
    'Miracle',
    'Finish'
]));

solve(([
    'Fancy|Lilly',
    'Retake Lilly Fancy',
    'Trouble Lilly',
    'Trouble Lilly',
    'Finish',
    'Rage Lilly'
]));