function toggle() {
    const button = document.querySelector("span.button");
    const content = document.querySelector("#extra");
    
    content.style.display = content.style.display === "block" 
        ? "none" 
        : "block";
    button.textContent = button.textContent === "More"
        ? "Less"
        : "More";
}