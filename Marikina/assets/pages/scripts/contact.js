var Contact = function () {

    return {
        //main function to initiate the module
        init: function () {
			var map;
			$(document).ready(function(){
			  map = new GMaps({
				div: '#gmapbg',
				lat: 14.633379,
				lng: 121.098369
			  });
			   var marker = map.addMarker({
			       lat: 14.633379,
			       lng: 121.098369,
		            title: 'Loop, Inc.',
		            infoWindow: {
		                content: "<b>Marikina, Philippines.</b> Shoe Avenue, Sta. Elena, Marikina City 1800<br>Philippines"
		            }
		        });

			   marker.infoWindow.open(map, marker);
			});
        }
    };

}();

jQuery(document).ready(function() {    
   Contact.init(); 
});

