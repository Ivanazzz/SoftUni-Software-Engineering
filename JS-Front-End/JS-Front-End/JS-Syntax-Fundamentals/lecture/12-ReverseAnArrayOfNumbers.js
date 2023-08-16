function reverseArray(count, array) {
    let resultArray = array.slice(0, count).reverse().join(' ');

    console.log(resultArray);
}