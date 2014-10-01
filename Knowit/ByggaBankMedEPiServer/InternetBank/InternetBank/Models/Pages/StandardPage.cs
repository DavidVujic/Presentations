using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace InternetBank.Models.Pages
{
	[ContentType(
		DisplayName = "Standard Page", 
		GUID = "1c7a7246-e302-4750-a4c7-4a4fdace1acf", 
		Description = "Used as an internet bank standard page")]
	public class StandardPage : PageData
	{
		[CultureSpecific]
		[Display(
			Name = "Main body",
			Description =
				"The main body will be shown in the main content area of the page, " +
				"using the XHTML-editor you can insert for example text, images and tables.",
			GroupName = SystemTabNames.Content,
			Order = 1)]
		public virtual XhtmlString MainBody { get; set; }
	}
}