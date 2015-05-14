using System;
using System.ServiceModel;

namespace DevBank.Proxy
{
	public class Proxy : IProxy
	{
		public TResult Call<T, TResult>(Func<T, TResult> function)
		{
			var factory = new ChannelFactory<T>("*");
			var client = default(T);
			var task = default(TResult);

			try
			{
				client = factory.CreateChannel();

				task = function(client);

				factory.Close();

				((ICommunicationObject)client).Close();
			}
			catch
			{
				((ICommunicationObject)client).Abort();
			}

			return task;
		}
	}
}
