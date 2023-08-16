function factorial(x) {
    if (x === 1) {
        return 1;
    }

    return x * factorial(x - 1);
}

function solve(num1, num2) {
    console.log((factorial(num1) / factorial(num2)).toFixed(2));
}