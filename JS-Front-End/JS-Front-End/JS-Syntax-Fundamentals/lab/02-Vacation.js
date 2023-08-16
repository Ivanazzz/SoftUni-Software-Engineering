function CalculateVacationSum(peopleCount, groupType, dayOfWeek) {
    let price = 0;

    switch (groupType) {
        case "Students":
            switch (dayOfWeek) {
                case "Friday":
                    price = 8.45;
                    break;
                case "Saturday":
                    price = 9.80;
                    break;
                case "Sunday":
                    price = 10.46;
                    break;
            }
            break;
        case "Business":
            switch (dayOfWeek) {
                case "Friday":
                    price = 10.90;
                    break;
                case "Saturday":
                    price = 15.60;
                    break;
                case "Sunday":
                    price = 16;
                    break;
            }
            break;
        case "Regular":
            switch (dayOfWeek) {
                case "Friday":
                    price = 15;
                    break;
                case "Saturday":
                    price = 20;
                    break;
                case "Sunday":
                    price = 22.50;
                    break;
            }
            break;
    }

    let totalPrice = price * peopleCount;

    if (groupType === "Students" && peopleCount >= 30) {
        totalPrice -= totalPrice * 0.15;
    } else if (groupType === "Business" && peopleCount >= 100) {
        totalPrice -= price * 10;
    } else if (groupType === "Regular" && peopleCount >= 10 && peopleCount <= 20) {
        totalPrice -= totalPrice * 0.05;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}