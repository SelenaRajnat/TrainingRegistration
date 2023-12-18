document.addEventListener("DOMContentLoaded", () => {
    // Sample data of enrolled employees
    const enrolledEmployees = [
        { id: 1, name: "John Doe", status: "Pending" },
        { id: 2, name: "Jane Smith", status: "Approved" },
        { id: 3, name: "Bob Johnson", status: "Rejected" },
    ];

    const enrolledList = document.getElementById("enrolledList");

    // Function to create list items based on enrolled employees data
    function createEnrolledListItem(employee) {
        const listItem = document.createElement("li");
        listItem.textContent = `${employee.name} - Status: ${employee.status}`;
        listItem.setAttribute("data-id", employee.id);

        // Add additional styling based on status
        if (employee.status === "Approved") {
            listItem.style.color = "green";
        } else if (employee.status === "Rejected") {
            listItem.style.color = "red";
        } else {
            listItem.style.color = "orange";
        }

        return listItem;
    }

    // Function to update the status dynamically
    function updateStatus(employeeId, newStatus) {
        const employeeItem = enrolledList.querySelector(`[data-id="${employeeId}"]`);
        if (employeeItem) {
            // Update the status text
            employeeItem.textContent = `${employeeItem.textContent.split(' - ')[0]} - Status: ${newStatus}`;

            // Update styling based on the new status
            if (newStatus === "Approved") {
                employeeItem.style.color = "green";
            } else if (newStatus === "Rejected") {
                employeeItem.style.color = "red";
            } else {
                employeeItem.style.color = "orange";
            }
        }
    }

    // Display the initial list of enrolled employees
    enrolledEmployees.forEach(employee => {
        enrolledList.appendChild(createEnrolledListItem(employee));
    });

    // Example: Simulate updating the status after some time (e.g., after an approval process)
    setTimeout(() => {
        // Simulate an approval for the employee with id 1
        updateStatus(1, "Approved");
    }, 3000);
});
