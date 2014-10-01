using System;

namespace InternetBank.Proxy
{
	public interface IProxy
	{
		TResult Call<T, TResult>(Func<T, TResult> function);
	}
}