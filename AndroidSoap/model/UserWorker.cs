using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidSoap
{
	public class Worker
	{
		
		public Worker(int dni, string name, string lastName, string email, string phone, string address){
			Dni = dni;
			Name = name;
			LastName = lastName;
			Email = email;
			Phone = phone;
			Address = address;
		}

		public Worker(){
		}
		public int Dni  { get ; set ; }
		public String Name  { get ; set ; }
		public String LastName  { get ; set ;}
		public String Email  { get ; set ;}
		public String Phone  { get ; set ;}
		public String Address  { get ; set ;}
		
	}
}

