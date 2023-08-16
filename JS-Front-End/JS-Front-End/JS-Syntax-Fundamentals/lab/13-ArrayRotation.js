function rotateArray(array, numberOfRotations) {
    for (let index = 0; index < numberOfRotations; index++) {
        const removed = array.shift();
        array.push(removed);
    }

    console.log(array.join(' '));
}