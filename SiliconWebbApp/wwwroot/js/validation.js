const length = (value, minLength = 2) => {
    return value.length >= minLength;
}

const compare = (value, compareValue) => {
    return value === compareValue;
}

const checkBox = (element) => {
    return element.checked;
}

const modelStateHandler = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`);

    if (validationResult) {
        element.classList.remove('input-validation-error');
        spanElement.classList.remove('field-validation-error');
        spanElement.classList.add('field-validation-valid');
        spanElement.innerHTML = '';
    } else {
        element.classList.add('input-validation-error');
        spanElement.classList.add('field-validation-error');
        spanElement.classList.remove('field-validation-valid');
        spanElement.innerHTML = element.dataset.valRequired;
    }
}

const textValidator = (element) => {
    modelStateHandler(element, length(element.value));
}

const checkboxValidator = (element) => {
    modelStateHandler(element, checkBox(element));
}

const emailVal = (element) => {
    const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    modelStateHandler(element, regEx.test(element.value));
}

const passwordVal = (element) => {
    if (element.dataset.valEqualtoOther !== undefined) {
        const otherValue = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', ''))[0].value;
        modelStateHandler(element, compare(element.value, otherValue));
    } else {
        const regEx = /^(?=.*[a-zA-Z])(?=.*\d).{8,}$/;
        modelStateHandler(element, regEx.test(element.value));
    }
}

let forms = document.querySelectorAll('form');
let inputs = document.querySelectorAll('input[data-val="true"]');

inputs.forEach(input => {
    if (input.type === 'checkbox') {
        input.addEventListener('change', () => {
            checkboxValidator(input);
        });
    } else {
        input.addEventListener('input', () => {
            switch (input.type) {
                case 'text':
                    textValidator(input);
                    break;
                case 'email':
                    emailVal(input);
                    break;
                case 'password':
                    passwordVal(input);
                    break;
            }
        });
    }
});
