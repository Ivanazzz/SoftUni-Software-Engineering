function isPerfectNumber(number) {
    let sum = 0;

    for (let index = 1; index < number; index++) {
        if (number % index === 0) {
            sum += index;
        }
    }

    const result = number === sum
        ? "We have a perfect number!"
        : "It's not so perfect.";

    console.log(result);
}

isPerfectNumber(1236498);