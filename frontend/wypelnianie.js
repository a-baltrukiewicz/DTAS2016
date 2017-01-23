function() {
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
		request.open('POST', 'http://localhost:8080/posts', true);
		request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
		request.send(json);
		var text = 'Data Sent';
		document.getElementById('output').innerHTML += json;
		request.onload=function(){
			var y=JSON.parse(request.responseText);
		}
		sleep(10000).then(() => {
			document.getElementById('output').innerHTML = '';
		});
	}
	document.addEventListener("DOMContentLoaded", function() {
		var form = document.getElementById("pollForm");
		var output = document.getElementById("output");
		form.addEventListener("submit", function(e) {
			e.preventDefault();
			var json = toJSONString(this);
			alert(json);
			//sendPostandSaveCookie(json);
		}, false);
	});
})();