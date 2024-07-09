using System;
using System.Collections;

public class Socio : Persona
{
	private ArrayList referenciasDeportes;
	private ArrayList nombresDeDeportesAnotado;
	private int categoria;
	private int mesPago;

	public Socio(int edad, string nombre, int dni, ArrayList referenciasDeportes, int categoria, int mesPago, ArrayList nombresDeDeportesAnotado) : base(edad, nombre, dni)
	{
		this.nombresDeDeportesAnotado = nombresDeDeportesAnotado != null ? nombresDeDeportesAnotado : new ArrayList();
		this.referenciasDeportes = referenciasDeportes != null ? referenciasDeportes : new ArrayList();
		this.categoria = categoria;
		this.mesPago = mesPago;
	}

	public ArrayList ReferenciasDeportes
	{
		get { return referenciasDeportes; }
	}

	public ArrayList NombresDeDeportesAnotado
	{
		get { return nombresDeDeportesAnotado; }
	}

	public int Categoria
	{
		get { return categoria; }
		set { categoria = value; }
	}
	public int MesPago
	{
		get { return mesPago; }
		set { mesPago = value; }

	}
	
	public void eliminarNombreDeporteIndex(int i){
		nombresDeDeportesAnotado.RemoveAt(i);
	}
	
	public void elimiarReferenciaDeporte(int i){
		referenciasDeportes.RemoveAt(i);
	}
	
	public int obtenerReferenciaDeporte(int i ){
		return (int)referenciasDeportes[i];
	}
	
	public string obtenerNombreDeporte(int i){
		return (string)nombresDeDeportesAnotado[i];
	}
	
	public bool esVacioReferenciaDeporte (){
		return referenciasDeportes.Count == 0;
	}
	
	public bool esVacioNombreDeportes(){
		return nombresDeDeportesAnotado.Count == 0;
	}
	
	public int totalReferenciaDeporte(){
		return referenciasDeportes.Count;
	}
	public int totalNombreDeporte(){
		return nombresDeDeportesAnotado.Count;
	}
	public ArrayList verReferenciaDeportes(){
		return referenciasDeportes;
	}
	
	public ArrayList verNombreDeporte(){
		return nombresDeDeportesAnotado;
	}

	
}