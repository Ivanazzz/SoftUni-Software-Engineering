function checkYear(year) {
    let leapYear = "no";

    if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
        leapYear = "yes";
    }

    console.log(leapYear);
}