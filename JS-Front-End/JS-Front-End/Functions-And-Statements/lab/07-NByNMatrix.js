function printMatrix(n) {
    for (let i = 0; i < n; i++) {
        const line = [];

        for (let j = 0; j < n; j++) {
            line.push(n);
        }

        console.log(line.join(' '));
    }
}