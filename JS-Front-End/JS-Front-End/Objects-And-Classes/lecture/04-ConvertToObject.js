function objConverter(json) {
    const person = JSON.parse(json);
    const entries = Object.entries(person);

    for (let [key, value] of entries) {
        console.log(`${key}: ${value}`);
    }
}