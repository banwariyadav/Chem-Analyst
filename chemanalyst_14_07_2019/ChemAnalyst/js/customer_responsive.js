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
}else{
  $('.top-left span i').click(function(){
    if($('.top-left span i').hasClass('fa-bars')){
      $('.top-left span i').removeClass('fa-bars');
      $('.top-left span i').addClass('fa-close');
      $('.side-wrapper').css('display','none');
      $('.side-left').css('display','none');
      $('.top-inner').css('width','100%');
      $('.top-inner').css('width','100%');
      $('.right-contant-bar').css('width','100%');
    }else if($('.top-left span i').hasClass('fa-close')){
      $('.top-left span i').removeClass('fa-close');
      $('.top-left span i').addClass('fa-bars');
      $('.side-wrapper').css('display','block');
      $('.side-left').css('display','block');
      $('.top-inner').css('width','80%');
      $('.right-contant-bar').css('width','80%');
    }
  });
}