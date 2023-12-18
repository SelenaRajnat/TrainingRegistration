function validateLogin() {
    var email = document.getElementsByName("EmailAddress")[0].value;
    var password = document.getElementsByName("Password")[0].value;
    var errorMessage = "";

    if (!email || email.trim() === "")
        errorMessage += "Please enter an email address.\n";

    if (!password || password.trim() === "")
        errorMessage += "Please enter a password.\n";

    if (errorMessage !== "") {
        alert(errorMessage);
        return false;
    }
    // Ajax request using Fetch API
    fetch('/Login/LogIntoAccount', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ EmailAddress: email, Password: password }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Invalid credentials');
            }
            return response.json();
        })
        .then(data => {

            if (data.Success) {
                window.location = data.url;
            }
            else {
                alert(data.ErrorMessage);
            }
        })
        .catch(error => {

            errorMessage += "Unable to authenticate user!\n";
            alert(errorMessage);
        });
}
