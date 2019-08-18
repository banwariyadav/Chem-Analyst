

    var loc=$(location).prop('href');

    
    var anchor=$('.side-wrapper ul > li > a').length-1;
    
   var count=0;
    while(count <= anchor){
       if($('.side-wrapper ul > li > a')[count]==loc){
        $($('.side-wrapper ul > li > a')[count]).addClass('active');
       }
        count++;
   }
