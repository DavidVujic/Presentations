using InternetBank.Business.Validation;
using NUnit.Framework;

namespace InternetBank.Tests
{
	[TestFixture]
	public class SocialSecurityNumberValidatorTests
	{
		[Test]
		public void Should_accept_valid_social_security_numbers()
		{
			// Arrange
			var validator = new SocialSecurityNumberAttribute();

			// Act
			var isValid = validator.IsValid("191212121212");

			// Assert
			Assert.IsTrue(isValid);
		}

		[Test]
		public void Should_not_accept_not_allowed_characters_in_social_security_numbers()
		{
			// Arrange
			var validator = new SocialSecurityNumberAttribute();

			// Act
			var isValid = validator.IsValid("191212<script>121212");

			// Assert
			Assert.IsFalse(isValid);
		}
	}
}
