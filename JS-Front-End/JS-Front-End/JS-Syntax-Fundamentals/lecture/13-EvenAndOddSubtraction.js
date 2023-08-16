function subtractOddFromEven(array) {
    let evenSum = 0;
    let oddSum = 0;

    array.forEach(function (element) {
        if (element % 2 === 0) {
            evenSum += element;
        }
        else {
            oddSum += element;
        }
    });

    const result = evenSum - oddSum;

    console.log(result);
}