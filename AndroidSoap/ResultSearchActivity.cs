using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


using Org.Ksoap2.Serialization;
using Org.Ksoap2.Transport;
using Org.Ksoap2;
using Java.Net;

namespace AndroidSoap
{

	[Activity (Label = "ResultSearchActivity")]			
	public class ResultSearchActivity : Activity
	{

		private static String NAMESPACE = "http://webservices.kachuelitos";
		private static String MAIN_REQUEST_URL = "http://192.168.115.1:8080/kachuelitos2/services/JobOffersList?wsdl";
		private ListView lsView;
		private List<Worker> lWorker;
		private ProgressDialog progressDialog;


		                                       
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.ListJobs); 
			lsView = FindViewById<ListView> (Resource.Id.lvResult);
			lWorker = new List<Worker>();

			String typeService = Intent.GetStringExtra ("TypeService");

			progressDialog = new ProgressDialog(this) { Indeterminate = true };
			progressDialog.SetTitle("Carga de Datos");
			progressDialog.SetMessage("Esperando");
		
			// Se crea un hilo par hacer el ws al wsdl
			SearchServicesWithThread (typeService);

		}

		public  SoapSerializationEnvelope getSoapSerializationEnvelope (SoapObject request) 
		{
			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.Ver12);

			envelope.DotNet = true;
			envelope.ImplicitTypes = true;
			envelope.AddAdornments = false ;
			envelope.SetOutputSoapObject (request);
			return envelope;
		}

		public  HttpTransportSE getHttpTransportSE() {
			HttpTransportSE ht = new HttpTransportSE(Proxy.NoProxy, MAIN_REQUEST_URL,60000);
			ht.Debug = true;
			ht.SetXmlVersionTag("<!--?xml version=\"1.0\" encoding= \"UTF-8\" ?-->");
			return ht;
		}

		public void loadData(String typeService)
		{
			String methodname = "verifyJobList";
			String SOAP_ACTION = NAMESPACE + methodname;
			SoapObject request = new SoapObject(NAMESPACE, methodname);
	
			request.AddProperty("description", typeService);
	
			SoapSerializationEnvelope envelope = getSoapSerializationEnvelope(request);
			HttpTransportSE ht = getHttpTransportSE();

			try {

				ht.Call(SOAP_ACTION, envelope);
				SoapObject soapObject = envelope.BodyIn.JavaCast<SoapObject>();

				int countTotal = soapObject.PropertyCount;
			
				Console.WriteLine("salida"+ countTotal );
				Console.WriteLine("salida2"+ soapObject.PropertyCount);

				for(int i = 0 ; i < countTotal ; i++)
				{
					SoapObject soapWorker = soapObject.GetProperty(i).JavaCast<SoapObject>();

					lWorker.Add(new Worker(Convert.ToInt32(soapWorker.GetProperty(0).ToString()), soapWorker.GetProperty(1).ToString(),
						soapWorker.GetProperty(2).ToString(),soapWorker.GetProperty(3).ToString(),
						soapWorker.GetProperty(4).ToString(),soapWorker.GetProperty(5).ToString()));

				}

			} catch (SocketTimeoutException t) {
				t.PrintStackTrace();

			} catch (Exception q) {
			
				//q.PrintStackTrace();
			}
		}

		private void SearchServicesWithThread(String typeService)
		{
			progressDialog.Show();
			new Thread(new ThreadStart(() =>
				{
					loadData(typeService);
					RunOnUiThread(() => onSuccessSearchServices());
				})).Start();
		}

		private void onSuccessSearchServices()
		{
			lsView.Adapter = new  MyListAdapter(this, lWorker);
			progressDialog.Hide();

			new AlertDialog.Builder(this)
				.SetTitle("Resultado")
				.SetMessage("Se encontro " +lWorker.Count+" trabajadores")
				.Show();
		}
	}
}

