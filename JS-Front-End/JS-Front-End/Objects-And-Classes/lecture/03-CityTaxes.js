function createCity(name, population, treasury) {
    return {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population += this.population * (percentage / 100);
        },
        applyRecession(percentage) {
            this.treasury -= this.treasury * (percentage / 100);
        },
    }
}