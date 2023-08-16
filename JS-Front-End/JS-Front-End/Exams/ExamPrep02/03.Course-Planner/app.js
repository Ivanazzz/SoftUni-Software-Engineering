const inputs = {
    title: document.querySelector('#course-name'),
    type: document.querySelector('#course-type'),
    description: document.querySelector('#description'),
    teacher: document.querySelector('#teacher-name'),
};

const buttons = {
    loadCourse: document.querySelector('#load-course'),
    addCourse: document.querySelector('#add-course'),
    editCourse: document.querySelector('#edit-course'),
};

const list = document.querySelector("#list");

const API_URL = 'http://localhost:3030/jsonstore/tasks/';

const courseTypes = ["Long", "Medium", "Short"];

let courses = {};
let currentCourseId = "";

function attachEvents() {
    buttons.loadCourse.addEventListener('click', loadCourses);
    buttons.addCourse.addEventListener('click', addCourse);
    buttons.editCourse.addEventListener('click', editCourse);
}

async function loadCourses() {
    courses = await (await fetch(API_URL)).json();

    Object.values(courses).forEach((course) => {
        const container = createElement('div', null, ['container'], null, list);
        createElement('h2', course.title, null, null, container);
        createElement('h3', course.teacher, null, null, container);
        createElement('h3', course.type, null, null, container);
        createElement('h4', course.description, null, null, container);
        const editButton = createElement('button', 'Edit Course', ['edit-btn'], null, container);
        const finishButton = createElement('button', 'Finish Course', ['finish-btn'], null, container);

        editButton.addEventListener('click', (e) => {
            inputs.title.value = course.title;
            inputs.type.value = course.type;
            inputs.description.value = course.description;
            inputs.teacher.value = course.teacher;

            currentCourseId = container.getAttribute("data-course-id");
            container.remove();

            buttons.addCourse.disabled = true;
            buttons.editCourse.disabled = false;
        });

        finishButton.addEventListener('click', async (e) => {
            await fetch(`${API_URL}/${course._id}`, {
                method: "DELETE",
            });
          
            await loadCourses();
        });
    });
}

async function addCourse() {
    if (Object.values(inputs).some((input) => input.value === '')) {
        return;
    }

    if (!courseTypes.includes(inputs.type.value)) {
        return;
    }

    const course = {
        title: inputs.title.value,
        type: inputs.type.value,
        description: inputs.description.value,
        teacher: inputs.teacher.value,
    };

    await fetch(API_URL, {
        method: "POST",
        body: JSON.stringify(course),
    });

    Object.values(inputs).forEach((input) => {
        input.value = "";
    });

    await loadCourses();
}

async function editCourse() {
    if (!courseTypes.includes(type)) {
        return;
    }

    const course = {
        _id: currentCourseId,
        title: inputs.title.value,
        type: inputs.type.value,
        description: inputs.description.value,
        teacher: inputs.teacher.value,
    };

    await fetch(`${API_URL}/${currentCourseId}`, {
        method: "PUT",
        body: JSON.stringify(course),
    });

    Object.values(inputs).forEach((input) => {
        input.value = "";
    });

    buttons.addCourse.disabled = false;
    buttons.editCourse.disabled = true;

    await loadCourses();
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

attachEvents();