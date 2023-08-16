function solve(input) {
    let movies = [];

    input.forEach(command => {
        if (command.includes("addMovie")) {
            const [_, name] = command.split("addMovie ");
            movies.push({
                name,
            });
        } else if (command.includes("directedBy")) {
            const [movieName, directorName] = command.split(" directedBy ");
            const movie = movies.find((m) => m.name === movieName)

            if (movie) {
                movie.director = directorName;
            }
        } else if (command.includes("onDate")) {
            const [movieName, date] = command.split(" onDate ");
            const movie = movies.find((m) => m.name === movieName)

            if (movie) {
                movie.date = date;
            }
        }
    });

    movies
        .filter((m) => m.name && m.director && m.date)
        .forEach((m) => console.log(JSON.stringify(m)));
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);