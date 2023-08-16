function getCharsInRange(char1, char2) {

    const startCharNum = char1 < char2 ? char1.charCodeAt(0) : char2.charCodeAt(0);
    const endCharNum = char1 > char2 ? char1.charCodeAt(0) : char2.charCodeAt(0);
    const charArray = [];

    for (let index = startCharNum + 1; index < endCharNum; index++) {
        charArray.push(String.fromCharCode(index));
    }

    console.log(charArray.join(' '));
}