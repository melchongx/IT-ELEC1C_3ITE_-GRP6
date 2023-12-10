//Modals
document.addEventListener('DOMContentLoaded', function () {
    // Fetch modal content
    fetch('post.html')
      .then(response => response.text())
      .then(data => {
        document.getElementById('postContainer').innerHTML = data;
      })
      .catch(error => console.error('Error fetching modal content:', error));
  });
  
  function openModal() {
    document.getElementById('modalId').style.display = 'block';
  }
  
  function closeModal() {
    document.getElementById('modalId').style.display = 'none';
  }