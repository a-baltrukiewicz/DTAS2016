(function() {
	function toJSONString(form) {
		var obj = {};
		var elements = form.querySelectorAll("input, select, textarea");
		for (var i = 0; i < elements.length; ++i) {
			var element = elements[i];
			var name = element.name;
			var value = element.value;
			if (name) {
				obj[name] = value;
			}
		}
		return JSON.stringify(obj);
	}

	function sleep(time) {
		return new Promise((resolve) => setTimeout(resolve, time));
	}

	function sendPostandSaveCookie(json) {
		var request = new XMLHttpRequest(json);
		request.open('POST', 'http://localhost:8080/login', true);
		request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
		request.send(json);
		var text = 'Data Sent';
		document.getElementById('output').innerHTML = json;
		request.onload=function(){
			var y=JSON.parse(request.responseText);
			setCookie('token', y, 1);
			if (getCookie('token').length > 35)
			{
				var email = document.getElementById("loginForm").email.value;
				alert ('Zalogowano jako: ' + email)
			}
			else
			{
				alert("Błędne dane! Spróbuj ponownie!");
			}
		}
		sleep(10000).then(() => {
			document.getElementById('output').innerHTML = '';
		});
	}
	document.addEventListener("DOMContentLoaded", function() {
		var form = document.getElementById("loginForm");
		var output = document.getElementById("output");
		form.addEventListener("submit", function(e) {
			e.preventDefault();
			var json = toJSONString(this);
			sendPostandSaveCookie(json);
		}, false);
	});
})();

function wypisz(ciag) {
	hateemel = ''
	hateemel += ciag
	document.getElementById('output').innerHTML = hateemel;
}
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires="+ d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function eraseCookie(name) {
    createCookie(name,"",-1);
}
