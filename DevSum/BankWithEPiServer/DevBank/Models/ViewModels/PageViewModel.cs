using DevBank.CustomerService.Entities;
using EPiServer.Core;

namespace DevBank.Models.ViewModels
{
	public interface IPageViewModel<out T>
	{
		T CurrentPage { get; }

		LocalCustomer CurrentUser { get; }
	}

	public class PageViewModel<T> : IPageViewModel<T> where T : PageData
	{
		public T CurrentPage { get; private set; }
		public LocalCustomer CurrentUser { get; private set; }

		public PageViewModel(T currentPage, LocalCustomer currentUser = null)
		{
			CurrentPage = currentPage;

			CurrentUser = currentUser ?? new LocalCustomer();
		}

		public object ToJson()
		{
			return new {firstName = CurrentUser.FirstName, lastName = CurrentUser.LastName};
		}
	}
}