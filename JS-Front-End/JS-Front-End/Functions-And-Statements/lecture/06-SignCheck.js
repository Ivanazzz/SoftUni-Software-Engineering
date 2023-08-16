function checkNegativeOrPositive(num1, num2, num3) {
    let countOfNegatives = 0;

    if (num1 < 0) {
        countOfNegatives++;
    }
    if (num2 < 0) {
        countOfNegatives++;
    }
    if (num3 < 0) {
        countOfNegatives++;
    }

    const result = countOfNegatives % 2 === 0
        ? "Positive"
        : "Negative";

    console.log(result);
}