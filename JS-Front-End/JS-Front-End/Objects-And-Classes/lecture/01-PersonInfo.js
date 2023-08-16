function createPerson(firstName, lastName, age) {
    return {
        firstName,
        lastName,
        age,

        printInfo: function () {
            console.log(`firstName: ${this.firstName}`);
            console.log(`lastName: ${this.lastName}`);
            console.log(`age: ${this.age}`);
        },
    };
}