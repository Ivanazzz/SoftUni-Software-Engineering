function printElements(array, step) {
    const resultArray = [];

    for (let index = 0; index < array.length; index += step) {
        resultArray.push(array[index]);
    }

    return resultArray;
}