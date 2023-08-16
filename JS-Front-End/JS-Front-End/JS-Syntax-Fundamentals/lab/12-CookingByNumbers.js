function cookByNumbers(number, ...commands) {
    let sum = Number(number);

    for (let index = 0; index < commands.length; index++) {
        const command = commands[index];

        switch (command) {
            case "chop":
                sum /= 2;
                break;
            case "dice":
                sum = Math.sqrt(sum);
                break;
            case "spice":
                sum++;
                break;
            case "bake":
                sum *= 3;
                break;
            case "fillet":
                sum -= sum * 0.2;
                break;
        }

        console.log(sum);
    }
}