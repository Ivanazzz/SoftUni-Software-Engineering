function solve(input) {
    const manageCars = {
        IN: (number) => parking.add(number),
        OUT: (number) => parking.delete(number),
    }

    const parking = new Set();

    input.forEach((entry) => {
        const [direction, number] = entry.split(", ");

        manageCars[direction](number);
    });

    const carNumbers = Array.from(parking)
        .sort()
        .forEach((number) => console.log(number));
}

solve([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);