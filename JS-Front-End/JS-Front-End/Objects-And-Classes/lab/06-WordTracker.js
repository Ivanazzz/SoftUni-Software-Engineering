function solve(input) {
    const [searchWords, ...words] = input;
    const wordOccurrences = searchWords.split(' ').reduce((acc, curr) => {
        acc[curr] = 0;
        return acc;
    }, {});

    words.forEach((word) => {
        if (wordOccurrences.hasOwnProperty(word)) {
            wordOccurrences[word]++;
        }
    });

    const sortedOccurrences = Object.entries(wordOccurrences).sort((a, b) => b[1] - a[1]);

    sortedOccurrences.forEach(([word, count]) => {
        console.log(`${word} - ${count}`);
    });
}

solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
    ]);