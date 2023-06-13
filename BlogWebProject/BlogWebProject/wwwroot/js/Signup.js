const form = document.getElementById('signup-form');
const username = document.getElementById('username');
const email = document.getElementById('email');
const password = document.getElementById('password');
const firstName = document.getElementById('firstName');
const lastName = document.getElementById('lastName');
const error = document.getElementById('error');

form.addEventListener('submit', (e) => {
    e.preventDefault();
    if (username.value === '' || email.value === '' || password.value === '') {
        error.innerText = 'Please fill in all required fields.';
    } else {
        // Code to submit form and create user goes here
        error.innerText = '';
        form.submit();
    }
});

