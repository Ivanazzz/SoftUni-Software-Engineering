function modifyNumber(number) {
    const digitsArray = number
        .toString()
        .split('')
        .map(x => Number(x));
    
    while (digitsArray.reduce((a, b) => a + b, 0) / digitsArray.length <= 5) {
        digitsArray.push(9);
    }

    console.log(digitsArray.join(""));
}

modifyNumber(5835);