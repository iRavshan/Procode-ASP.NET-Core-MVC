// const accordion = document.querySelector(".nav-mobile");
// const navBar=document.getElementsByClassName("nav-bar");
// accordion.addEventListener("click", () => {
//   console.log("Button clicked.");
//   document.navBar.style.background="Yellow";
//   document.navBar.style.height="600px";

//   });



(function($) { 
    $(function() { 
      $('nav ul li a:not(:only-child)').click(function(e) {
        $(this).siblings('.nav-dropdown').toggle();
        $('.dropdown').not($(this).siblings()).hide();
        e.stopPropagation();
      });
      $('html').click(function() {
        $('.nav-dropdown').hide();
      });
      $('#nav-toggle').click(function() {
        $('nav ul').slideToggle();
      });
      $('#nav-toggle').on('click', function() {
        this.classList.toggle('active');
      });
    }); 
  })(jQuery);