function solve(input) {
    class Article {
        constructor(name) {
            this.name = name;
            this.commentsCount = 0;
            this.users = [];
        }
    }

    const users = [];
    const articles = [];

    for (const line of input) {
        if (line.includes("user")) {
            const username = line.split(" ")[1];
            users.push(username);
        } else if (line.includes("article")) {
            const articleName = line.split(" ")[1];
            articles.push(new Article(articleName));
        } else if (line.includes("posts")) {
            const [userArticleInfo, commentInfo] = line.split(": ");
            const username = userArticleInfo.split(" ")[0];
            const articleName = userArticleInfo.split(" ")[3];
            const [title, content] = commentInfo.split(", ");

            const userIndex = users.findIndex((u) => u === username);
            const articleIndex = articles.findIndex((a) => a.name === articleName);

            if (userIndex !== -1 && articleIndex !== -1) {
                const user = {
                    username,
                    title,
                    content,
                };

                const currentArticle = articles[articleIndex];
                currentArticle.users.push(user);
                currentArticle.commentsCount++;
            }
        }
    }

    articles.sort((a, b) => b.commentsCount - a.commentsCount);
    for (const article of articles) {
        console.log(`Comments on ${article.name}`);

        article.users.sort((a, b) => a.username.localeCompare(b.username));
        for (const user of article.users) {
            console.log(`--- From user ${user.username}: ${user.title} - ${user.content}`);
        }
    }
}

solve([
    'user aUser123', 
    'someUser posts on someArticle: NoTitle, stupidComment', 
    'article Books',
    'article Movies', 
    'article Shopping', 
    'user someUser', 
    'user uSeR4', 
    'user lastUser', 
    'uSeR4 posts on Books: I like books, I do really like them', 
    'uSeR4 posts on Movies: I also like movies, I really do', 
    'someUser posts on Shopping: title, I go shopping every day',
    'someUser posts on Movies: Like, I also like movies very much'
]);

solve([
    'user Mark', 
    'Mark posts on someArticle: NoTitle, stupidComment', 
    'article Bobby',
    'article Steven', 
    'user Liam', 
    'user Henry', 
    'Mark posts on Bobby: Is, I do really like them', 
    'Mark posts on Steven: title, Run', 
    'someUser posts on Movies: Like'
]);