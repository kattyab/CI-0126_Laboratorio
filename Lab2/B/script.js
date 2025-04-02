function agregar() {
  var lista = document.getElementById("lista");
  var nuevoElemento = document.createElement("li");
  nuevoElemento.innerHTML = "Elemento" + (lista.children.length + 1);
  lista.appendChild(nuevoElemento);
}

function cambiarFondo() {
  var body = document.body;
  if (body.style.backgroundColor) {
    body.style.backgroundColor = "";
  } else {
    body.style.backgroundColor =
      "#" + Math.floor(Math.random() * 16777215).toString(16);
  }
}

function borrar() {
  var lista = document.getElementById("lista");
  var elementos = lista.getElementsByTagName("li");
  if (elementos.length > 0) {
    lista.removeChild(elementos[elementos.length - 1]);
  }
}
