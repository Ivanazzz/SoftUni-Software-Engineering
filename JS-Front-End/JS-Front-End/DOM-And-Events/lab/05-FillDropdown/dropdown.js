function addItem() {
    const textInput = document.querySelector("#newItemText");
    const valueInput = document.querySelector("#newItemValue");

    const option = document.createElement('option');
    option.textContent = textInput.value;
    option.value = valueInput.value;

    const select = document.querySelector('#menu');
    select.appendChild(option);
    textInput.value = "";
    valueInput.value = "";
}