function sumTable() {
    const prices = Array.from(
        document.querySelectorAll("td:nth-child(2)")
    );

    const totalPrice = prices.reduce((acc, curr) => {
        acc += Number(curr.textContent);
        return acc;
    }, 0);

    document.querySelector("#sum").textContent = totalPrice;
}