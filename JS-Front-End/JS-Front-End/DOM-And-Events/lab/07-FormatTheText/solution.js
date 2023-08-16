function solve() {
  const input = document.querySelector("#input").value.split(".");
  // clear empty last element
  input.pop();

  const container = document.querySelector("#output");

  while (input.length > 0) {
    const p = document.createElement("p");
    p.textContent = input
      .splice(0, 3)
      .map((text) => text.trim())
      .join(".") + ".";
    container.appendChild(p);
  }
}