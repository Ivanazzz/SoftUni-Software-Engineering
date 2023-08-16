function processChunks(input) {
    function washChunk(chunk) {
        console.log("Transporting and washing");
        return Math.floor(chunk);
    }

    const canCut = (chunk) => chunk / 4 >= target;
    const canLap = (chunk) => chunk - chunk * 0.2 >= target;
    const canGrind = (chunk) => chunk - 20 >= target;
    const canEtch = (chunk) => chunk - 2 >= target - 1;

    const cut = (chunk) => chunk / 4;
    const lap = (chunk) => chunk - chunk * 0.2;
    const grind = (chunk) => chunk - 20;
    const etch = (chunk) => chunk - 2;

    const [target, ...chunks] = input;

    for (let chunk of chunks) {
        console.log(`Processing chunk ${chunk} microns`);

        while (chunk > target) {
            // Cut
            if (canCut(chunk)) {
                let counter = 0;

                while (canCut(chunk)) {
                    chunk = cut(chunk);
                    counter++;
                }

                console.log(`Cut x${counter}`);
                chunk = washChunk(chunk);
            }

            // Lap
            if (canLap(chunk)) {
                let counter = 0;

                while (canLap(chunk)) {
                    chunk = lap(chunk);
                    counter++;
                }

                console.log(`Lap x${counter}`);
                chunk = washChunk(chunk);
            }

            // Grind
            if (canGrind(chunk)) {
                let counter = 0;

                while (canGrind(chunk)) {
                    chunk = grind(chunk);
                    counter++;
                }

                console.log(`Grind x${counter}`);
                chunk = washChunk(chunk);
            }

            // Etch
            if (canEtch(chunk)) {
                let counter = 0;

                while (canEtch(chunk)) {
                    chunk = etch(chunk);
                    counter++;
                }

                console.log(`Etch x${counter}`);
                chunk = washChunk(chunk);
            }
        }

        // X-ray
        if (chunk + 1 === target) {
            chunk++;
            console.log("X-ray x1");
        }

        console.log(`Finished crystal ${target} microns`);
    }
}