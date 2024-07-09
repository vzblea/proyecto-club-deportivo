using System;
using System.Collections.Generic;

public class Persona
{
	protected int edad;
	protected string nombre;
	protected int dni;

	public Persona(int edad, string nombre, int dni)
	{
		this.edad = edad;
		this.nombre = nombre;
		this.dni = dni;
	}

	public int Dni
	{
		get { return dni; }
		set { dni = value; }
	}

	public string Nombre
	{
		get { return nombre; }
		set { nombre = value; }
	}
	public int Edad
	{
		get { return edad; }
		set { edad = value; }
	}


}