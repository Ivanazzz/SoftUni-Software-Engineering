const calculator = {
    multiply: (x, y) => x * y,
    divide: (x, y) => x / y,
    add: (x, y) => x + y,
    subtract: (x, y) => x - y,
}

function calculate(num1, num2, operator) {
    console.log(calculator[operator](num1, num2));
}