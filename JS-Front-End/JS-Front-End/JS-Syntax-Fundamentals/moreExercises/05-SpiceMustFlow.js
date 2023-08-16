function calculateDays(yield) {
    const workersConsumation = 26;
    const yieldSpicesDropPerDay = 10;
    let days = 0;
    let spices = 0;

    while (yield >= 100) {
        days++;
        spices += yield - workersConsumation;
        yield -= yieldSpicesDropPerDay;
    }

    spices = spices >= 26
        ? spices - workersConsumation
        : 0;

    console.log(days);
    console.log(spices);
}