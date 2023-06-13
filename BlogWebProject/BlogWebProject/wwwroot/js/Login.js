const form = document.getElementById('login-form');
const username = document.getElementById('username');
const password = document.getElementById('password');
const error = document.getElementById('error');

form.addEventListener('submit', (e) => {
    e.preventDefault();
    if (username.value === '' || password.value === '') {
        error.innerText = 'Please fill in all fields.';
    } else {
        // Code to submit form and check credentials goes here
        error.innerText = '';
        form.submit();
    }
});

