function displayNumbersAndSum(start, end) {
    const numbers = [];
    let sum = 0;

    for (let element = start; element <= end; element++) {
        numbers.push(element);
        sum += element;
    }

    console.log(numbers.join(' '));
    console.log(`Sum: ${sum}`);
}