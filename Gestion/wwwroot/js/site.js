function obtenerClientes() {
    fetch("http://localhost:5014/api/Cliente")
        .then(response => response.json())
        .then(clientes => {
            const listaClientes = document.getElementById('clientes-list');
            listaClientes.innerHTML = ''; // Limpiar la lista antes de agregar los nuevos elementos
            clientes.forEach(cliente => {
                const li = document.createElement('li');
                li.textContent = `Id:${cliente.id},Nombre: ${cliente.nombre}, DNI: ${cliente.dni}, Teléfono: ${cliente.telefono}, Email: ${cliente.email}`;
                listaClientes.appendChild(li);
            });
        })
        .catch(error => console.error('Error al obtener clientes:', error));
}



function obtenerClientePorId(id) {
    fetch(`http://localhost:5014/api/Cliente/${id}`)
        .then(response => response.json())
        .then(cliente => {
            console.log('Cliente encontrado:', cliente);
        })
        .catch(error => console.error('Error al obtener el cliente:', error));
}


function agregarCliente() {
    // Obtén los valores de los campos de entrada
    const nombre = document.getElementById('nombreCliente').value;
    const dni = document.getElementById('dniCliente').value;
    const telefono = document.getElementById('telefonoCliente').value;
    const email = document.getElementById('emailCliente').value;

    // Validamos que todos los campos estén llenos
    if (!nombre || !dni || !telefono || !email) {
        console.error("Todos los campos son obligatorios.");
        return;  // Salir si algún campo está vacío
    }

    // Creamos el objeto cliente
    const cliente = {
        nombre: nombre,
        dni: dni,
        telefono: telefono,
        email: email
    };

    console.log("Cliente a agregar:", cliente);  // Verifica el objeto cliente antes de enviarlo

    fetch("http://localhost:5014/api/Cliente", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cliente)
    })
        .then(response => response.json())
        .then(data => {
            console.log('Cliente agregado:', data);
            obtenerClientes(); // Volver a cargar la lista de clientes después de agregar uno nuevo
        })
        .catch(error => console.error('Error al agregar el cliente:', error));
}




function actualizarCliente() {
    // Obtener los valores del formulario
    const id = document.getElementById('idActualizar').value.trim();
    const nombre = document.getElementById('nombreActualizar').value.trim();
    const dni = document.getElementById('dniActualizar').value.trim();
    const telefono = document.getElementById('telefonoActualizar').value.trim();
    const email = document.getElementById('emailActualizar').value.trim();

    // Convertir ID a número
    const numericId = parseInt(id, 10);

    // Validar datos antes de enviar
    if (isNaN(numericId) || !nombre || !dni || !telefono || !email) {
        console.error("Todos los campos son obligatorios y el ID debe ser un número válido.");
        alert("Error: Todos los campos son obligatorios y el ID debe ser válido.");
        return;
    }

    // Crear objeto cliente actualizado
    const cliente = {
        id: numericId,  // Asegurar que el ID está en el JSON si la API lo requiere
        nombre: nombre,
        dni: dni,
        telefono: telefono,
        email: email
    };

    console.log("✅ URL generada:", `http://localhost:5014/api/Cliente/${numericId}`);
    console.log("✅ Datos enviados:", JSON.stringify(cliente));

    fetch(`http://localhost:5014/api/Cliente/${numericId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cliente)
    })
        .then(response => {
            if (response.ok) {
                console.log('✔ Cliente actualizado correctamente.');
                obtenerClientes(); // Recargar lista de clientes
            } else {
                return response.json().then(errorData => {
                    console.error("❌ Error en la API:", errorData);
                    alert("Error al actualizar cliente: " + JSON.stringify(errorData));
                });
            }
        })
        .catch(error => {
            console.error('❌ Error en la solicitud:', error);
            alert("Error en la solicitud. Revisa la consola para más detalles.");
        });
}



function eliminarCliente() {
    const id = document.getElementById('idEliminar').value;  // Obtén el valor del input

    // Verifica que el id es un número y no está vacío
    const numericId = parseInt(id, 10);  // Convierte a número

    if (isNaN(numericId)) {
        console.error("El ID no es válido:", id);
        return;
    }

    console.log("ID a eliminar:", numericId);  // Verifica el id antes de enviarlo

    const url = `http://localhost:5014/api/Cliente/${numericId}`;

    fetch(url, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                console.log('Cliente eliminado');
                obtenerClientes(); // Recarga la lista de clientes
            } else {
                console.error("Error al eliminar el cliente. Status:", response.status);
            }
        })
        .catch(error => {
            console.error('Error al eliminar el cliente:', error);
        });
}
