function getSmallestNumber(num1, num2, num3) {
    function returnSmallerNumber(x, y) {
        if (x < y) {
            return x;
        }

        return y;
    }

    let smallestNum = returnSmallerNumber(returnSmallerNumber(num1, num2), returnSmallerNumber(num1, num3));
    console.log(smallestNum);
}