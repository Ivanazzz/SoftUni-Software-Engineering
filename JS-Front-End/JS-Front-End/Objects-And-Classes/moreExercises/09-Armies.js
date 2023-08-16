function solve(input) {
    class Leader {
        constructor(name) {
            this.name = name;
            this.armies = [];
            this.totalArmiesCount = 0;
        }
    }

    const leaders = [];

    for (const line of input) {
        if (line.includes("arrives")) {
            const leaderName = line.split(" arrives")[0];
            leaders.push(new Leader(leaderName));
        } else if (line.includes("defeated")) {
            const leaderToDelete = line.split(" defeated")[0];
            const leaderIndex = leaders.findIndex((l) => l.name === leaderToDelete);

            if (leaderIndex !== -1) {
                leaders.splice(leaderIndex, 1);
            }
        } else if (line.includes(":")) {
            const [leaderName, armyInfo] = line.split(": ");
            const leaderIndex = leaders.findIndex((l) => l.name === leaderName);

            if (leaderIndex !== -1) {
                const [armyName, armyCountAsString] = armyInfo.split(", ");
                const armyCount = Number(armyCountAsString);
                leaders[leaderIndex].armies.push({
                    armyName,
                    armyCount,
                });
                leaders[leaderIndex].totalArmiesCount += armyCount;
            }
        } else if (line.includes("+")) {
            const [armyNameToSearch, armyCountToAddAsString] = line.split(" + ");
            const armyCountToAdd = Number(armyCountToAddAsString);
            let isFound = false;
            
            for (const leader of leaders) {
                for (const army of leader.armies) {
                    if (army.armyName === armyNameToSearch) {
                        army.armyCount += armyCountToAdd;
                        leader.totalArmiesCount += armyCountToAdd;
                        isFound = true;
                        break;
                    }
                }

                if (isFound) {
                    break;
                }
            }
        }
    }

    leaders.sort((a, b) => b.totalArmiesCount - a.totalArmiesCount);
    
    for (const leader of leaders) {
        console.log(`${leader.name}: ${leader.totalArmiesCount}`);

        leader.armies.sort((a, b) => b.armyCount - a.armyCount);

        for (const army of leader.armies) {
            console.log(`>>> ${army.armyName} - ${army.armyCount}`);
        }
    }
}

solve([
    'Rick Burr arrives', 
    'Fergus: Wexamp, 30245', 
    'Rick Burr: Juard, 50000', 
    'Findlay arrives', 
    'Findlay: Britox, 34540', 
    'Wexamp + 6000', 
    'Juard + 1350', 
    'Britox + 4500',
    'Porter arrives', 
    'Porter: Legion, 55000', 
    'Legion + 302', 
    'Rick Burr defeated', 
    'Porter: Retix, 3205'
]);

solve([
    'Rick Burr arrives', 
    'Findlay arrives', 
    'Rick Burr: Juard, 1500',
    'Wexamp arrives', 
    'Findlay: Wexamp, 34540', 
    'Wexamp + 340', 
    'Wexamp: Britox, 1155', 
    'Wexamp: Juard, 43423'
]);