function sortList(array) {
    const sortedArray = array.sort((a, b) => a - b);
    const resultArray = [];

    for (let index = 0; index < array.length; index++) {
        const lastIndex = array.length - index - 1;

        if (index > lastIndex) {
            break;
        } else if (index === lastIndex) {
            resultArray.push(sortedArray[index]);
            break;;
        } else {
            resultArray.push(sortedArray[index]);
            resultArray.push(sortedArray[lastIndex]);
        }
    }

    return resultArray;
}

function sortList(array) {
    const sortedArray = array.sort((a, b) => a - b);
    const resultArray = [];
    const length = array.length;

    for (let index = 0; index < length; index++) {
        if (index % 2 === 0) {
            resultArray.push(sortedArray.shift());
        }
        else {
            resultArray.push(sortedArray.pop());
        }
    }

    return resultArray;
}