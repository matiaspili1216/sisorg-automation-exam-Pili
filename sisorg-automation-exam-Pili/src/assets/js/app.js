// Utilidades compartidas

// Validar email
function validateEmail(email) {
  var re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return re.test(email);
}

// Validar campo vacío
function isEmpty(value) {
  return !value || value.trim() === '';
}

// Base de datos simulada de clientes
var clientsDatabase = [
  { id: 1, name: 'Juan Pérez', email: 'juan.perez@empresa.com', phone: '555-1001', status: 'Activo', registrationDate: '2024-01-15' },
  { id: 2, name: 'María García', email: 'maria.garcia@empresa.com', phone: '555-1002', status: 'Activo', registrationDate: '2024-02-20' },
  { id: 3, name: 'Carlos López', email: 'carlos.lopez@empresa.com', phone: '555-1003', status: 'Inactivo', registrationDate: '2024-03-10' },
  { id: 4, name: 'Ana Martínez', email: 'ana.martinez@empresa.com', phone: '555-1004', status: 'Activo', registrationDate: '2024-04-05' },
  { id: 5, name: 'Roberto Sánchez', email: 'roberto.sanchez@empresa.com', phone: '555-1005', status: 'Activo', registrationDate: '2024-05-12' },
  { id: 6, name: 'Laura Rodríguez', email: 'laura.rodriguez@empresa.com', phone: '555-1006', status: 'Inactivo', registrationDate: '2024-06-18' },
  { id: 7, name: 'Pedro Fernández', email: 'pedro.fernandez@empresa.com', phone: '555-1007', status: 'Activo', registrationDate: '2024-07-22' },
  { id: 8, name: 'Carmen Díaz', email: 'carmen.diaz@empresa.com', phone: '555-1008', status: 'Activo', registrationDate: '2024-08-30' },
  { id: 9, name: 'Jorge Ramírez', email: 'jorge.ramirez@empresa.com', phone: '555-1009', status: 'Inactivo', registrationDate: '2024-09-14' },
  { id: 10, name: 'Sofía Torres', email: 'sofia.torres@empresa.com', phone: '555-1010', status: 'Activo', registrationDate: '2024-10-25' }
];

// Obtener cliente por ID
function getClientById(id) {
  return clientsDatabase.find(function (client) {
    return client.id == id;
  });
}

// Obtener todos los clientes
function getAllClients() {
  return clientsDatabase.slice();
}

// Filtrar clientes
function filterClients(name, email, status) {
  return clientsDatabase.filter(function (client) {
    var matchName = !name || client.name.toLowerCase().indexOf(name.toLowerCase()) !== -1;
    var matchEmail = !email || client.email.toLowerCase().indexOf(email.toLowerCase()) !== -1;
    var matchStatus = !status || client.status === status;
    return matchName && matchEmail && matchStatus;
  });
}

// Generar CSV
function generateCSV(data, headers) {
  var csv = headers.join(',') + '\n';

  data.forEach(function (row) {
    var rowData = headers.map(function (header) {
      var value = row[header] || '';
      return '"' + value + '"';
    });
    csv += rowData.join(',') + '\n';
  });

  return csv;
}

// Descargar CSV
function downloadCSV(csvContent, filename) {
  var blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
  var link = document.createElement('a');

  if (navigator.msSaveBlob) {
    navigator.msSaveBlob(blob, filename);
  } else {
    link.href = URL.createObjectURL(blob);
    link.download = filename;
    link.style.display = 'none';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }
}

// Obtener parámetro de query string
function getQueryParam(param) {
  var urlParams = new URLSearchParams(window.location.search);
  return urlParams.get(param);
}
