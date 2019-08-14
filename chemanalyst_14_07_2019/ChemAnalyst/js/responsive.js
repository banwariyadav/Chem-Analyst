if($(window).width() < 500){
  $('.top-left span i').click(function(){
    if($('.top-left span i').hasClass('fa-bars')){
    $('.top-left span i').removeClass('fa-bars');
    $('.top-left span i').addClass('fa-close');
    $('.side-wrapper').addClass('mob_display');
    $('.top-inner').addClass('top-inner-mob');
    $('.side-left').addClass('top-bar-mob');
    $('.right-contant-bar').addClass('right-contant-bar-mob');
    }else if($('.top-left span i').hasClass('fa-close')){
      $('.top-left span i').removeClass('fa-close');
    $('.top-left span i').addClass('fa-bars');
    $('.side-wrapper').removeClass('mob_display');
    $('.top-inner').removeClass('top-inner-mob');
    $('.side-left').removeClass('top-bar-mob');
    $('.right-contant-bar').removeClass('right-contant-bar-mob');
    }
  });
}