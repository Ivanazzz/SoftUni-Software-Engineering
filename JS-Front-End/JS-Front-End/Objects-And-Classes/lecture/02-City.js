function printCityInfo1(city) {
    for (const key in city) {
        console.log(key + ' -> ' + city[key]);
    }
}

function printCityInfo2(city) {
    Object.entries(city).forEach(function([key, value]) {
        console.log(key + ' -> ' + value);
    });
}

const city = {
    name: 'Sofia',
    area: 492,
    population: 1238438,
    country: 'Bulgaria',
    postCode: 1000,
};