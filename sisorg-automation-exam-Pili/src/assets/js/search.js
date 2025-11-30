$(document).ready(function () {
  // Cargar todos los clientes al inicio
  loadClients(getAllClients());

  // Manejar búsqueda
  $('#frmSearch').on('submit', function (e) {
    e.preventDefault();
    performSearch();
    return false;
  });

  // Botón limpiar
  $('#btnClear').on('click', function () {
    $('#txtSearchName').val('');
    $('#txtSearchEmail').val('');
    $('#ddlSearchStatus').val('');
    loadClients(getAllClients());
  });

  // Función para realizar búsqueda
  function performSearch() {
    var name = $('#txtSearchName').val();
    var email = $('#txtSearchEmail').val();
    var status = $('#ddlSearchStatus').val();

    var results = filterClients(name, email, status);
    loadClients(results);
  }

  // Función para cargar clientes en la tabla
  function loadClients(clients) {
    var tbody = $('#gvResultsBody');
    tbody.empty();

    if (clients.length === 0) {
      $('#gvResults').hide();
      $('#divNoResults').show();
      $('#lblResultCount').text('0 registros encontrados');
    } else {
      $('#divNoResults').hide();
      $('#gvResults').show();
      $('#lblResultCount').text(clients.length + ' registros encontrados');

      clients.forEach(function (client) {
        var row = '<tr id="row_' + client.id + '">' +
          '<td>' + client.id + '</td>' +
          '<td>' + client.name + '</td>' +
          '<td>' + client.email + '</td>' +
          '<td>' + client.phone + '</td>' +
          '<td>' + client.status + '</td>' +
          '<td>' +
          '<button type="button" class="btn btn-primary btnEdit" data-id="' + client.id + '">Editar</button>' +
          '</td>' +
          '</tr>';
        tbody.append(row);
      });
    }
  }

  // Manejar click en botón Editar
  $(document).on('click', '.btnEdit', function () {
    var clientId = $(this).data('id');
    window.location.href = 'edit.html?id=' + clientId;
  });
});
