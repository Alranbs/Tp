/*
 * Created by SharpDevelop.
 * User: alanv
 * Date: 09/10/2022
 * Time: 08:12 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Main
{
	class Program
	{
		public static void Main(string[] args)
		{
			Paciente paciente1 = new Paciente("Jose", "Particular", "Dolor de cuello", 44709023, 0);
			Paciente paciente2 = new Paciente("Manuel", "Particular", "Dolor de brazo", 22004433, 0);
			Turno turno1 = new Turno("Jose", "08:30");
			Turno turno2 = new Turno("Manuel", "09:00");
			ArrayList listaturnos = new ArrayList();
			ArrayList listapacientes = new ArrayList();
			//listaturn.Add(turno1);
			//listaturn.Add(turno2);
			//listapac.Add(paciente1);
			//listapac.Add(paciente2);
			//paciente1.agregarTurno(turno1);
			//paciente2.agregarTurno(turno2);	
			Medico Jose = new Medico("Jose", "Traumatologia", 35523938, listapacientes, listaturnos);
			bool t = true;
			
			do{
				Console.WriteLine("Bienvenido al menu");
				Console.WriteLine("---------------");
				Console.WriteLine("Ingrese el numero correspondiente a la funcion que desea realizar");
				Console.WriteLine("1) Dar un turno");
				Console.WriteLine("2) Actualizar el diagnostico de un paciente");
				Console.WriteLine("3) Cancelar un turno");
				Console.WriteLine("4) Listado de los turnos");
				Console.WriteLine("5) Lista de las obras sociales de los pacientes");
				Console.WriteLine("6) Agregar paciente");
				Console.WriteLine("7) Eliminar paciente");
				Console.WriteLine("8) Lista de los pacientes");
				Console.WriteLine("9) Salir del programa");
				Console.WriteLine("---------------");
				int eleccion = int.Parse(Console.ReadLine());
			
				switch(eleccion)
				{
					case 1:
						DarTurno(Jose);
						break;
					case 2:
						Jose.ActualizarDiag(Jose.LISTAPACIENTES);
						break;
					case 3:
						Jose.CancTurno(Jose.LISTATURNOS);
						break;
					case 4:
						ListaTurnos(Jose.LISTATURNOS);
						break;
					case 5:
						ListaObras(Jose.LISTAPACIENTES);
						break;
					case 6:
						Jose.AgregarPaciente(Jose.LISTAPACIENTES);
						break;
					case 7:
						Jose.EliminarPaciente(Jose.LISTATURNOS, Jose.LISTAPACIENTES);
						break;
					case 8:
						ListaPacientes(Jose.LISTAPACIENTES);
						break;
					case 9:
						t = false;
						break;
					default :
						Console.WriteLine("No existe esa opcion");
						break;
						
				}
			}
			while (t);
		}
		
// Se pasan los datos necesarios para dar el turno y se llama a la funcion AgregarTurno de la clase medico
		
		static public void DarTurno(Medico medico)
		{
			Console.WriteLine("---------------");
			Console.WriteLine("Ingrese el nombre del paciente");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese el dni del paciente");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el horario en el siguiente formato: hh:mm");
			string hora = Console.ReadLine();			
			medico.AgregarTurno(medico.LISTATURNOS, medico.LISTAPACIENTES,medico.HORARIO, nombre, hora, dni);
			
		}
		
// Recorre la lista de turnos imprimiendo nombre y hora		

		static public void ListaTurnos(ArrayList listaturnos)
		{
			Console.WriteLine("---------------");
			foreach(Turno elem in listaturnos)
			{
				Console.WriteLine("Nombre:" + elem.NOMBRE);
				Console.WriteLine("Horario:" + elem.HORA);	
			}
			Console.WriteLine("---------------");
		}
		
// Crea una lista y luego agrega las obras sociales de la lista obras sociales sin repetirlas para luego imprimirlas		
		
		static public void ListaObras(ArrayList listapacientes)
		{
			ArrayList lista = new ArrayList();
			foreach(Paciente elem in listapacientes)
			{
				if (!lista.Contains(elem.OBRA)){
					lista.Add(elem.OBRA);
				}
			}
			Console.WriteLine("Las obras sociales de los pacientes son las siguientes:");
			Console.WriteLine("---------------");
			foreach(string elem in lista)
			{
				Console.WriteLine(elem);
			}
			Console.WriteLine("---------------");
		}

// Recorre la lista de pacientes e imprime los datos de los mismos
		
		static public void ListaPacientes(ArrayList listapacientes)
		{
			foreach (Paciente elem in listapacientes)
			{
				Console.WriteLine("---------------");
				Console.WriteLine("Nombre: " + elem.NOMBRE);
				Console.WriteLine("Obra social: " + elem.OBRA);
				Console.WriteLine("Diagnostico: " + elem.DIAG);
				Console.WriteLine("Dni: " + elem.DNI);
				Console.WriteLine("Numero de afiliado: " + elem.NUMOB);
				Console.WriteLine("---------------");
			}
		}
		
		
	}
}