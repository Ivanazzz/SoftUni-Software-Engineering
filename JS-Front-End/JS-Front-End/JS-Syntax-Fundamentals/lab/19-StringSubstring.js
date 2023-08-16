function searchWord(word, text) {
    const wordLower = word.toLowerCase();
    const textLower = text.toLowerCase();
    const textLowerArray = textLower.split(' ');

    if (textLowerArray.includes(wordLower)) {
        console.log(wordLower);
    } else {
        console.log(`${wordLower} not found!`);
    }
}