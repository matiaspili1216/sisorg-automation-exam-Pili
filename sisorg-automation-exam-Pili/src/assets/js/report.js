$(document).ready(function () {
  // Establecer fechas por defecto (último mes)
  var today = new Date();
  var lastMonth = new Date();
  lastMonth.setMonth(lastMonth.getMonth() - 1);

  $('#txtDateFrom').val(formatDate(lastMonth));
  $('#txtDateTo').val(formatDate(today));

  // Manejar generación de reporte
  $('#frmReportFilters').on('submit', function (e) {
    e.preventDefault();
    generateReport();
    return false;
  });

  // Manejar exportación a CSV
  $('#btnExportCSV').on('click', function () {
    exportToCSV();
  });

  // Función para generar reporte
  function generateReport() {
    var dateFrom = $('#txtDateFrom').val();
    var dateTo = $('#txtDateTo').val();
    var status = $('#ddlReportStatus').val();

    // Obtener clientes (filtrar por estado si se seleccionó)
    var clients = status ? filterClients('', '', status) : getAllClients();

    // Mostrar mensaje
    $('#divReportMessage').text('Reporte generado correctamente. Registros encontrados: ' + clients.length).show();

    // Cargar datos en tabla
    loadReportData(clients);

    // Mostrar panel de resultados
    $('#reportResultsPanel').show();
  }

  // Función para cargar datos en la tabla de reporte
  function loadReportData(clients) {
    var tbody = $('#gvReportBody');
    tbody.empty();

    $('#lblReportCount').text(clients.length + ' registros');

    clients.forEach(function (client) {
      var row = '<tr>' +
        '<td>' + client.id + '</td>' +
        '<td>' + client.name + '</td>' +
        '<td>' + client.email + '</td>' +
        '<td>' + client.phone + '</td>' +
        '<td>' + client.status + '</td>' +
        '<td>' + client.registrationDate + '</td>' +
        '</tr>';
      tbody.append(row);
    });
  }

  // Función para exportar a CSV
  function exportToCSV() {
    var tbody = $('#gvReportBody tr');

    if (tbody.length === 0) {
      alert('No hay datos para exportar. Por favor, genere un reporte primero.');
      return;
    }

    // Preparar datos para CSV
    var data = [];
    tbody.each(function () {
      var cells = $(this).find('td');
      data.push({
        'ID': cells.eq(0).text(),
        'Nombre': cells.eq(1).text(),
        'Email': cells.eq(2).text(),
        'Telefono': cells.eq(3).text(),
        'Estado': cells.eq(4).text(),
        'Fecha_Alta': cells.eq(5).text()
      });
    });

    // Generar CSV
    var headers = ['ID', 'Nombre', 'Email', 'Telefono', 'Estado', 'Fecha_Alta'];
    var csvContent = generateCSV(data, headers);

    // Descargar archivo
    var timestamp = new Date().getTime();
    var filename = 'Reporte_Clientes_' + timestamp + '.csv';
    downloadCSV(csvContent, filename);

    // Mostrar mensaje de éxito
    $('#divReportMessage').text('Archivo CSV exportado exitosamente: ' + filename).show();
  }

  // Función auxiliar para formatear fecha
  function formatDate(date) {
    var year = date.getFullYear();
    var month = String(date.getMonth() + 1).padStart(2, '0');
    var day = String(date.getDate()).padStart(2, '0');
    return year + '-' + month + '-' + day;
  }
});
