using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace AndroidSoap
{
	[Activity (Label = "AndroidSoap", MainLauncher = true)]
	public class MainActivity : Activity
	{
		//int count = 1;
		
	
		private Context context;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			context = this;

			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button bSearch = FindViewById<Button> (Resource.Id.bSearch);
			EditText edTypeService = FindViewById<EditText> (Resource.Id.etTypeWord);	

			Intent i = new Intent (this, typeof(ResultSearchActivity));
		
			bSearch.Click  += delegate {

				string sTypeService = edTypeService.Text;
				//sTypeService = "Ninhera";
				i.PutExtra("TypeService", sTypeService);
				StartActivity(i);

			};		
					
		}
	}
}


