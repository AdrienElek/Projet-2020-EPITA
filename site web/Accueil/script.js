$(function(){
    $("#thank").hide();
    $("button").click(function() {
        $("#thank").show(2000);
    });
   $(window).scroll(function (event) {
    // A chaque fois que l'utilisateur va scroller (descendre la page)
    var y = $(this).scrollTop(); // On récupérer la valeur du scroll vertical
 
    //si cette valeur > à 200 on ajouter la class
    if (y >= 130) {
      $('#nav').css('opacity',"0.7");
    } else {
      // sinon, on l'enlève
      $('#nav').css('opacity',"1");
    }
  });
});