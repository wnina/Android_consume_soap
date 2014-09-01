using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AndroidSoap
{
	public class ViewLinearLayout : LinearLayout
	{

		public LinearLayout llRow;

		public LinearLayout llNumber;
		public LinearLayout llDescription;
		public LinearLayout llContact;

		public TextView tvNumber;
		public TextView tvDescription;
		public TextView tvContact;
		public Context context;
		
		public ViewLinearLayout (Context context) :
			base (context)
		{
			Initialize ();
			this.context = context;
		
			this.LayoutParameters = new AbsListView.LayoutParams (AbsListView.LayoutParams.FillParent , AbsListView.LayoutParams.FillParent);
			this.Orientation =  Orientation.Horizontal;
			tvNumber = new TextView (context);
			tvDescription = new TextView (context);
			tvContact = new TextView (context);

			llRow = new LinearLayout (context);
			llRow.LayoutParameters = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.FillParent , LinearLayout.LayoutParams.FillParent);
			//llRow.WeightSum = 1.0f;
			llRow.Orientation = Orientation.Horizontal;
		
			llNumber = new LinearLayout (context);
			llDescription = new LinearLayout (context);
			llContact = new LinearLayout (context);

			createItem (llNumber, tvNumber, 0.2f);
			createItem (llDescription, tvDescription, 0.5f);
			createItem (llContact, tvContact, 0.3f);

			this.AddView (llRow);

		}

		public ViewLinearLayout (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public ViewLinearLayout (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		public void createItem(LinearLayout linearlayout, TextView textview, float weight)
		{
	
			//textview.LayoutParameters = new ViewGroup.LayoutParams 
			//                           (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);


			textview.LayoutParameters = new LinearLayout.LayoutParams (LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent, 1.0f);

			//linearlayout.LayoutParameters = new LinearLayout.LayoutParams (0 , LayoutParams.MatchParent, weight);
		
			//linearlayout.AddView (textview);
			llRow.AddView (textview);
		}
	}
}