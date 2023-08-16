// SOLUTION 1
function solve(input) {
    const dictionary = input
        // ['', '', '', ''] 
        .map(jsonString => JSON.parse(jsonString))
        // map -> [{}, {}, {}, {}]
        .reduce((acc, curr) => {
            return {
                ...acc,
                ...curr, // if we have same acc names the value will be replaced with the last one
            }; // this type of reduce is used when we want to merge objects into one object
        }, {});

    const sortedDictionaryTerms = Object.keys(dictionary).sort();
    sortedDictionaryTerms.forEach((term) => console.log(`Term: ${term} => Definition: ${dictionary[term]}`));
}

// SOLUTION 2
function solve(input) {
    let dictionary = {};

    input.forEach((jsonString) => {
        const term = JSON.parse(jsonString);
        dictionary = Object.assign(dictionary, term);
    });

    const sortedDictionaryTerms = Object.keys(dictionary).sort();
    sortedDictionaryTerms.forEach((term) => console.log(`Term: ${term} => Definition: ${dictionary[term]}`));
}

solve([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]);