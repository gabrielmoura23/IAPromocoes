var ContactUs = function () {

    return {
        //main function to initiate the module
        init: function () {
			var map;
			$(document).ready(function(){
			  map = new GMaps({
				div: '#map',
	            lat: -13.004333,
				lng: -38.494333,
			  });
			   var marker = map.addMarker({
		            lat: -13.004333,
					lng: -38.494333,
		            title: 'IA Promocoes',
		            infoWindow: {
		                content: "<b>IA Promocoes</b> Rua do teste, 123<br>Salvador, BA 41950-000"
		            }
		        });

			   marker.infoWindow.open(map, marker);
			});
        }
    };

}();