function solve(computer, actions) {
    const browserName = computer["Browser Name"];
    const openTabs = computer["Open Tabs"];
    const recentlyClosed = computer["Recently Closed"];
    const browserLogs = computer["Browser Logs"];

    for (const action of actions) {
        if (action === "Clear History and Cache") {
            openTabs.splice(0, openTabs.length);
            recentlyClosed.splice(0, recentlyClosed.length);
            browserLogs.splice(0, browserLogs.length);

            continue;
        }

        const [command, ...website] = action.split(" ");
        websiteAsString = website[0];

        if (command === "Open") {
            openTabs.push(websiteAsString);
            browserLogs.push(action);
        } else if (command === "Close") {
            const websiteIndex = openTabs.findIndex((t) => t === websiteAsString);
            if (websiteIndex !== -1) {
                openTabs.splice(websiteIndex, 1);
                recentlyClosed.push(websiteAsString);
                browserLogs.push(action);
            }
        }
    }

    console.log(browserName);
    console.log(`Open Tabs: ${openTabs.join(", ")}`);
    console.log(`Recently Closed: ${recentlyClosed.join(", ")}`);
    console.log(`Browser Logs: ${browserLogs.join(", ")}`); 
}

solve(
    {
        "Browser Name":"Google Chrome",
        "Open Tabs":["Facebook","YouTube","Google Translate"],
        "Recently Closed":["Yahoo","Gmail"],
        "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]
    },
    ["Close Facebook", "Open StackOverFlow", "Open Google"]
);