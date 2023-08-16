function reveal(words, text) {
    const wordsArray = words.split(", ");

    for (let index = 0; index < wordsArray.length; index++) {
        let wordInAsterix = "";
        let currentWord = wordsArray[index];

            for (let index2 = 0; index2 < currentWord.length; index2++) {
                wordInAsterix += "*";
            }

        text = text.replace(wordInAsterix, currentWord);
    }

    console.log(text);
}