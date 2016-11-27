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
		request.open('POST', 'http://localhost:8080/users', true);
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
		var form = document.getElementById( "test" );
		var output = document.getElementById( "output" );
		form.addEventListener( "submit", function( e ) {
			e.preventDefault();
			var json = toJSONString( this );
			sendPost(json);

		}, false);

	});

})();

function pokazUserow(){
	var ourRequest = new XMLHttpRequest();
	ourRequest.open('GET','http://localhost:8080/users');
	ourRequest.onload=function(){
	//x1='{  "users": [ { "id": 1, "firstName": "Michał", "lastName": "Głazik", "email": "michal.glazik@mail.com", "password": "123456", "sex": "M" }, { "id": 2, "firstName": "Kamil", "lastName": "Hliwa", "email": "elas@mail.com", "password": "password", "sex": "M" }, { "id": 3, "firstName": "Jan", "lastName": "Bachleda", "email": "janbach@a.com", "password": "pswd", "sex": "M" } ] }';
	//var y=JSON.parse(ourRequest.responseText);
	//var y=JSON.parse(x);
	var y=JSON.parse(ourRequest.responseText);
	/*var hateemel="";
	for(i=0;i<y.length; i++){
	hateemel+='<p>'+y[i].id + '. ' +y[i].firstName+" "+ y[i].lastName +" "+y[i].email+" "+y[i].password+" "+y[i].sex+'</p>';
	}
	document.getElementById('uzytkownicy').innerHTML=hateemel;
	*/
	wypisz(y);
	}
	ourRequest.send();
}

	function wypisz(ciag){
	var hateemel="[ID] [FIRST NAME] [LAST NAME] [E-MAIL] [PASSWORD] [SEX]";
	for(i=0;i<ciag.length; i++){
	hateemel+='<p>'+ciag[i].id + '. ' +ciag[i].firstName+" "+ ciag[i].lastName +" "+ciag[i].email+" "+ciag[i].password+" "+ciag[i].sex+'</p>';
	}
	document.getElementById('uzytkownicy').innerHTML=hateemel;
	}