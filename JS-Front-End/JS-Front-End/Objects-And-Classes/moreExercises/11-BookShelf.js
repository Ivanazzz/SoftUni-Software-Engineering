function solve(input) {
    class Shelf {
        constructor(id, genre) {
            this.id = id;
            this.genre = genre;
            this.booksCount = 0;
            this.books = [];
        }
    }

    const shelves = [];

    for (const line of input) {
        if (line.includes("->")) {
            const [shelfIdAsString, shelfGenre] = line.split(" -> ");
            const shelfId = Number(shelfIdAsString);

            const shelfDoesntExists = shelves.findIndex((s) => s.id === shelfId) !== -1
                ? false
                : true;
            if (shelfDoesntExists) {
                shelves.push(new Shelf(shelfId, shelfGenre));
            }
        } else if (line.includes(":")) {
            const [title, bookInfo] = line.split(": ");
            const [author, genre] = bookInfo.split(", ");

            const shelfIndex = shelves.findIndex((s) => s.genre === genre);
            if (shelfIndex !== -1) {
                const shelf = shelves[shelfIndex];
                shelf.books.push({
                    title, 
                    author,
                    genre
                });
                shelf.booksCount++;
            }
        }
    }

    shelves.sort((a, b) => b.booksCount - a.booksCount);
    for (const shelf of shelves) {
        console.log(`${shelf.id} ${shelf.genre}: ${shelf.booksCount}`);

        shelf.books.sort((a, b) => a.title.localeCompare(b.title));
        for (const book of shelf.books) {
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }
}

solve([
    '1 -> history', 
    '1 -> action', 
    'Death in Time: Criss Bell, mystery', 
    '2 -> mystery', 
    '3 -> sci-fi', 
    'Child of Silver: Bruce Rich, mystery', 
    'Hurting Secrets: Dustin Bolt, action', 
    'Future of Dawn: Aiden Rose, sci-fi', 
    'Lions and Rats: Gabe Roads, history', 
    '2 -> romance', 
    'Effect of the Void: Shay B, romance', 
    'Losing Dreams: Gail Starr, sci-fi', 
    'Name of Earth: Jo Bell, sci-fi', 
    'Pilots of Stone: Brook Jay, history'
]);

solve([
    '1 -> mystery', 
    '2 -> sci-fi',
    'Child of Silver: Bruce Rich, mystery',
    'Lions and Rats: Gabe Roads, history',
    'Effect of the Void: Shay B, romance',
    'Losing Dreams: Gail Starr, sci-fi',
    'Name of Earth: Jo Bell, sci-fi'
]);