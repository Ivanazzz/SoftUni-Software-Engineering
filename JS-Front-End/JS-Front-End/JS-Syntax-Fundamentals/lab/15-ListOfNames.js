function sortNames(nameArray) {
    nameArray.sort((a, b) => a.localeCompare(b));;

    for (let index = 0; index < nameArray.length; index++) {
        console.log(`${index + 1}.${nameArray[index]}`);
    }
}