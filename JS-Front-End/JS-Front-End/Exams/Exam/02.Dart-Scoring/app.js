window.addEventListener("load", solve);

function solve() {
    const inputSelectors = {
        player: document.querySelector('#player'),
        score: document.querySelector('#score'),
        round: document.querySelector('#round'),
    };

    const selectors = {
        buttonAdd: document.querySelector('#add-btn'),
        buttonClear: document.querySelector('.clear'),
        sureList: document.querySelector('#sure-list'),
        scoreboardList: document.querySelector('#scoreboard-list'),
    };

    selectors.buttonAdd.addEventListener('click', addScore);
    selectors.buttonClear.addEventListener('click', clear);

    function addScore() {
        if (Object.values(inputSelectors).some((selector) => selector.value === '')) {
            return;
        }

        const playerScore = {
            player: inputSelectors.player.value,
            score: Number(inputSelectors.score.value),
            round: Number(inputSelectors.round.value),
        };

        const dartItem = createElement('li', null, ['dart-item'], null, selectors.sureList);
        const article = createElement('article', null, null, null, dartItem);
        createElement('p', playerScore.player, null, null, article);
        createElement('p', `Score: ${playerScore.score}`, null, null, article);
        createElement('p', `Round: ${playerScore.round}`, null, null, article);
        const editButton = createElement('button', 'edit', ['btn', 'edit'], null, dartItem);
        const okButton = createElement('button', 'ok', ['btn', 'ok'], null, dartItem);

        editButton.addEventListener('click', () => {
            Object.keys(inputSelectors).forEach((key) => {
                const selector = inputSelectors[key];
                selector.value = playerScore[key];
            });

            selectors.buttonAdd.disabled = false;
            dartItem.remove();
        });

        okButton.addEventListener('click', () => {
            editButton.remove();
            okButton.remove();
            dartItem.remove();

            selectors.scoreboardList.appendChild(dartItem);
            selectors.buttonAdd.disabled = false;
        });

        selectors.buttonAdd.disabled = true;
        Object.values(inputSelectors).forEach((selector) => selector.value = '');
    }

    function clear() {
        selectors.sureList.innerHTML = '';
        selectors.scoreboardList.innerHTML = '';
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