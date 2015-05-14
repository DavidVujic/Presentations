using System;

namespace DevBank.Proxy
{
	public interface IProxy
	{
		TResult Call<T, TResult>(Func<T, TResult> function);
	}
}