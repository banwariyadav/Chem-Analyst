$(document).ready(function() {
    $("#slider").owlCarousel({
		items : 1,
		nav:true,
		dots:true,
		loop:true,
		autoplay:true,
		mouseDrag:true,
		autoplayTimeout:3000,smartSpeed:1000,
		autoplayHoverPause:true,
		navText : ["<span><i class='fa fa-angle-left'></i></span>","<span><i class='fa fa-angle-right'></i></span>"]
      });
    });

$(document).ready(function() {
    $("#work-slider").owlCarousel({
		nav:true,
		dots:false,
		loop:true,
		autoplay:true,
		mouseDrag:true,
		autoplayHoverPause:true,
		navText : ["<span><i class='fa fa-chevron-left'></i></span>","<span><i class='fa fa-chevron-right'></i></span>"],
		responsiveClass: true,
		responsive: {
	  0: {
		items: 1,
		nav: true
	  },
	  600: {
		items: 3,
		nav: false
	  },
	  1000: {
		items: 3,
		nav: false,
		loop: true,
		margin:30
	  }
	}
      });
    });


$(document).ready(function() {
    $("#testimonials").owlCarousel({
		nav:true,
		dots:false,
		loop:true,
		autoplay:true,
		mouseDrag:true,
		autoplayHoverPause:true,
		navText : ["<span><i class='fa fa-angle-left'></i></span>","<span><i class='fa fa-angle-right'></i></span>"],
		responsiveClass: true,
		responsive: {
	  0: {
		items: 1,
		nav: true
	  },
	  600: {
		items:1,
		nav: false
	  },
	  1000: {
		items: 1,
		nav: false,
		loop: true,
		margin:30
	  }
	}
      });
    });


$(document).ready(function() {
  $('.owl-carousel').owlCarousel({
	loop: true,
	responsiveClass: true,
	responsive: {
	  0: {
		items: 1,
		nav: true
	  },
	  600: {
		items: 3,
		nav: false
	  },
	  1000: {
		items: 3,
		nav: false,
		loop: true,
		margin:30
	  }
	}
  })
})


$(document).ready(function(){
$(window).scroll(function(){
if($(this).scrollTop() > 200){
	$('.up').fadeIn(400);
}else{ $('.up').fadeOut(400); }	
});

$('.up').click(function(event){
event.preventDefault();
$('html, body').animate({scrollTop:0}, 800);
});
	
});





jQuery(window).scroll(function(){ 
	var scroll = jQuery(window).scrollTop();
	if (scroll>=150){ 
		jQuery('header').addClass('fixed-nav');
	}
	else{
		jQuery('header').removeClass('fixed-nav');
	}
});


$(function(){
	var $gallery = $('.gallery a').simpleLightbox();

	$gallery.on('show.simplelightbox', function(){
		console.log('Requested for showing');
	})
	.on('shown.simplelightbox', function(){
		console.log('Shown');
	})
	.on('close.simplelightbox', function(){
		console.log('Requested for closing');
	})
	.on('closed.simplelightbox', function(){
		console.log('Closed');
	})
	.on('change.simplelightbox', function(){
		console.log('Requested for change');
	})
	.on('next.simplelightbox', function(){
		console.log('Requested for next');
	})
	.on('prev.simplelightbox', function(){
		console.log('Requested for prev');
	})
	.on('nextImageLoaded.simplelightbox', function(){
		console.log('Next image loaded');
	})
	.on('prevImageLoaded.simplelightbox', function(){
		console.log('Prev image loaded');
	})
	.on('changed.simplelightbox', function(){
		console.log('Image changed');
	})
	.on('nextDone.simplelightbox', function(){
		console.log('Image changed to next');
	})
	.on('prevDone.simplelightbox', function(){
		console.log('Image changed to prev');
	})
	.on('error.simplelightbox', function(e){
		console.log('No image found, go to the next/prev');
		console.log(e);
	});
});
