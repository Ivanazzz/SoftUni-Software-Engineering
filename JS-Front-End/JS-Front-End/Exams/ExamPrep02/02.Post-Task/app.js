window.addEventListener("load", solve);

function solve() {
    const inputSelectors = {
        title: document.querySelector('#task-title'),
        category: document.querySelector('#task-category'),
        content: document.querySelector('#task-content'),
    };

    const selectors = {
        publishButton: document.querySelector('#publish-btn'),
        ulReview: document.querySelector('#review-list'),
        ulUploaded: document.querySelector('#published-list'),
    };

    selectors.publishButton.addEventListener('click', publishTask);

    function publishTask() {
        if (Object.values(inputSelectors).some((selector) => selector.value === '')) {
            return;
        }

        const title = inputSelectors.title.value;
        const category = inputSelectors.category.value;
        const content = inputSelectors.content.value;
    
        const li = createElement('li', null, ['rpost'], null, selectors.ulReview);
        const article = createElement('article', null, null, null, li);
        createElement('h4', title, null, null, article);
        createElement('p', `Category: ${category}`, null, null, article);
        createElement('p', `Content: ${content}`, null, null, article);
        const editButton = createElement('button', 'Edit', ['action-btn', 'edit'], null, li);
        const postButton = createElement('button', 'Post', ['action-btn', 'post'], null, li);
    
        editButton.addEventListener('click', () => {
            inputSelectors.title.value = title;
            inputSelectors.category.value = category;
            inputSelectors.content.value = content;

            li.remove();
        });
        postButton.addEventListener('click', () => {
            if (editButton) {
                li.removeChild(editButton);
            }
            if (postButton) {
                li.removeChild(postButton);
            }
    
            selectors.ulUploaded.appendChild(li);
        });
    
        Object.values(inputSelectors).forEach((selector) => selector.value = '');
    }

    function createElement(type, textContent, classes, id, parent) {
        const element = document.createElement(type);
    
        if (textContent) {
            element.textContent = textContent;
        }
    
        if (classes && classes.length > 0) {
            element.classList.add(...classes);
        }
    
        if (id) {
            element.setAttribute('id', id);
        }
    
        if (parent) {
            parent.appendChild(element);
        }
    
        return element;
    }
}