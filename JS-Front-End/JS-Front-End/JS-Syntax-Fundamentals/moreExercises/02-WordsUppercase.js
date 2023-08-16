function wordsToUpperCase(text) {
    const result = text
        .split(/[\W]+/)
        .filter((w) => w !== "")
        .map((w) => w.toUpperCase())
        .join(", ");
        
    console.log(result);
}