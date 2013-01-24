using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

namespace Redslide.HttpLib
{
	/*
	 * A deligate void to be called if there's a network issue
	 */
	public delegate void ConnectionIssue(WebException ex);


	/// <summary>
	/// Request is a static class that holds the http methods
	/// </summary>
	public static class Request
	{
		/*
		 *  Events
		 */
		public static event ConnectionIssue ConnectFailed = delegate { };



		/*
		 * Cookie Container
		 */
		private static CookieContainer cookies = new CookieContainer();
				

		/*
		 * Methods
		 */
		#region Methods

		#region GET
		/// <summary>
		/// Performs a HTTP get operation
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Get(string URL, Action<string> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Get(URL, new {}, StreamToStringCallback(SuccessCallback), Headers);
		}

		/// <summary>
		/// Performs a HTTP get operation with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Get(string URL, object Parameters, Action<String> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Get(URL, Parameters, StreamToStringCallback(SuccessCallback), (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP get operation with parameters and a function that is called on failure
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Get(string URL, object Parameters, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			Get(URL, Parameters, StreamToStringCallback(SuccessCallback), FailCallback, Headers);
		}

		/// <summary>
		/// Performs a HTTP get request
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Get(string URL, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Get(URL, new {}, SuccessCallback, Headers);
		}

		/// <summary>
		/// Performs a HTTP get request with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Get(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Get(URL, Parameters, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}
		 
		/// <summary>
		/// Performs a HTTP get request with parameters and a function that is called on failure
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Get(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			UriBuilder b = new UriBuilder(URL);
			
			/*
			 * Append Paramters to the URL
			 */


			if (Parameters != null)
			{
				if (!string.IsNullOrWhiteSpace(b.Query))
				{
					b.Query = b.Query.Substring(1) + "&" + Utils.SerializeQueryString(Parameters);
				}
				else
				{
					b.Query = Utils.SerializeQueryString(Parameters);
				}
				
			}


			MakeRequest("application/x-www-form-urlencoded", "GET", b.Uri.ToString(), new {}, SuccessCallback, FailCallback, Headers);
		}
		#endregion

		#region HEAD
		/// <summary>
		/// Performs a HTTP head operation
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Head(string URL, Action<string> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Head(URL, new {}, StreamToStringCallback(SuccessCallback), Headers);
		}

		/// <summary>
		/// Performs a HTTP head operation with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Head(string URL, object Parameters, Action<String> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Head(URL, Parameters, StreamToStringCallback(SuccessCallback), (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP head operation with parameters and a function that is called on failure
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Head(string URL, object Parameters, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			Head(URL, Parameters, StreamToStringCallback(SuccessCallback), FailCallback, Headers);
		}
		/// <summary>
		/// Performs a HTTP head operation
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Head(string URL, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Head(URL, new {}, SuccessCallback, Headers);
		}

		/// <summary>
		/// Performs a HTTP head operation with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">A function that is called on success</param>
		public static void Head(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Head(URL, Parameters, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP head operation with parameters and a function that is called on failure
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">KVP Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Head(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			UriBuilder b = new UriBuilder(URL);

			/*
			 * Append Paramters to the URL
			 */


			#if NETFX_CORE
			if (Parameters.GetType().GetTypeInfo().DeclaredProperties.ToArray().Length > 0)
			#else
			if (Parameters.GetType().GetProperties().Length > 0)
			#endif
			{
				if (!string.IsNullOrWhiteSpace(b.Query))
				{
					b.Query = b.Query.Substring(1) + "&" + Utils.SerializeQueryString(Parameters);
				}
				else
				{
					b.Query = Utils.SerializeQueryString(Parameters);
				}

			}


			MakeRequest("application/x-www-form-urlencoded", "HEAD", b.Uri.ToString(), new {}, SuccessCallback, FailCallback, Headers);
		}
		#endregion

		#region POST
		/// <summary>
		/// Performs a HTTP post request on a target with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		public static void Post(string URL, object Parameters, Action<string> SuccessCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "POST", URL, Parameters, StreamToStringCallback(SuccessCallback), (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP post request on a target with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		public static void Post(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "POST", URL, Parameters, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}


		/// <summary>
		/// Performs a HTTP post request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Post(string URL, object Parameters, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "POST", URL, Parameters, StreamToStringCallback(SuccessCallback), FailCallback, Headers);
		}

		/// <summary>
		/// Performs a HTTP post request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Post(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "POST", URL, Parameters, SuccessCallback, FailCallback, Headers);
		}
		#endregion

		#region PUT
		/// <summary>
		/// Performs a HTTP put request on a target with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		public static void Put(string URL, object Parameters, Action<string> SuccessCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "PUT", URL, Parameters, StreamToStringCallback(SuccessCallback), (webEx) =>
				{
					ConnectFailed(webEx);

				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP put request on a target with parameters
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		public static void Put(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "PUT", URL, Parameters, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);

				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP put request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Put(string URL, object Parameters, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "PUT", URL, Parameters, StreamToStringCallback(SuccessCallback), FailCallback, Headers);
		}

		/// <summary>
		/// Performs a HTTP put request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Put(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "PUT", URL, Parameters, SuccessCallback, FailCallback, Headers);
		}
		#endregion

		#region DELETE
		/// <summary>
		/// Performs a HTTP delete request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Delete(string URL, object Parameters, Action<string> SuccessCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "DELETE", URL, Parameters, StreamToStringCallback(SuccessCallback), (webEx) =>
				{
					ConnectFailed(webEx);

				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP delete request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Delete(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "DELETE", URL, Parameters, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);

				}, Headers);
		}

		/// <summary>
		/// Performs a HTTP delete request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Delete(string URL, object Parameters, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "DELETE", URL, Parameters, StreamToStringCallback(SuccessCallback), FailCallback, Headers);
		}

		/// <summary>
		/// Performs a HTTP delete request with parameters and a fail function
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Array of parameters</param>
		/// <param name="SuccessCallback">Function that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Delete(string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			MakeRequest("application/x-www-form-urlencoded", "DELETE", URL, Parameters, SuccessCallback, FailCallback, Headers);
		}
		#endregion

		#region UPLOAD
		/// <summary>
		/// Upload an array of files to a remote host using the HTTP post multipart method
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Parmaters</param>
		/// <param name="files">An array of files</param>
		/// <param name="SuccessCallback">funciton that is called on success</param>
		public static void Upload(string URL, object Parameters, NamedFileStream[] files, Action<string> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Upload(URL, Parameters, files, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}

		/// <summary>
		/// Upload an array of files to a remote host using the HTTP post multipart method
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Parmaters</param>
		/// <param name="files">An array of files</param>
		/// <param name="SuccessCallback">funciton that is called on success</param>
		public static void Upload(string URL, object Parameters, NamedFileStream[] files, Action<WebHeaderCollection, Stream> SuccessCallback, WebHeaderCollection Headers = null)
		{
			Upload(URL, Parameters, files, SuccessCallback, (webEx) =>
				{
					ConnectFailed(webEx);
				}, Headers);
		}

		/// <summary>
		/// Upload an array of files to a remote host using the HTTP post multipart method
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Parmaters</param>
		/// <param name="files">An array of files</param>
		/// <param name="SuccessCallback">Funciton that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Upload(string URL, object Parameters, NamedFileStream[] files, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			Upload(URL, "POST", files, SuccessCallback, FailCallback, Headers);
		}

		/// <summary>
		/// Upload an array of files to a remote host using the HTTP post multipart method
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="parameters">Parmaters</param>
		/// <param name="files">An array of files</param>
		/// <param name="SuccessCallback">Funciton that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Upload(string URL, object Parameters, NamedFileStream[] files, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			Upload(URL, "POST", files, SuccessCallback, FailCallback, Headers);
		}

		/// <summary>
		/// Upload an array of files to a remote host using the HTTP post or put multipart method
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="Method">Request Method - POST or PUT</param>
		/// <param name="Parameters">Parmaters</param>
		/// <param name="files">An array of files</param>
		/// <param name="SuccessCallback">Funciton that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Upload(string URL, string Method, object Parameters, NamedFileStream[] Files, Action<string> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			Upload(URL, Method, Parameters, Files, StreamToStringCallback(SuccessCallback), FailCallback, Headers);
		}

		/// <summary>
		/// Upload an array of files to a remote host using the HTTP post or put multipart method
		/// </summary>
		/// <param name="URL">Target URL</param>
		/// <param name="Method">Request Method - POST or PUT</param>
		/// <param name="Parameters">Parmaters</param>
		/// <param name="files">An array of files</param>
		/// <param name="SuccessCallback">Funciton that is called on success</param>
		/// <param name="FailCallback">Function that is called on failure</param>
		public static void Upload(string URL, string Method, object Parameters, NamedFileStream[] Files, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			if (Method != "POST" && Method != "PUT")
			{
				throw new ArgumentException("Request method must be POST or PUT");
			}

			try
			{
				/*
				 * Generate a random boundry string
				 */
				string boundary = RandomString(12);

				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(URL));
				request.Method = Method;
				request.ContentType = "multipart/form-data, boundary=" + boundary;
				request.CookieContainer = cookies;
				if (Headers != null) request.Headers = Headers;
	 
				request.BeginGetRequestStream(new AsyncCallback((IAsyncResult asynchronousResult) =>
				{
					/*
					 * Create a new request
					 */
					HttpWebRequest tmprequest = (HttpWebRequest)asynchronousResult.AsyncState;

					/*
					 * Get a stream that we can write to
					 */
					Stream postStream = tmprequest.EndGetRequestStream(asynchronousResult);
					string querystring = "\n";

					/*
					 * Serialize parameters in multipart manner
					 */
					#if NETFX_CORE
					foreach (var property in Parameters.GetType().GetTypeInfo().DeclaredProperties)
					#else
					foreach (var property in Parameters.GetType().GetProperties())                    
					#endif
					{
						querystring += "--" + boundary + "\n";
						querystring += "content-disposition: form-data; name=\"" + System.Uri.EscapeDataString(property.Name) + "\"\n\n";
						querystring += System.Uri.EscapeDataString(property.GetValue(Parameters, null).ToString());
						querystring += "\n";
					}

				
					/*
					 * Then write query string to the postStream
					 */
					byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(querystring);
					postStream.Write(byteArray, 0, byteArray.Length);
				
					/*
					 * A boundary string that we'll reuse to separate files
					 */ 
					byte[] closing = System.Text.Encoding.UTF8.GetBytes("\n--" + boundary + "--\n");


					/*
					 * Write each files to the postStream
					 */
					foreach (NamedFileStream file in Files)
					{
						/*
						 * A temporary buffer to hold the file stream
						 * Not sure if this is needed ???
						 */
						Stream outBuffer = new MemoryStream();

						/*
						 * Additional info that is prepended to the file
						 */
						string qsAppend;
						qsAppend = "--" + boundary + "\ncontent-disposition: form-data; name=\""+file.Name +"\"; filename=\"" + file.Filename + "\"\r\nContent-Type: " + file.ContentType + "\r\n\r\n";
	   
						/*
						 * Read the file into the output buffer
						 */
						StreamReader sr = new StreamReader(file.Stream);
						outBuffer.Write(System.Text.Encoding.UTF8.GetBytes(qsAppend), 0, qsAppend.Length);

						int bytesRead = 0;
						byte[] buffer = new byte[4096];

						while ((bytesRead = file.Stream.Read(buffer, 0, buffer.Length)) != 0)
						{
							outBuffer.Write(buffer, 0, bytesRead);

						}


						/*
						 * Write the delimiter to the output buffer
						 */
						outBuffer.Write(closing, 0, closing.Length);



						/*
						 * Write the output buffer to the post stream using an intemediate byteArray
						 */
						outBuffer.Position = 0;
						byte[] tempBuffer = new byte[outBuffer.Length];
						outBuffer.Read(tempBuffer, 0, tempBuffer.Length);
						postStream.Write(tempBuffer, 0, tempBuffer.Length);
						postStream.Flush();           
					}

				
					postStream.Flush();
					postStream.Dispose();

					tmprequest.BeginGetResponse(ProcessCallback(SuccessCallback, FailCallback), tmprequest);

				}), request);
			}
			catch (WebException webEx)
			{
				FailCallback(webEx);
			}

		}
		#endregion

		#region Private Methods

		private static Action<WebHeaderCollection, Stream> StreamToStringCallback(Action<string> StringCallback)
		{
			return (WebHeaderCollection headers ,Stream resultStream) =>
			{
				using (StreamReader sr = new StreamReader(resultStream))
				{
					StringCallback(sr.ReadToEnd());
				}
			};
		}


		private static void MakeRequest(string ContentType, string Method, string URL, object Parameters, Action<WebHeaderCollection, Stream> SuccessCallback, Action<WebException> FailCallback, WebHeaderCollection Headers = null)
		{
			if (Parameters == null)
			{
				throw new ArgumentNullException("Parameters object cannot be null");
			}

			if (string.IsNullOrWhiteSpace(ContentType))
			{
				throw new ArgumentException("Content type is missing");
			}

			if (string.IsNullOrWhiteSpace(URL))
			{
				throw new ArgumentException("URL is empty");
			}

			if (Method != "HEAD" && Method != "GET" && Method != "POST" && Method != "DELETE" && Method != "PUT")
			{
				throw new ArgumentException("Invalid Method");
			}

			try
			{
				/*
				 * Create new Request
				 */
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(URL));
				request.CookieContainer = cookies;
				request.Method = Method;
				request.ContentType = ContentType;
				if (Headers != null) request.Headers = Headers;

			  

				/*
				 * Asynchronously get the response
				 */
				if (Method == "POST" || Method == "PUT" || Method == "DELETE")
				{
					request.BeginGetRequestStream(new AsyncCallback((IAsyncResult callbackResult) =>
					{

						HttpWebRequest tmprequest = (HttpWebRequest)callbackResult.AsyncState;
						Stream postStream;

						postStream = tmprequest.EndGetRequestStream(callbackResult);


						string postbody = "";

						
						postbody = Utils.SerializeQueryString(Parameters);
						

						// Convert the string into a byte array. 
						byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postbody);

						// Write to the request stream.
						postStream.Write(byteArray, 0, byteArray.Length);
						postStream.Flush();
						postStream.Dispose();

						// Start the asynchronous operation to get the response
						tmprequest.BeginGetResponse(ProcessCallback(SuccessCallback,FailCallback), tmprequest);


					}), request);
				}
				else if (Method == "GET" || Method=="HEAD")
				{
					request.BeginGetResponse(ProcessCallback(SuccessCallback,FailCallback), request);
				}
			}
			catch (WebException webEx)
			{
				FailCallback(webEx);
			}
		}

		/*
		 * Muhammad Akhtar @StackOverflow
		 */
		private static string RandomString(int passwordLength)
		{
			string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
			char[] chars = new char[passwordLength];
			Random rd = new Random();

			for (int i = 0; i < passwordLength; i++)
			{
				chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
			}

			return new string(chars);
		}



		private static AsyncCallback ProcessCallback(Action<WebHeaderCollection, Stream>Success,Action<WebException>Fail)
		{
			return new AsyncCallback((callbackResult) =>
				{
					HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;

					try
					{
						using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.EndGetResponse(callbackResult))
						{

								
							Success(myResponse.Headers, myResponse.GetResponseStream());
						   
						}

					}
					catch (WebException webEx)
					{
						if (ConnectFailed != null)
						{
							Fail(webEx);

						}

					}
				});
		}
		#endregion




		#endregion
	}


}
