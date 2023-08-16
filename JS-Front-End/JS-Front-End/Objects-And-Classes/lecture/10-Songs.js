class Song {
    constructor(type, name, length) {
        this.type = type;
        this.name = name;
        this.length = length;
    }
}

function solve(input) {
    const typeToDisplay = input.pop();
    const [_, ...songs] = input; // _ -> removes the first element

    const result = songs
        .map((songAsText) => {
            const [type, name, length] = songAsText.split("_");
            const song = new Song(type, name, length);

            return song;
        })
        .filter((song) => {
            if (typeToDisplay === "all") {
                return song;
            }

            return song.type === typeToDisplay;
        })
        .map((song) => song.name)
        .join("\n");

    console.log(result);
}