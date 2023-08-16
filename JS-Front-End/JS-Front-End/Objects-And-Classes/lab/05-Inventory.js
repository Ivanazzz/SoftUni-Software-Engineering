function solve(input) {
    let heroes = [];

    input.forEach((command) => {
        const heroInfo = command.split(" / ");
        const name = heroInfo[0];
        const level = Number(heroInfo[1]);
        const items = heroInfo[2].split(", ");

        heroes.push({
            name,
            level,
            items,
        });
    });

    heroes.sort((a, b) => a.level - b.level);;
    heroes.forEach((hero) => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(", ")}`);
    });
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]);