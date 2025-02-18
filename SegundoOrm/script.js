function obtenerClientes() {
    fetch("/api/Cliente")
        .then(response => response.json())
        .then(clientes => {
            const listaClientes = document.getElementById('clientes-list');
            listaClientes.innerHTML = ''; // Limpiar la lista antes de agregar los nuevos elementos
            clientes.forEach(cliente => {
                const li = document.createElement('li');
                li.textContent = `Nombre: ${cliente.nombre}, DNI: ${cliente.dni}, Teléfono: ${cliente.telefono}, Email: ${cliente.email}`;
                listaClientes.appendChild(li);
            });
        })
        .catch(error => console.error('Error al obtener clientes:', error));
}

function obtenerClientePorId(id) {
    fetch(`/api/Cliente/${id}`)
        .then(response => response.json())
        .then(cliente => {
            console.log('Cliente encontrado:', cliente);
        })
        .catch(error => console.error('Error al obtener el cliente:', error));
}

function agregarCliente(cliente) {
    fetch("/api/Cliente", {
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

function actualizarCliente(id, cliente) {
    fetch(`/api/Cliente/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cliente)
    })
        .then(() => {
            console.log('Cliente actualizado');
            obtenerClientes(); // Volver a cargar la lista de clientes después de actualizar uno
        })
        .catch(error => console.error('Error al actualizar el cliente:', error));
}

function eliminarCliente(id) {
    fetch(`/api/Cliente/${id}`, {
        method: 'DELETE'
    })
        .then(() => {
            console.log('Cliente eliminado');
            obtenerClientes(); // Volver a cargar la lista de clientes después de eliminar uno
        })
        .catch(error => console.error('Error al eliminar el cliente:', error));
}
