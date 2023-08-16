function splitPascalCaseString(pascalCaseString) {
    const words = pascalCaseString
      .replace(/([A-Z])/g, " $1")
      .trim()
      .split(/\s+/);
  
    const result = words.join(", ");
  
    console.log(result);
}