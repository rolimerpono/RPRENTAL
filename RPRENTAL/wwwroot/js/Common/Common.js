//Toaster Notification
function ShowToaster(Type, Header, Message)
{  
	toastr.options.hideDuration = 2000;
	toastr.options.preventDuplicates = true;
	toastr.options.closeButton = true;
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