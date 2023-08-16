function solve(input) {
    // Complex Solution
    const employees = input.reduce((acc, curr) => {
        acc[curr] = curr.length;
        return acc;
    }, {});

    Object.entries(employees).forEach(([name, number]) => {
        console.log(`Name: ${name} -- Personal Number: ${number}`);
    });

    // Simple Solution
    //input.forEach((employee) => {
    //    console.log(`Name: ${employee} -- Personal Number: ${employee.length}`);
    //})
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );