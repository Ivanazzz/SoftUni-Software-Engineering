function calculateExpenses(lostFightsCount, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let totalPrice = 0;
    const helmetBreakForGamesCount = 2;
    const swordBreakForGamesCount = 3;
    const helmetsCount = Math.floor(lostFightsCount / helmetBreakForGamesCount);
    const swordsCount = Math.floor(lostFightsCount / swordBreakForGamesCount);
    const shieldsCount = Math.floor(lostFightsCount / (helmetBreakForGamesCount * swordBreakForGamesCount));
    const armorsCount = Math.floor(shieldsCount / 2) > 0 
        ? Math.floor(shieldsCount / 2)
        : 0;

    totalPrice += helmetPrice * helmetsCount;
    totalPrice += swordPrice * swordsCount;
    totalPrice += shieldPrice * shieldsCount;
    totalPrice += armorPrice * armorsCount;

    console.log(`Gladiator expenses: ${totalPrice.toFixed(2)} aureus`);
}