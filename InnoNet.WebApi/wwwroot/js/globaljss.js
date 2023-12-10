//Unused JS


document.addEventListener('DOMContentLoaded', function () {
  // Fetch post content
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
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
  
  function openPost() {
    const myModal = new bootstrap.Modal(document.getElementById('modalId'))
  }
  
  function closePost() {
    document.getElementById('modalId').style.display = 'none';
  }
  
  
//Videos
var videos = ["../videos/pastel-blue-loop", "../videos/pastel-pink-loop.mp4"];
var currentVideoIndex = 0;

function fadeInVideo(video) {
  video.style.opacity = 1;
  video.addEventListener('ended', function() {
    fadeOutVideo(video);
  });
}

function fadeOutVideo(video) {
  video.style.opacity = 0;
  currentVideoIndex = (currentVideoIndex + 1) % videos.length;
  video.src = videos[currentVideoIndex];
  video.load();
  video.play();
  fadeInVideo(video);
}