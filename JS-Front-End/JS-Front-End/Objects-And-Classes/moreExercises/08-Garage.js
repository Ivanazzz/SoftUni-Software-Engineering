function solve(input) {
    class Garage {
        constructor(number) {
            this.number = number;
            this.cars = [];
        }
    }

    const garages = [];

    for (const line of input) {
        let [garageNumber, carInfo] = line.split(" - ");
        garageNumber = Number(garageNumber);
        let garageIndex = garages.findIndex((g) => g.number === garageNumber);

        if (garageIndex === -1) {
            garages.push(new Garage(garageNumber));
            garageIndex = garages.length - 1;
        }

        let car = {};
        const carInfoArray = carInfo.split(", ");

        carInfoArray.forEach((ci) => {
                const tokens = ci.split(": ");
                const property = tokens[0];
                const value = tokens[1];
                car[property] = value;
        });

        garages[garageIndex].cars.push(car);
    }

    for (const garage of garages) {
        console.log(`Garage № ${garage.number}`);
        const carsInfo = [];

        for (const car of garage.cars) {
            const carInfo = [];
            Object.entries(car).forEach(([key, value]) => carInfo.push(`${key} - ${value}`));
            console.log(`--- ${carInfo.join(", ")}`);
        } 
    }
}

solve([
    '1 - color: blue, fuel type: diesel', 
    '1 - color: red, manufacture: Audi', 
    '2 - fuel type: petrol', 
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'
]);

solve([
    '1 - color: green, fuel type: petrol',
    '1 - color: dark red, manufacture: VW',
    '2 - fuel type: diesel',
    '3 - color: dark blue, fuel type: petrol'
]);