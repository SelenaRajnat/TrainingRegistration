document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("validateRegisterForm");

    form.addEventListener('submit', async (event) => {
        event.preventDefault();
        event.stopPropagation();

        try {
            if (form.checkValidity()) {

                const phoneRegex = /^5[0-9]{7}$/;
                const phoneNumber = form.elements["PhoneNumber"].value;

                if (!phoneRegex.test(phoneNumber)) {
                    alert("Phone Number must contain 8 numbers.");
                    return;
                }
                
                const emailRegex = /^[a-zA-Z0-9]+@ceridian\.com$/i;
                const emailAddress = form.elements["EmailAddress"].value;

                if (!emailRegex.test(emailAddress)) {
                    alert("Invalid email address format");
                    return;
                }

                const newPassword = form.elements["NewPassword"].value;
                const confirmPassword = form.elements["ConfirmPassword"].value;

                if (newPassword !== confirmPassword) {
                    alert("Passwords do not match");
                    return;
                }

                const formData = new FormData(form);

                const response = await fetch('/Register/Verify', {
                    method: 'POST',
                    headers: {},
                    body: formData,
                });

                if (!response.ok) {
                    const errorData = await response.json();
                    throw new Error(errorData.ErrorMessage || 'Unable to register user!');
                }

                const data = await response.json();
                if (data.Success) {
                    window.location = data.url;
                } else {
                    const retryRegistration = confirm(`${data.ErrorMessage}\nDo you want to register again?`);

                    if (retryRegistration) {
                        form.reset();
                    }
                }
            } else {
                form.classList.add('was-validated');
            }
        } catch (error) {
            console.error('Error during registration verification:', error.message);
            alert(error.message);
        }
    });
});


