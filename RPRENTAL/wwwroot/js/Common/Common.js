//Toaster Notification
function ShowToaster(Type, Header, Message)
{  
	toastr.options.hideDuration = 3000;
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