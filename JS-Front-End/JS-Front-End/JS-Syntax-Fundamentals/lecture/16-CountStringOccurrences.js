function countOccurrences(text, word) {
    const occurrencesArray = text.split(' ').filter(function (element) {
        return element === word;
    });

    const occurrences = occurrencesArray.length;

    console.log(occurrences);
}