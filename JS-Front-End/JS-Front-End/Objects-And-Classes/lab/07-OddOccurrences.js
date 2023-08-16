function solve(input) {
    const words = input
        .split(' ')
        .map((w) => w.toLowerCase());

    const wordOccurrences = [];

    words.forEach((word) => {
        const existingWord = wordOccurrences.find((w) => w.word === word);
        if (existingWord) {
            existingWord.occurrences++;
        } else {
            wordOccurrences.push({ word, occurrences: 1 });
        }
    });

    const wordsResult = wordOccurrences.filter((word) => word.occurrences % 2 !== 0);

    console.log(wordsResult.map((word) => word.word).join(" "));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');