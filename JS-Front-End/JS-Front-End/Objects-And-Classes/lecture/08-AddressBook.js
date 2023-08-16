function collectAddresses(arr) {
    const addressBook = arr.reduce((acc, curr) => {
        const [name, address] = curr.split(":");
        acc[name] = address;

        return acc;
    }, {});

    const sorted = Object.entries(addressBook);
    sorted.sort((a, b) => a[0].localeCompare(b[0]));

    sorted.forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}