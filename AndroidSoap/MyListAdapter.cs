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
	public class MyListAdapter: BaseAdapter<Worker>
	{

		private Activity context;
		//private ViewElement viewelement;
		private List<Worker> lWorkerResult;

		public MyListAdapter (Activity context, List<Worker> lWorkerResult) :
		base ()
		{
			this.context = context;
			this.lWorkerResult = lWorkerResult;
		}


		public override View GetView (int position, View convertView, ViewGroup parent)
		{ 
			Worker worker = lWorkerResult[position];

			ViewLinearLayout viewLinearLayout = new ViewLinearLayout (context);

			viewLinearLayout.tvNumber.Text = Convert.ToString(position);
			viewLinearLayout.tvDescription.Text = worker.Name +" "+ worker.LastName +" "+ worker.Dni;
			viewLinearLayout.tvContact.Text = worker.Address +" "+ worker.Email +" "+ worker.Phone;


			return viewLinearLayout;
		}
		public override Java.Lang.Object GetItem (int position)
		{
			return base.GetItem (position);
		}

		public override Worker this[int position] {
			get {
	
				return lWorkerResult[position];
			}
		}
		public override int Count {
			get {
				return lWorkerResult.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}
	}
}

