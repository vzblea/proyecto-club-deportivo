using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace clases
{
	class Program
	{
		static void Main(string[] args)
		{
			// (string nombreDeporte, DateTime categoria, Entrenador entrenador,
			// int cupo, int cantidadInscriptos, double costo, string horario)

			ClubDeportivo club = datosCargados();

			while (true)
			{
				Console.Clear();
				string opcion = menuInfo();
				if (opcion == "x")
				{
					break;
				}
				Menu(club, opcion);
				Console.ReadKey();
			}


		}

		static public ClubDeportivo datosCargados() {

			ArrayList listDeportes = new ArrayList();
			ArrayList listSocio = new ArrayList();

			// (int edad, string nombre, int dni)
			Entrenador entrador1 = new Entrenador(20, "Eliana", 12345678);
			Entrenador entrador2 = new Entrenador(20, "Juan", 2345678);
			Entrenador entrador3 = new Entrenador(20, "Pedro", 345678);

			// (string nombreDeporte, int categoria, Entrenador entrenador, int cupo, int cantidadInscriptos, double costo, string horario, int descuento, int id)
			Deporte deporte1 = new Deporte("futbol", 2001, entrador1, 2, 0, 8000, "jueves de 18 a 20hs", 15, 3333);
			Deporte deporte2 = new Deporte("futbol", 2006, entrador2, 2, 0, 8000, "jueves de 18 a 20hs", 15, 3334);
			Deporte deporte3 = new Deporte("futbol", 2007, entrador3, 2, 0, 8000, "jueves de 18 a 20hs", 25, 3335);
			Deporte deporte4 = new Deporte("voley", 2005, entrador3, 2, 0, 8000, "jueves de 18 a 20hs", 15, 3335);

			listDeportes.Add(deporte1);
			listDeportes.Add(deporte2);
			listDeportes.Add(deporte3);
			listDeportes.Add(deporte4);


			//(int edad, string nombre, int dni, ArrayList referenciasDeportes, int categoria, int mesPago, ArrayList nombresDeDeportesAnotado)
			ArrayList referenciasDeportes = new ArrayList();
			ArrayList nombresDeDeportesAnotado = new ArrayList();
			Socio socio = new Socio(22, "Eliana", 1, referenciasDeportes, 2001, 6, nombresDeDeportesAnotado);
			socio.NombresDeDeportesAnotado.Add(deporte1.NombreDeporte);
			socio.ReferenciasDeportes.Add(deporte1.Id);
			listSocio.Add(socio);
			deporte1.CantidadInscriptos++;


			ClubDeportivo club = new ClubDeportivo(listSocio, listDeportes);
			return club;
		}




		static public string menuInfo()
		{
			Console.WriteLine("Menú:");
			Console.WriteLine("a- Agregar a un entrenador");
			Console.WriteLine("b- Dar de baja a un entrenador");
			Console.WriteLine("c- Agregar a un niño/socio en un deporte");
			Console.WriteLine("d- Dar de baja a un niño/socio en un deporte");
			Console.WriteLine("e- Simular el pago de una cuota");
			Console.WriteLine("f- Submenú de inscripción:");
			Console.WriteLine("g- Listado de deudores");
			Console.WriteLine("h- Agregar un deporte");
			Console.WriteLine("i- Eliminar un deporte");
			Console.WriteLine("j- Listado de deportes");
			Console.WriteLine("x- Salir");

			Console.Write("Seleccione una opción: ");
			string opcion = Console.ReadLine();
			return opcion;
		}

		static public void Menu(ClubDeportivo club, string opcion)
		{
			try
			{
				switch (opcion)
				{
					case "a":
						añadirEntrenador(club);

						break;
					case "b":
						eliminarEntrenador(club);

						break;
					case "c":
						añadirSocio(club);
						break;
					case "d":
						eliminarSocio(club);
						break;
					case "e":
						PagarCuota(club);
						break;
					case "f":
						Console.WriteLine("Ingrese una opcion");
						Console.WriteLine("1 - Por deporte");
						Console.WriteLine("2 - Por deporte y categoría");
						Console.WriteLine("3 - Total");
						int opcion2 = int.Parse(Console.ReadLine());
						switch (opcion2)
						{
							case 1:
								ListarInscriptosPorDeporte(club);
								break;
							case 2:
								ListarInscriptosPorDeporteYCategoría(club);
								break;
							case 3:
								imprimirTotalIncriptos(club);
								break;

						}
						break;
					case "g":
						if (club.ListSocio == null || club.ListSocio.Count == 0)
						{
							Console.WriteLine("La lista esta vacia");
						}
						else
						{
							imprimirDeudores(club);
						}
						break;
					case "h":
						agregarDeporte(club);
						break;
					case "i":
						eliminarDeporte(club);
						break;
					case "j":
						listadoDeportes(club);
						break;
				}
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}

		}


		static public void listadoDeportes(ClubDeportivo club)
		{
			foreach (Deporte d23 in club.ListDeportes)
			{
				Console.WriteLine("-----------------------");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Deporte: " + d23.NombreDeporte);
				Console.ResetColor();
				Console.WriteLine("Horario: " + d23.Horario);
				Console.WriteLine("Categoria: " + d23.Categoria);
				Console.WriteLine("Cantidad de cupos disponibles: " + d23.Cupo);
				Console.WriteLine("Cantidad de personas inscriptas: " + d23.CantidadInscriptos);
				Console.WriteLine("Entrenador: " + d23.Entrenador.Nombre);
				Console.WriteLine("Costo: " + d23.Costo);


			}

		}

		static public void añadirEntrenador(ClubDeportivo club)
		{
			Console.WriteLine("Ingrese el nombre del entrador");
			string nombreEntrenador = Console.ReadLine();
			Console.WriteLine("Ingrese la edad del entrador");
			int edad = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el Dni del entrenador");
			int dni = int.Parse(Console.ReadLine());
			Entrenador entrador = new Entrenador(edad, nombreEntrenador, dni);

			Console.WriteLine("Ingrese el nombre del deporte para agregar entrenador");
			string nombreDeporte = Console.ReadLine();

			Deporte deporteEncontrado = null;

			foreach (Deporte d22 in club.ListDeportes)
			{
				if (d22.Entrenador != null && d22.Entrenador.Dni == dni)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("El entrenador ya esta anotado en un deporte");
					Console.ResetColor();
					deporteEncontrado = null;
					return;
				}
				if (d22.Entrenador == null && d22.NombreDeporte == nombreDeporte)
				{
					deporteEncontrado = d22;
				}

			}

			if (deporteEncontrado != null)
			{
				deporteEncontrado.AgregarEntrenador(entrador);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("El entrenador se agregró correctamente");
				Console.ResetColor();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("No se encontro el deporte especificado o ya tiene entrenador.");
				Console.ResetColor();
			}








		}

		static public void añadirSocio(ClubDeportivo club)
		{
			Socio socio = pedirDatosSocio(club);

			Console.WriteLine("Ingrese el nombre del deporte para anotarse");
			string nombreDeporte = Console.ReadLine();

			var socioEncontrado = club.buscarSocio(socio.Dni);
			var entrenadorEncontrado = club.buscarEntrenador(socio.Dni);

			if (socioEncontrado == null && entrenadorEncontrado == null)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("El Dni ingresado ya existe en la base de datos");
				Console.ResetColor();
				return;
			}

			try
			{
				foreach (Deporte d18 in club.ListDeportes)
				{
					if (d18.NombreDeporte == nombreDeporte && socio.Categoria == d18.Categoria)
					{
						if (d18.Cupo - 1 < 0)
						{
							throw new ExceptionCupoSocio("No hay cupos");
						}
						else
						{
							club.agregarSocio(socio);
							socio.ReferenciasDeportes.Add(d18.Id);
							socio.NombresDeDeportesAnotado.Add(d18.NombreDeporte);
							d18.Cupo--;
							d18.CantidadInscriptos++;
							Console.WriteLine("Se agrego correctamente.");
							Console.WriteLine("Horario: " + d18.Horario);
							return;
						}

					}
				}
				Console.WriteLine("No se encontró el deporte");
				return;
			}
			catch (ExceptionCupoSocio ex3)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex3.Message);
				Console.ResetColor();
			}



		}


		static public void eliminarSocio(ClubDeportivo club)
		{
			Console.WriteLine("Ingrese el Dni del socio a eliminar");
			int dni = int.Parse(Console.ReadLine());
			foreach (Socio s17 in club.ListSocio)
			{
				if (s17.Dni == dni)
				{
					DateTime fechaActual = DateTime.Now;
					if (s17.MesPago < fechaActual.Month)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("No se puede dar de baja, el socio tiene deuda de " + (fechaActual.Month - s17.MesPago + " Mes"));
						Console.ResetColor();
						return;
					}
					foreach (int referencias4 in s17.ReferenciasDeportes)
					{
						foreach (Deporte d25 in club.ListDeportes)
						{
							if (d25.Id == referencias4)
							{
								d25.Cupo++;
								d25.CantidadInscriptos--;
							}
						}
					}
					club.ListSocio.Remove(s17);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Se elimino correctamente");
					Console.ResetColor();
					return;
				}

			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("No se encontro el socio especificado.");
			Console.ResetColor();

		}

		static public void PagarCuota(ClubDeportivo club)
		{
			Console.WriteLine("Ingrese su Dni");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el nombre del deporte");
			string nombreDeporte = Console.ReadLine();
			DateTime fechaActual = DateTime.Now;
			foreach (Socio s15 in club.ListSocio)
			{
				if (s15.Dni == dni)
				{
					foreach (Deporte d16 in club.ListDeportes)
					{
						if (d16.NombreDeporte == nombreDeporte)
						{
							foreach (int referencia in s15.ReferenciasDeportes)
							{
								if (referencia == d16.Id)
								{
									try
									{
										double costo = d16.Costo;
										double cuentaAux = ((costo / 100) * d16.Descuento);
										double precioFinal = costo - cuentaAux;
										Console.WriteLine("Costo original: " + costo);
										Console.WriteLine("Se aplico un: " + d16.Descuento + "% de descuento.");
										Console.WriteLine("Precio a pagar por ser Socio: " + precioFinal);
										Console.WriteLine("---------------------------------");
										Console.WriteLine("Ingrese el monto para pagar");
										double monto = double.Parse(Console.ReadLine());
										if (precioFinal - monto <= 0)
										{
											if (s15.MesPago + 1 > fechaActual.Year)
											{
												Console.WriteLine("La cuota del mes ya esta pagada espere hasta el mes siguiente");
												return;
											}
											if (s15.MesPago + 1 == 13)
											{
												s15.MesPago = 0;
											}
											s15.MesPago++;
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine("Se pago correctamente la cuota, su vuelto es: " + (monto - precioFinal));
											Console.ResetColor();
											return;

										}
										else
										{
											throw new ExceptionMontoInsuficiente("El monto ingresado no es suficiente para cubrir la cuota");
										}
									}
									catch (Exception ex)
									{
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine(ex.Message);
										Console.ResetColor();
										return;
									}

								}

							}


						}



					}
					Console.WriteLine("No se encontro el deporte especificado");
					return;
				}
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("No se encontró el Socio especificado.");
			Console.ResetColor();
			return;



		}

		static void eliminarEntrenador(ClubDeportivo club)
		{
			bool entradorEncontrado = false;
			Console.WriteLine("Ingrese el Dni del entrenador a eliminar");
			int dni = int.Parse(Console.ReadLine());
			foreach (Deporte d20 in club.ListDeportes)
			{
				if (d20.Entrenador != null && d20.Entrenador.Dni == dni)
				{
					entradorEncontrado = true;
					if (d20.CantidadInscriptos <= 0)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Se elimino correctamente el entrador");
						Console.ResetColor();
						Console.WriteLine("Dni: " + d20.Entrenador.Dni + " Nombre: " + d20.Entrenador.Nombre + " Edad: " + d20.Entrenador.Edad);
						d20.Entrenador = null;
						return;
					}
				}

			}
			if (!entradorEncontrado) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("El entrenador no se encontró en la base de datos.");
				Console.ResetColor();
			}

		}


		static public void eliminarDeporte(ClubDeportivo club)
		{
			Console.WriteLine("Ingrese nombre del deporte");
			string nombreDeporte = Console.ReadLine();
			Console.WriteLine("Ingrese categoria del deporte a eliminar");
			int categoria = int.Parse(Console.ReadLine());
			foreach (Deporte d15 in club.ListDeportes)
			{
				if (d15.NombreDeporte == nombreDeporte && d15.Categoria == categoria)
				{
					if (d15.CantidadInscriptos > 0)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Hay inscriptos en este deporte no se puede eliminar");
						Console.ResetColor();
						return;
					}
					club.ListDeportes.Remove(d15);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Se elimino correctamente");
					Console.ResetColor();
					return;
				}
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("No se encontró el deporte especificado");
			Console.ResetColor();
		}

		public static void ListarInscriptosPorDeporte(ClubDeportivo club)
		{
			var deportesImprimidos = new HashSet<string>();

			foreach (Deporte deporte in club.ListDeportes)
			{
				if (deportesImprimidos.Contains(deporte.NombreDeporte))
					continue;

				deportesImprimidos.Add(deporte.NombreDeporte);
				Console.WriteLine("-----------------------");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Deporte: " + deporte.NombreDeporte);
				Console.ResetColor();

				bool sociosEncontrados = false;

				foreach (Socio socio in club.ListSocio)
				{
					if (socio.NombresDeDeportesAnotado.Contains(deporte.NombreDeporte))
					{
						Console.WriteLine("Nombre: " + socio.Nombre + " Edad: " + socio.Edad);
						sociosEncontrados = true;
					}
				}

				if (!sociosEncontrados)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("No hay socios en este deporte.");
					Console.ResetColor();
				}
			}
		}

		static public void ListarInscriptosPorDeporteYCategoría(ClubDeportivo club)
		{
			bool sociosEncontrados = false;
			foreach (Deporte d19 in club.ListDeportes)
			{
				Console.WriteLine("-----------------------");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Deporte: " + d19.NombreDeporte + " Categoría: " + d19.Categoria);
				Console.ResetColor();

				foreach (Socio s19 in club.ListSocio)
				{
					foreach (int referencia2 in s19.ReferenciasDeportes)
					{
						if (d19.Id == referencia2)
						{
							Console.WriteLine("Nombre: " + s19.Nombre + " Edad: " + s19.Edad);
							sociosEncontrados = true;
						}

					}
				}
				if (sociosEncontrados == false) {
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("No hay socios en este deporte.");
					Console.ResetColor();
				}


				sociosEncontrados = false;

			}




		}
		// int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago
		static public Socio pedirDatosSocio(ClubDeportivo club)
		{
			
			Console.WriteLine("ingrese su edad");
			int edad2 = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su nombre");
			string nombre2 = Console.ReadLine();
			Console.WriteLine("Ingrese su Dni");
			int dni2 = int.Parse(Console.ReadLine());
			ArrayList listaDeportes = new ArrayList();
			DateTime fechaActual = DateTime.Now;
			int categoria = fechaActual.Year - edad2;
			ArrayList nombresDeportes = new ArrayList();
			//(int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago, ArrayList nombresDeDeportesAnotado)
			Socio socio = new Socio(edad2, nombre2, dni2, listaDeportes, categoria, fechaActual.Month, nombresDeportes);
			return socio;
		}


		static public void imprimirTotalIncriptos(ClubDeportivo club)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("--------Total--------");
			Console.ResetColor();
			foreach (Socio s3 in club.ListSocio)
			{
				Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}", s3.Nombre, s3.Dni, s3.Edad);
			}
		}


		static public void imprimirDeudores(ClubDeportivo club)
		{
			DateTime fechaActual = DateTime.Now;
			foreach (Socio s4 in club.ListSocio)
			{
				if (fechaActual.Month > s4.MesPago)
				{
					Console.WriteLine("Deudores: ");
					Console.WriteLine("Nombre: {0}, Dni: {1}, Edad: {2}", s4.Nombre, s4.Dni, s4.Edad);
				}
			}
		}

		// string nombreDeporte, DateTime categoria, Entrenador entrenador, int cupo,
		// int cantidadInscriptos, double costo, string horario
		static public void agregarDeporte(ClubDeportivo club)
		{
			Console.WriteLine("ingrese el nombre del deporte");
			string nombreDeporte = Console.ReadLine();
			try
			{
				Console.WriteLine("Ingrese la categoria aaaa (año)");
				int categoria = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese los datos del entreador para el deporte");
				Entrenador entrenador = pedirDatos();
				Console.WriteLine("Ingrese la cantidad de cupos del deporte");
				int cupo = int.Parse(Console.ReadLine());
				int cantidadIncriptos = 0;
				Console.WriteLine("Ingrese el costo del deporte");
				double costo = double.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el horario del deporte");
				string horario = Console.ReadLine();
				Console.WriteLine("Ingrese el descueto para socios");
				int descuento = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el Id del deporte");
				int id = int.Parse(Console.ReadLine());

				Deporte deporte = new Deporte(nombreDeporte, categoria, entrenador, cupo, cantidadIncriptos, costo, horario, descuento, id);
				club.agregarDeporte(deporte);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("El deporte se agrego correctamente");
				Console.ResetColor();
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}

		}

		static public Entrenador pedirDatos()
		{
			int edad2, dni2;
			Console.WriteLine("Ingrese su nombre");
			string nombre = Console.ReadLine();
			try
			{
				Console.WriteLine("ingrese su edad");
				string edadTexto = Console.ReadLine();
				bool valor = int.TryParse(edadTexto, out edad2);
				if (valor)
				{
					Console.WriteLine("ingrese su dni");
					string dniTexto = Console.ReadLine();
					bool valor2 = int.TryParse(dniTexto, out dni2);
					if (valor2)
					{
						Entrenador entrenador = new Entrenador(dni2, nombre, edad2);
						return entrenador;
					}
					else
					{
						throw new ExceptionDniInvalido("El dni ingresado en invalido");
					}
				}
				else
				{
					throw new ExceptionEdadInvalida("La edad ingresada es invalida");
				}

			}

			catch (ExceptionEdadInvalida ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ExceptionDniInvalido ex2)
			{
				Console.WriteLine(ex2.Message);
			}
			return null;
		}


	}
	
}

