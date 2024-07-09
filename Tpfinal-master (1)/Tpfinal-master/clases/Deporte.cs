using System;
using System.Collections;
public class Deporte
{
	private string nombreDeporte;
	private int categoria;
	private Entrenador entrenador;
	private int cupo;
	private int cantidadInscriptos;
	private double costo;
	private string horario;
	private int descuento;
	private int id;


	public Deporte(string nombreDeporte, int categoria, Entrenador entrenador, int cupo, int cantidadInscriptos, double costo, string horario, int descuento, int id)
	{
		this.descuento = descuento;
		this.nombreDeporte = nombreDeporte;
		this.categoria = categoria;
		this.entrenador = entrenador;
		this.cupo = cupo;
		this.cantidadInscriptos = cantidadInscriptos;
		this.costo = costo;
		this.horario = horario;
		this.id = id;
	}

	public void AgregarEntrenador(Entrenador entrenador)
	{
		this.entrenador = entrenador;
	}


	public int Id
	{
		get { return id; }
		set { id = value; }

	}
	public int Descuento
	{
		get { return descuento; }
		set { descuento = value; }
	}

	public string NombreDeporte
	{
		get { return nombreDeporte; }
		set { nombreDeporte = value; }
	}
	public int Categoria
	{
		get { return categoria; }
		set { categoria = value; }

	}
	public Entrenador Entrenador
	{
		get { return entrenador; }
		set { entrenador = value; }
	}
	public int Cupo
	{
		get { return cupo; }
		set { cupo = value; }
	}
	public int CantidadInscriptos
	{
		get { return cantidadInscriptos; }
		set { cantidadInscriptos = value; }
	}
	public string Horario
	{
		get { return horario; }
		set { horario = value; }
	}

	public double Costo
	{
		get { return costo; }
		set { costo = value; }
	}
}