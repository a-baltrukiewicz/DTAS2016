functionSend=function(){
	var objectData =
			{
				firstName: document.getElementById('firstName').value,
				lastName: document.getElementById('lastName').value ,
				email: document.getElementById('email').value,
				password: document.getElementById('password').value,               
				sex: document.getElementById('sex').value               			 
			};
	var objectDataString = JSON.stringify(objectData);
	$.ajax({
				type: "POST",
				url: "https://localhost:8080/users",
				dataType: "json",
				data: {
					o: objectDataString
				},
				success: function (data) {
				   alert('Success');
				},
				error: function () {
				 alert('Error');
				}
			});
}
