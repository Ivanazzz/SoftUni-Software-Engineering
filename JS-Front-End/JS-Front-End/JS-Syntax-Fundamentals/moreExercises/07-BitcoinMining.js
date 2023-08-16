function calculateDays(shifts) {
    const bitcoinPrice = 11949.16;
    const goldPricePerGram = 67.51;
    const goldStolen = 0.3;
    const dayToSteal = 3;

    let boughtBitcoins = 0;
    let firstPurchasedBitcoinDay = 0;
    let money = 0;

    for (let index = 0; index < shifts.length; index++) {
        let currentShiftGold = shifts[index];

        if ((index + 1) % dayToSteal === 0) {
            currentShiftGold -= currentShiftGold * goldStolen;
        }

        money += currentShiftGold * goldPricePerGram;

        if (money >= bitcoinPrice) {
            const bitcoins = Math.floor(money / bitcoinPrice);
            money -= bitcoinPrice * bitcoins;
            boughtBitcoins += bitcoins;
            
            if (firstPurchasedBitcoinDay === 0) {
                firstPurchasedBitcoinDay = index + 1;
            }
        }
    }

    console.log(`Bought bitcoins: ${boughtBitcoins}`);

    if (boughtBitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstPurchasedBitcoinDay}`);
    }

    console.log(`Left money: ${money.toFixed(2)} lv.`);
}