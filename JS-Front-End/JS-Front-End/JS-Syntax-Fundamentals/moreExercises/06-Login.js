function login(input) {
    const username = input[0];
    const password = username
        .split('')
        .reverse()
        .join('');
    let triesCount = 0;

    for (let index = 1; index < input.length; index++) {
        if (password === input[index]) {
            console.log(`User ${username} logged in.`);
            return;
        }

        triesCount++;
        if (triesCount >= 4) {
            console.log(`User ${username} blocked!`);
            return;
        }

        console.log("Incorrect password. Try again.");
    }
}