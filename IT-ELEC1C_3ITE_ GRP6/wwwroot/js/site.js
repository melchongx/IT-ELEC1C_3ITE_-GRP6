// Write your JavaScript code.
//Unused JS


document.addEventListener('DOMContentLoaded', function () {
    // Fetch post content
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            // new bootstrap.Modal(document.getElementById('modalId') = this.responseText);
            var parser = new DOMParser();
            var doc = parser.parseFromString(this.responseText, 'text/html');
            // var specificPart = doc.querySelector('#modalId');
            const test = doc.getElementById("modalId").innerHTML = this.responseText;
            console.log(test);
        }
    };
    xhttp.open("GET", "post.html", true);
    xhttp.send();
});