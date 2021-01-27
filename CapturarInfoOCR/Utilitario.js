var DotnetHelper;

export function Obtener(dotnetHelper) {
	document.onkeypress = mostrarInformacionTecla;
	DotnetHelper = dotnetHelper;
}	 

function mostrarInformacionTecla(eventoObj) {
	var caracter = String.fromCharCode(eventoObj.which);
	DotnetHelper.invokeMethodAsync("MostrarInfo", caracter);
}


export function Liberar() {
	document.onkeypress = null;
}
