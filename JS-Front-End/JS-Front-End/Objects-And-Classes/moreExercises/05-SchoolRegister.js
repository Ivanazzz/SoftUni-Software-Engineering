function solve(input) {
    class Grade {
        constructor(grade) {
            this.grade = grade;
            this.students = [];
        }
    }

    const grades = [];

    input.reduce((acc, curr) => {
        const infoArray = curr.split(/,\s|:\s/);
        const name = infoArray[1];
        const grade = Number(infoArray[3]) + 1;
        const avgScore = Number(infoArray[5]);

        if (avgScore >= 3) {
            const existingGrade = grades.find((g) => g.grade === grade);
            if (!existingGrade) {
                grades.push(new Grade(grade));
            }

            const gradeIndex = grades.findIndex((g) => g.grade === grade);
            grades[gradeIndex].students.push({
                name,
                grade,
                avgScore,
            });
        }
        return acc;
    }, {});

    grades.sort((a, b) => a.grade - b.grade);

    for (const grade of grades) {
        console.log(`${grade.grade} Grade`);
        console.log(`List of students: ${grade.students.map((s) => s.name).join(", ")}`);
        
        const totalScoreSum = grade.students
            .map((s) => s.avgScore)
            .reduce((acc, curr) => {
            acc += curr;
            return acc;
        }, 0);
        const studentsCount = grade.students
            .map((s) => s.name).length;

        console.log(`Average annual score from last year: ${(totalScoreSum / studentsCount).toFixed(2)}`);
        console.log();
    }
}

solve([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
    "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
    "Student name: George, Grade: 8, Graduated with an average score: 2.83",
    "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
    "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
    "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
    "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
    "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
    "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
    "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
    "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
    "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
]);

solve([
    'Student name: George, Grade: 5, Graduated with an average score: 2.75',
    'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
    'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
    'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
    'Student name: John, Grade: 9, Graduated with an average score: 2.90',
    'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
    'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
]);