"use strict";

function checkPointDistanceValidity(x1, y1, x2, y2) {
    isDistanceValid(x1, y1, 0, 0);
    isDistanceValid(x2, y2, 0, 0);
    isDistanceValid(x1, y1, x2, y2);
}

function calculateDistance(x1, y1, x2, y2) {
    return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
}

function isDistanceValid(x1, y1, x2, y2) {
    const distance = calculateDistance(x1, y1, x2, y2);
    const isValid = Number.isInteger(distance);
    const status = isValid ? "valid" : "invalid";

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status}`);
}