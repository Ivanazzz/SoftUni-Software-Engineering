window.addEventListener("load", solve);

function solve() {
    const inputSelectors = {
        student: document.querySelector('#student'),
        university: document.querySelector('#university'),
        score: document.querySelector('#score'),
    };
    
    const selectors = {
        buttonNext: document.querySelector('#next-btn'),
        previewList: document.querySelector('#preview-list'),
        candidatesList: document.querySelector('#candidates-list'),
    };

    selectors.buttonNext.addEventListener('click', addToPreview);

    function addToPreview() {
        if (Object.values(inputSelectors).some((selector) => selector.value === '')) {
          return;
        }

        const scholarship = {
            student: inputSelectors.student.value,
            university: inputSelectors.university.value,
            score: Number(inputSelectors.score.value),
        };

        const li = createElement('li', null, ['application'], null, selectors.previewList);
        const article = createElement('article', null, null, null, li);
        createElement('h4', scholarship.student, null, null, article);
        createElement('p', `University: ${scholarship.university}`, null, null, article);
        createElement('p', `Score: ${scholarship.score}`, null, null, article);
        const editButton = createElement('button', 'edit', ['action-btn', 'edit'], null, li);
        const applyButton = createElement('button', 'apply', ['action-btn', 'apply'], null, li);

        editButton.addEventListener('click', () => {
            Object.keys(inputSelectors).forEach((key) => {
                const selector = inputSelectors[key];
                selector.value = scholarship[key];
            });

            li.remove();
            selectors.buttonNext.disabled = false;
        });

        applyButton.addEventListener('click', () => {
            editButton.remove();
            applyButton.remove();
            selectors.buttonNext.disabled = false;

            li.remove();
            selectors.candidatesList.appendChild(li);
        });

        Object.values(inputSelectors).forEach((selector) => selector.value = '');

        selectors.buttonNext.disabled = true;
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