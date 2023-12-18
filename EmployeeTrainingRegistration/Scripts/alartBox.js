document.getElementById('showAlert').addEventListener('click', showAlert);

function showAlert() {
    document.getElementById('customAlert').style.display = 'block';
}

function closeAlert() {
    document.getElementById('customAlert').style.display = 'none';
}
