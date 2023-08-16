function checkSpeed(speed, area) {
    let speedLimit = 0;

    switch (area) {
        case "motorway":
            speedLimit = 130;
            break;
        case "interstate":
            speedLimit = 90;
            break;
        case "city":
            speedLimit = 50;
            break;
        case "residential":
            speedLimit = 20;
            break;
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        let status;
        const speedDifference = speed - speedLimit;

        if (speedDifference <= 20) {
            status = "speeding";
        } else if (speedDifference <= 40) {
            status = "excessive speeding";
        } else {
            status = "reckless driving";
        }

        console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

function checkSpeed(speed, area) {
    const speedLimits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20,
    };

    const currentSpeedLimit = speedLimits[area];
    const speedOverLimit = speed - currentSpeedLimit;

    if (speedOverLimit <= 0) {
        console.log(`Driving ${speed} km/h in a ${currentSpeedLimit} zone`);
        return;
    }

    const speedingMessage = 
        speedOverLimit <= 20 
            ? "speeding" 
            : speedOverLimit <= 40 
            ? "excessive speeding"
            : "reckless driving";

    console.log(`The speed is ${speedOverLimit} km/h faster than the allowed speed of ${currentSpeedLimit} - ${speedingMessage}`);
}