function solve(input) {
    const products = input.reduce((acc, curr) => {
        const [key, value] = curr.split(" : ");
        acc[key] = Number(value);
        return acc;
    }, {});

    const sortedKeys = Object.keys(products).sort((a, b) => a.localeCompare(b));

    let letter = sortedKeys[0][0];
    console.log(letter);

    sortedKeys.forEach((key) => {
        if (key[0] !== letter) {
            letter = key[0];
            console.log(letter);
        }
        
        console.log(`  ${key}: ${products[key]}`);
    });
}
    
solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);