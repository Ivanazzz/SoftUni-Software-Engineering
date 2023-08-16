"use strict";

function checkIfAllDigitsAreSame(number) {
    const digitString = number.toString();
    let isConsistent = true;
    let sum = Number(digitString[0]);

    for (let index = 1; index < digitString.length; index++) {
        sum += Number(digitString[index]);
        if (digitString[index] !== digitString[index - 1]) {
            isConsistent = false;
        }
    }

    console.log(isConsistent);
    console.log(sum);
}


function checkIfAllDigitsAreSame(number) {
    const digits = Array.from(String(number), Number);
    const isConsistent = new Set(digits).size === 1;
    const sum = digits.reduce(function(total, number) {
        return total + number;
    }, 0);

    console.log(isConsistent);
    console.log(sum);
}