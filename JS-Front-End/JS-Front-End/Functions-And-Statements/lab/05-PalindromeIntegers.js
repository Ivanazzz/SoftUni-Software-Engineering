function checkIfPalindrome(number, numberHalfLength) {
    for (let index = 0; index < numberHalfLength; index++) {
        if (number[index] !== number[number.length - index - 1]) {
            return false;
        }
    }

    return true;
}

function isPalindrome(numbers) {
    for (let index = 0; index < numbers.length; index++) {
        const currentNumberAsString = numbers[index].toString();
        const halfLengthOfCurrentNumber = Math.floor(currentNumberAsString / 2);

        console.log(checkIfPalindrome(currentNumberAsString, halfLengthOfCurrentNumber));
    }
}