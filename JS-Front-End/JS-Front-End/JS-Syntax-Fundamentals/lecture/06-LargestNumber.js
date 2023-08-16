function largestNumber(...input) {
    const sortedInput = input.sort(function(a, b) {
        return b - a;
    });

    const largestNum = sortedInput[0];

    console.log(`The largest number is ${largestNum}.`);
}