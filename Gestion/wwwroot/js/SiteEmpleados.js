function obtenerEmpleados() {
    fetch("http://localhost:5014/api/Empleado")
        .then(response => response.json())
        .then(empleados => {
            const listaEmpleados = document.getElementById('empleados-list');
            listaEmpleados.innerHTML = ''; // Limpiar la lista antes de agregar los nuevos elementos
            empleados.forEach(empleado => {
                const li = document.createElement('li');
                li.textContent = `Id:${empleado.id}, Nombre: ${empleado.nombre}, Puesto: ${empleado.puesto}, Teléfono: ${empleado.telefono}, Salario: ${empleado.salario}`;
                listaEmpleados.appendChild(li);
            });
        })
        .catch(error => console.error('Error al obtener empleados:', error));
}

function obtenerEmpleadoPorId(id) {
    fetch(`http://localhost:5014/api/Empleado/${id}`)
        .then(response => response.json())
        .then(empleado => {
            console.log('Empleado encontrado:', empleado);
        })
        .catch(error => console.error('Error al obtener el empleado:', error));
}

function agregarEmpleado() {
    // Obtén los valores de los campos de entrada
    const nombre = document.getElementById('nombreEmpleado').value;
    const puesto = document.getElementById('puestoEmpleado').value;
    const telefono = document.getElementById('telefonoEmpleado').value;
    const salario = document.getElementById('salarioEmpleado').value;

    // Validamos que todos los campos estén llenos
    if (!nombre || !puesto || !telefono || !salario) {
        console.error("Todos los campos son obligatorios.");
        return;  // Salir si algún campo está vacío
    }

    // Creamos el objeto empleado
    const empleado = {
        nombre: nombre,
        puesto: puesto,
        telefono: telefono,
        salario: salario
    };

    console.log("Empleado a agregar:", empleado);  // Verifica el objeto empleado antes de enviarlo

    fetch("http://localhost:5014/api/Empleado", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(empleado)
    })
        .then(response => response.json())
        .then(data => {
            console.log('Empleado agregado:', data);
            obtenerEmpleados(); // Volver a cargar la lista de empleados después de agregar uno nuevo
        })
        .catch(error => console.error('Error al agregar el empleado:', error));
}

function actualizarEmpleado() {
    // Obtener los valores del formulario
    const id = document.getElementById('idActualizarEmpleado').value.trim();
    const nombre = document.getElementById('nombreActualizarEmpleado').value.trim();
    const puesto = document.getElementById('puestoActualizarEmpleado').value.trim();
    const telefono = document.getElementById('telefonoActualizarEmpleado').value.trim();
    const salario = document.getElementById('salarioActualizarEmpleado').value.trim();

    // Convertir ID a número
    const numericId = parseInt(id, 10);

    // Validar datos antes de enviar
    if (isNaN(numericId) || !nombre || !puesto || !telefono || !salario) {
        console.error("Todos los campos son obligatorios y el ID debe ser un número válido.");
        alert("Error: Todos los campos son obligatorios y el ID debe ser válido.");
        return;
    }

    // Crear objeto empleado actualizado
    const empleado = {
        id: numericId,  // Asegurar que el ID está en el JSON si la API lo requiere
        nombre: nombre,
        puesto: puesto,
        telefono: telefono,
        salario: salario
    };

    console.log("✅ URL generada:", `http://localhost:5014/api/Empleado/${numericId}`);
    console.log("✅ Datos enviados:", JSON.stringify(empleado));

    fetch(`http://localhost:5014/api/Empleado/${numericId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(empleado)
    })
        .then(response => {
            if (response.ok) {
                console.log('✔ Empleado actualizado correctamente.');
                obtenerEmpleados(); // Recargar lista de empleados
            } else {
                return response.json().then(errorData => {
                    console.error("❌ Error en la API:", errorData);
                    alert("Error al actualizar empleado: " + JSON.stringify(errorData));
                });
            }
        })
        .catch(error => {
            console.error('❌ Error en la solicitud:', error);
            alert("Error en la solicitud. Revisa la consola para más detalles.");
        });
}

function eliminarEmpleado() {
    const id = document.getElementById('idEliminarEmpleado').value;  // Obtén el valor del input

    // Verifica que el id es un número y no está vacío
    const numericId = parseInt(id, 10);  // Convierte a número

    if (isNaN(numericId)) {
        console.error("El ID no es válido:", id);
        return;
    }

    console.log("ID a eliminar:", numericId);  // Verifica el id antes de enviarlo

    const url = `http://localhost:5014/api/Empleado/${numericId}`;

    fetch(url, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                console.log('Empleado eliminado');
                obtenerEmpleados(); // Recarga la lista de empleados
            } else {
                console.error("Error al eliminar el empleado. Status:", response.status);
            }
        })
        .catch(error => {
            console.error('Error al eliminar el empleado:', error);
        });
}
