$(document).ready(function () {
  // Manejar submit del formulario
  $('#frmLogin').on('submit', function (e) {
    e.preventDefault();

    var username = $('#txtUserName').val();
    var password = $('#txtPassword').val();
    var errorDiv = $('#divErrorMessage');

    // Limpiar mensaje de error previo
    errorDiv.hide().text('');

    // Validar campos vacíos
    if (isEmpty(username)) {
      errorDiv.text('El campo Usuario es requerido.').show();
      $('#txtUserName').focus();
      return false;
    }

    if (isEmpty(password)) {
      errorDiv.text('El campo Contraseña es requerido.').show();
      $('#txtPassword').focus();
      return false;
    }

    // Validar credenciales
    if (username === 'admin' && password === 'admin123') {
      // Login exitoso - redirigir a search.html
      window.location.href = 'search.html';
    } else {
      // Login fallido
      errorDiv.text('Usuario o contraseña incorrectos. Por favor, intente nuevamente.').show();
      $('#txtPassword').val('').focus();
    }

    return false;
  });

  // Focus en el primer campo al cargar
  $('#txtUserName').focus();
});
