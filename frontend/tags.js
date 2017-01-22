	function pokazTagi(){
	var ourRequest = new XMLHttpRequest();
	ourRequest.open('GET','http://localhost:8080/tags');
	ourRequest.onload=function(){
	var y=JSON.parse(ourRequest.responseText);
	wypiszT(y);
	}
	ourRequest.send();
}

function wypiszT(ciag){
	var hateemel="<table><tr><th>[ID]</th> <th>[NAME]</th><tr>";
	for(i=0;i<ciag.length; i++){
	hateemel+='<tr><th>'+ciag[i].id + "</th><th>" +ciag[i].name+"</th></tr>";
	}
	hateemel+='</table>'
	document.getElementById('tagi').innerHTML=hateemel;
	}
	
(function() {
	function toJSONString( form ) {
		var obj = {};
		var elements = form.querySelectorAll( "input, select, textarea" );
		for( var i = 0; i < elements.length; ++i ) {
			var element = elements[i];
			var name = element.name;
			var value = element.value;

			if( name ) {
				obj[ name ] = value;
			}
		}

		return JSON.stringify( obj );
	}
	
	function sleep (time) 
	{
		return new Promise((resolve) => setTimeout(resolve, time));
	}
	
	function sendPost(json)
	{
		var request = new XMLHttpRequest(json);
		request.open('POST', 'http://localhost:8080/tags', true);
		request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
		request.send(json);
		var text = 'Data Sent'
		document.getElementById('output').innerHTML=json;
		sleep(5000).then(() => 
		{
			document.getElementById('output').innerHTML='';
		});
		
	}

	document.addEventListener( "DOMContentLoaded", function() {
		var form = document.getElementById( "tagg" );
		var output = document.getElementById( "out" );
		form.addEventListener( "submit", function( e ) {
			e.preventDefault();
			var json = toJSONString( this );
			sendPost(json);

		}, false);

	});

})();