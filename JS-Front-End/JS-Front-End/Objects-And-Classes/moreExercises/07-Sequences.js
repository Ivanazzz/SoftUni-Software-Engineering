function solve(input) {
    const arraysHolder = [];

    for (let i = 0; i < input.length; i++) {
        const currentArray = JSON.parse(input[i]).sort((a, b) => b - a);

        if (i === 0) {
            arraysHolder.push(currentArray);
            continue;
        }

        let isUnique = true;
        for (const array of arraysHolder) {
            if (currentArray.length === array.length) {
                for (let j = 0; j < array.length; j++) {
                    if(currentArray[j] !== array[j]) {
                        isUnique = true;
                        break;
                    }

                    isUnique = false;
                }
            }

            if (!isUnique) {
                break;
            }
        }

        if (isUnique) {
            arraysHolder.push(currentArray);
        }
    }

    arraysHolder
        .sort((a, b) => a.length - b.length)
        .forEach((a) => console.log(`[${a.join(", ")}]`));
}

solve([
    "[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"
]);

solve([
    "[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"
]);