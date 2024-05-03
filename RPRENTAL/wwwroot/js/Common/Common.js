//Toaster Notification
function ShowToaster(Type, Header, Message)
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

function DisplayImagePreview(event) {
	let imageSrc = URL.createObjectURL(event.target.files[0]);
	$('#image_preview').attr('src', imageSrc);
}


function ReloadDataTable(objDataTable) {
	objDataTable.ajax.reload();
}

function LoadModal(url, modalContent, data = null) {

	$.ajax({
		type: 'GET',
		url: url,
		data: data,
		success: function (result) {
			$(modalContent).html(result);
			$(modalContent.replace('-content', '')).modal('show');
		},
		error: function (xhr, status, error) {
			ShowToaster('error', 'Error', error);
		}
	});

	$(document).on('hidden.bs.modal', modalContent.replace('-content', ''), function () {
		$(modalContent).html('');
	});
}

function HideModal(modalContent) {
	$(modalContent).modal('hide');
}

function InputBoxFocus(input_name, modal_name) {		
	$(document).on('shown.bs.modal', modal_name, function () {

		var input = $(input_name);
		input.focus().select();

		if (input.val().trim() !== '') {
			var inputLength = input.val().length;
			input[0].setSelectionRange(inputLength, inputLength);
		}
	});
}

function IsFieldValid(formSelector) {
	
	if (!$(formSelector)[0].checkValidity()) {
		$(formSelector).addClass('was-validated');
		return false;
	}
	return true;
}

function ValidateEmail(email)
{	

	let is_valid = false;	
	let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
	is_valid = emailPattern.test(email);

	if (!is_valid) {
		$('#email-validation').css('color', 'red').html('Please enter a valid email.');
		return;
	}
}

function GetRowData(objDataTable, btn) {
	return objDataTable.row(btn.closest('tr')).data();
}





$(document).ready(function () {

	let span = document.getElementById('#description-span');

	if (span.scrollHeight > 70) {
		span.style.display = '-webkit-box';
		span.style.webkitBoxOrient = 'vertical';
		span.style.webkitLineClamp = '100'; // Number of lines to show before truncating
		span.style.overflow = 'hidden';
	}


});