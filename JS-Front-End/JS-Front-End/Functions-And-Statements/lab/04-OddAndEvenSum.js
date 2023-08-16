function sumOddAndEven(number) {
    let evenSum = 0;
    let oddSum = 0;

    while (number > 0) {
        const digit = number % 10;
        number = Math.floor(number / 10);

        if (digit % 2 === 0) {
            evenSum += digit;
        } else {
            oddSum += digit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}