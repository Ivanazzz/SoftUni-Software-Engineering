function collectPhones(arr) {
    const phooneObject = arr.reduce((acc, curr) => {
        const [name, phone] = curr.split(' ');
        acc[name] = phone;

        return acc;
    }, {});

    Object.entries(phooneObject).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}