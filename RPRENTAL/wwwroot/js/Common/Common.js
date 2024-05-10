$(document).ready(function () {

	
	if (localStorage.getItem('loginTriggered')) {
		ShowToaster('success', 'LOGIN USER', 'Login successful!');
		localStorage.removeItem('loginTriggered');
	}

	if (localStorage.getItem('logoutTriggered')) {
		ShowToaster('success', 'LOGOUT USER', 'Logout successful!');
		localStorage.removeItem('logoutTriggered');
	}
});

let ShowToaster = function(Type, Header, Message)
{  

	
	toastr.options.hideDuration = 2000;
	toastr.options.preventDuplicates = 1;
	toastr.options.closeButton = 1;
	toastr.options.positionClass = 'toast-bottom-right';

	
	switch (Type)
	{	
		case 'success':
			toastr.success(Message, Header);
			break;
		case 'error':
			toastr.error(Message, Header);
			break;
		case 'info':
			toastr.info(Message, Header);
			break;
		case 'warning':
			toastr.warning(Message, Header);
			break;		
	}	
}

let DisplayImagePreview = function(event) {
	let imageSrc = URL.createObjectURL(event.target.files[0]);
	$('#image_preview').attr('src', imageSrc);
}


let ReloadDataTable = function(objMainTable) {
	objMainTable.ajax.reload();
}


let LoadModal = function(url, modalContent, data = null) {

	$.ajax({
		type: 'GET',
		url: url,
		data: data,
		success: function (response) {			
			if (response.success) {		
				$(modalContent).html('');
				$(modalContent).html(response.htmlContent);
				$(modalContent.replace('-content', '')).modal('show');
			}
			else {
				ShowToaster('error', '', response.message);
			}		
		},
		error: function (xhr, status, error) {
			ShowToaster('error', 'Error', error);
		}
	});

	$(document).on('hidden.bs.modal', modalContent.replace('-content', ''), function () {
		$(modalContent).html('');
	});
}

let HideModal = function(modalContent) {	
	$(modalContent).modal('hide');
}

let InputBoxFocus = function(input_name, modal_name) {		
	$(document).on('shown.bs.modal', modal_name, function () {

		var input = $(input_name);
		input.focus().select();

		if (input.val() !== '') {
			var inputLength = input.val().length;
			input[0].setSelectionRange(inputLength, inputLength);
		}
	});
}

let IsFieldValid = function(formSelector) {	
	
	if (!$(formSelector)[0].checkValidity()) {
		$(formSelector).addClass('was-validated');
		return false;
	}


	return true;
}

let ValidateEmail = function(email) {	
	
	let is_valid = false;	
	let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
	is_valid = emailPattern.test(email);

	if (!is_valid) {
		$('#email-validation').css('color', 'red').html('Please enter a valid email.');
		return;
	}
}

let GetRowData = function(objTable, btn) {	
	return objTable.row(btn.closest('tr')).data();
}



