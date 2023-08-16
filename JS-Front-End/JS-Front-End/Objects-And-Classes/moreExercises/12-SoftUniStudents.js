function solve(input) {
    class Course {
        constructor(name, capacity) {
            this.name = name;
            this.capacity = capacity;
            this.studentsCount = 0;
            this.students = [];
        }
    }
s
    const courses = [];

    for (const line of input) {
        if (line.includes(":")) {
            const [courseName, courseCapacityAsString] = line.split(": ");
            const courseCapacity = Number(courseCapacityAsString);

            const courseIndex = courses.findIndex((c) => c.name === courseName);
            if (courseIndex === -1) {
                courses.push(new Course(courseName, courseCapacity));
            } else {
                courses[courseIndex].capacity += courseCapacity;
            }

        } else if (line.includes("email")) {
            const studentInfo = line.split(" ");
            const usernameAndCredits = studentInfo[0];
            const [username, creditsCountAsString] = usernameAndCredits.split(/\[|\]/);
            const creditsCount = Number(creditsCountAsString);
            const email = studentInfo[3];
            const courseName = studentInfo[5];

            const courseIndex = courses.findIndex((c) => c.name === courseName);
            if (courseIndex !== -1 && courses[courseIndex].capacity > 0) {
                const currentCourse = courses[courseIndex];
                currentCourse.students.push({
                    username,
                    creditsCount,
                    email
                });
                currentCourse.capacity--;
                currentCourse.studentsCount++;
            }
        }
    }

    courses.sort((a, b) => b.studentsCount - a.studentsCount);
    for (const course of courses) {
        console.log(`${course.name}: ${course.capacity} places left`);

        course.students.sort((a, b) => b.creditsCount - a.creditsCount);
        for (const student of course.students) {
            console.log(`--- ${student.creditsCount}: ${student.username}, ${student.email}`);
        }
    }
}

solve([
    'JavaBasics: 2', 
    'user1[25] with email user1@user.com joins C#Basics', 
    'C#Advanced: 3', 
    'JSCore: 4', 
    'user2[30] with email user2@user.com joins C#Basics',
    'user13[50] with email user13@user.com joins JSCore',
    'user1[25] with email user1@user.com joins JSCore', 
    'user8[18] with email user8@user.com joins C#Advanced',
    'user6[85] with email user6@user.com joins JSCore', 'JSCore: 2',
    'user11[3] with email user11@user.com joins JavaBasics',
    'user45[105] with email user45@user.com joins JSCore',
    'user007[20] with email user007@user.com joins JSCore',
    'user700[29] with email user700@user.com joins JSCore',
    'user900[88] with email user900@user.com joins JSCore'
]);

solve([
    'JavaBasics: 15',
    'user1[26] with email user1@user.com joins JavaBasics',
    'user2[36] with email user11@user.com joins JavaBasics',
    'JavaBasics: 5',
    'C#Advanced: 5',
    'user1[26] with email user1@user.com joins C#Advanced',
    'user2[36] with email user11@user.com joins C#Advanced',
    'user3[6] with email user3@user.com joins C#Advanced',
    'C#Advanced: 1',
    'JSCore: 8',
    'user23[62] with email user23@user.com joins JSCore'
]);