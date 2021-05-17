console.log("1");


jQuery(document).ready(function () {
	Login.init();
});

//$(document).ready(function () {

	//function manter() {
	//console.log("3");



	$('.login-form').validate({

		//errorElement: 'span', //default input error message container
		//errorClass: 'help-block', // default input error message class
		errorClass: 'help-block text-right animated fadeInDown',
		errorElement: 'div',
		errorPlacement: function (error, e) {
			jQuery(e).parents('.form-group > div').append(error);
		},

		focusInvalid: false, // do not focus the last invalid input
		rules: {
			email: {
				required: true
			},
			password: {
				required: true
			},
			remember: {
				required: false
			}
		},
		messages: {
			email: {
				required: "Email é obrigatório."
			},
			password: {
				required: "Password é obrigatório."
			}
		},

		//invalidHandler: function (event, validator) { //display error alert on form submit   
		//	$('.alert-danger', $('.login-form')).show();
		//},

		highlight: function (e) { // hightlight error inputs
			//$(element).closest('.form-group').addClass('has-error'); // set error class to the control group
			jQuery(e).closest('.error').removeClass('has-error').addClass('has-error');
			jQuery(e).closest('.help-block').remove();
		},

		success: function (e) {
			jQuery(e).closest('.error').removeClass('has-error');
			jQuery(e).closest('.help-block').remove();
			//label.closest('.form-group').removeClass('has-error');
			//label.remove();
		},

		//errorPlacement: function (error, element) {
		//	error.insertAfter(element.closest('.input-icon'));
		//},

		submitHandler: function (form) {
			form.submit();
		}

	});

	$('.login-form input').keypress(function (e) {
		if (e.which == 13) {
			if ($('.login-form').validate().form()) {
				$('.login-form').submit();
			}
			return false;
		}
	});

	//}
	console.log("2");



//});