using DataAccess.CRUD;
using DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RESTManagers
{
	public class SUNPEManager
	{
		// Post para SUNPE
		public async Task PostToApi(TEF sunpe)
		{
			var url = "https://sunpe.azurewebsites.net/api/SUNPE/SendTEF";

			var httpClient = new HttpClient();

			// Serializar el objeto usuario a JSON
			string jsonUser = JsonConvert.SerializeObject(sunpe);

			// Crear el contenido de la solicitud HTTP
			var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync(url, content);

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsStringAsync();
				throw new Exception(error);
			}

		}

		//Request suplente:
		public void CreateTransaction(TEF sunpe)
		{
			PostToApi(sunpe); /**Wait()*/
		}

		//Se hace el llamado directamente en el controller

		public async Task<List<TEF>> GetToApi()
		{
			var url = "https://sunpe.azurewebsites.net/api/SUNPE/RetrieveAll";

			var httpClient = new HttpClient();

			var list = new List<TEF>();
			HttpResponseMessage response = await httpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var json = response.Content.ReadAsStringAsync().Result;
				list = JsonConvert.DeserializeObject<List<TEF>>(json);
			}
			return list;
		}

	}
}
