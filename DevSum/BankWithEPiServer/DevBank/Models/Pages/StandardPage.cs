using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace DevBank.Models.Pages
{
	[ContentType(
		DisplayName = "Standard Page", 
		GUID = "504428E1-04FD-44A6-9BDA-CFFBA671A52C", 
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