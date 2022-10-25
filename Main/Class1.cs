/*
 * Created by SharpDevelop.
 * User: alanv
 * Date: 09/10/2022
 * Time: 08:14 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Main
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Medico
	{
		private string nombre,especialidad;
		private int dni;
		private ArrayList horario = new ArrayList () {"8:00","8:30","09:00","09:30","10:00","10:30","11:00","11:30","12:00"};
		private ArrayList listapacientes;
		private ArrayList listaturnos;
		
		public string NOMBRE
		{
			set{nombre=value;}
			get{return nombre;}
		}
		
		public string ESPECIALIDAD
		{
			set{especialidad=value;}
			get{return especialidad;}
		}
		
		public int DNI
		{
			set{dni=value;}
			get{return dni;}
		}
		
		public ArrayList LISTATURNOS
		{
			set{listaturnos = value;}
			get{return listaturnos;}
		}
		public ArrayList LISTAPACIENTES
		{
			set{listapacientes = value;}
			get{return listapacientes;}
		}
		
		public ArrayList HORARIO
		{
			set{horario = value;}
			get{return horario;}
		}
		
		public Medico(string nombre, string especialidad, int dni, ArrayList listapacientes, ArrayList listaturnos)
		{
			this.nombre = nombre;
			this.especialidad = especialidad;
			this.dni = dni;
			this.listapacientes = listapacientes;
			this.listaturnos = listaturnos;
		}
		
// Intenta agregar el turno, en caso de que no haya horario disponible aparece una excepcion

		public void AgregarTurno(ArrayList listaturnos, ArrayList listapacientes, ArrayList horarios, string nombrep, string hora, int dni)
		{
			
			try{
				if (!horarios.Contains(hora))
				{
					throw new FueraDeHorario();
				}
				foreach(Turno elem in listaturnos)
				{
					if(elem.HORA == hora)
					{
						throw new SinHorarios();
					}
				}
				Turno nueTurno = new Turno(nombrep, hora);
				listaturnos.Add(nueTurno);
				foreach(Paciente elem in listapacientes)
				{
					if(elem.DNI == dni)
					{
						elem.agregarTurno(nueTurno);
					}
				}
				Console.WriteLine("Se ha agregado el turno");
				Console.WriteLine("---------------");
			}
			catch(SinHorarios)
			{
				Console.WriteLine("Horario no disponible, llame el proximo dia de atencion");
			}
			catch(FueraDeHorario)
			{
				Console.WriteLine("Fuera de horario de atencion.");
			}
							
		}
		
// Actualiza el diagnostico de un paciente a traves de su dni	

		public void ActualizarDiag(ArrayList listapacientes)
		{
			Console.WriteLine("Ingrese el dni del paciente");
			int dni = int.Parse(Console.ReadLine());
			foreach (Paciente elem in listapacientes)
			{
				if (elem.DNI == dni)
				{
					Console.WriteLine("Ingrese el nuevo diagnostico del paciente");
					elem.DIAG = Console.ReadLine();
				}
			}
			Console.WriteLine("Se ha actualizado el diagnostico");
			Console.WriteLine("---------------");			
		}
		
// Cancela un turno a traves del horario del turno

		public void CancTurno(ArrayList listaturnos)
		{
			int contador = 0;
			Console.WriteLine("Ingrese el horario del turno a cancelar");
			string horario = Console.ReadLine();
			foreach (Turno elem in listaturnos)
			{
				if (horario == elem.HORA)
				{
					break;
				}
				contador = contador+1;
			}
			listaturnos.RemoveAt(contador);
			Console.WriteLine("Se ha eliminado el turno");
			Console.WriteLine("---------------");			
		}
		
// Agrega un paciente a la lista de pacientes
		
		public void AgregarPaciente(ArrayList listapacientes)
		{
			Console.WriteLine("Ingrese el nombre del paciente");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese la obra social del paciente, en caso de no tener obra ingrese 'particular'");
			string obra = Console.ReadLine();
			Console.WriteLine("Ingrese el diagnostico del paciente");
			string diag = Console.ReadLine();
			Console.WriteLine("Ingrese el dni del paciente");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el numero de afiliado, en caso de no tener ingrese '0'");
			int numob = int.Parse(Console.ReadLine());
			Paciente paciente = new Paciente(nombre, obra, diag, dni, numob);
			listapacientes.Add(paciente);
			Console.WriteLine("Se agrego al paciente: " + nombre);
			Console.WriteLine("---------------");			
		}
		
// Elimina un paciente a traves de su dni		
		
		public void EliminarPaciente(ArrayList listaturnos, ArrayList listapacientes)
		{
			int contador = 0;
			Console.WriteLine("Ingrese el dni del paciente a eliminar");
			int dni = int.Parse(Console.ReadLine());
			foreach(Paciente elem in listapacientes)
			{
				if (dni == elem.DNI)
				{
					foreach(Turno el in listaturnos)
					{
						if (elem.TURNO == el)
						{
							listaturnos.Remove(el);
							break;
						}
					}
					break;
				}
				contador = contador + 1;
			}
			listapacientes.RemoveAt(contador);
			Console.WriteLine("Se ha eliminado al paciente");
			Console.WriteLine("---------------");			
		}
		
	}
	public class Paciente
	{
		private string nombre,obra,diag;
		private int dni,numob;
		private Turno turno;
		
		public Paciente(string nombre, string obra, string diag, int dni, int numob)
		{
			this.nombre = nombre;
			this.obra = obra;
			this.diag = diag;
			this.dni = dni;
			this.numob = numob;
			
		}
		public string NOMBRE
		{
			set {nombre=value;}
			get {return nombre;}
		}
		public string OBRA
		{
			set{obra=value;}
			get{return obra;}
		}
		public string DIAG
		{
			set{diag=value;}
			get{return diag;}
		}
		public int DNI
		{
			set{dni=value;}
			get{return dni;}
		}
		public int NUMOB
		{
			set{numob=value;}
			get{return numob;}
		}
		public void agregarTurno(Turno turno){
			this.turno = turno;
		}
		
		public Turno TURNO
		{
			set{turno = value;}
			get{return turno;}
		}
	}
	
	public class Turno
	{
		private string nombre,hora;
		
		public Turno(string nombre, string hora)
		{
			this.nombre = nombre;
			this.hora = hora;
		}
		public string NOMBRE
		{
			set{nombre=value;}
			get{return nombre;}
		}
		public string HORA
		{
			set{hora=value;}
			get{return hora;}
		}
	}
	public class SinHorarios: Exception
	{	
	}
	public class FueraDeHorario : Exception
	{		
	}
}
