$(document).ready(function () {
  // Obtener ID del cliente de la query string
  var clientId = getQueryParam('id');

  if (!clientId) {
    alert('No se especificó un cliente para editar.');
    window.location.href = 'search.html';
    return;
  }

  // Cargar datos del cliente
  var client = getClientById(clientId);

  if (!client) {
    alert('Cliente no encontrado.');
    window.location.href = 'search.html';
    return;
  }

  // Llenar formulario con datos del cliente
  $('#hdnClientId').val(client.id);
  $('#txtClientId').val(client.id);
  $('#txtName').val(client.name);
  $('#txtEmail').val(client.email);
  $('#txtPhone').val(client.phone);
  $('#ddlStatus').val(client.status);

  // Manejar submit del formulario
  $('#frmEdit').on('submit', function (e) {
    e.preventDefault();

    var errorDiv = $('#divValidationErrors');
    var successDiv = $('#divSuccessMessage');

    // Limpiar mensajes previos
    errorDiv.hide().text('');
    successDiv.hide().text('');

    // Obtener valores
    var name = $('#txtName').val();
    var email = $('#txtEmail').val();
    var phone = $('#txtPhone').val();
    var status = $('#ddlStatus').val();

    // Validaciones
    var errors = [];

    if (isEmpty(name)) {
      errors.push('El campo Nombre es requerido.');
    }

    if (isEmpty(email)) {
      errors.push('El campo Email es requerido.');
    } else if (!validateEmail(email)) {
      errors.push('El formato del Email no es válido.');
    }

    if (isEmpty(phone)) {
      errors.push('El campo Teléfono es requerido.');
    }

    if (isEmpty(status)) {
      errors.push('El campo Estado es requerido.');
    }

    // Mostrar errores o guardar
    if (errors.length > 0) {
      var errorMsg = '<ul>';
      errors.forEach(function (error) {
        errorMsg += '<li>' + error + '</li>';
      });
      errorMsg += '</ul>';
      errorDiv.html(errorMsg).show();
      return false;
    }

    // Simular guardado exitoso
    successDiv.html('Los datos del cliente se guardaron exitosamente. ID: ' + clientId).show();

    // Actualizar objeto en memoria (no persiste)
    client.name = name;
    client.email = email;
    client.phone = phone;
    client.status = status;

    // Scroll al mensaje de éxito
    $('html, body').animate({
      scrollTop: successDiv.offset().top - 100
    }, 500);

    return false;
  });

  // Botón cancelar
  $('#btnCancel').on('click', function () {
    if (confirm('¿Está seguro que desea cancelar? Los cambios no guardados se perderán.')) {
      window.location.href = 'search.html';
    }
  });

  // Botón volver
  $('#btnBack').on('click', function () {
    window.location.href = 'search.html';
  });
});
