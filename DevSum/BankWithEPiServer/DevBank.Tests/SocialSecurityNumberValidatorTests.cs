using DevBank.Business.Validation;
using NUnit.Framework;

namespace DevBank.Tests
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

		/// <summary>
		/// This unit test is an example of test driven development.
		/// The validation attribute currently only sanitizes the input, but should also
		/// (of course) do a full social security number checking! This unit test proves the missing functionality.
		/// </summary>
		[Test]
		public void Should_not_accept_invalid_social_security_numbers()
		{
			// Arrange
			var validator = new SocialSecurityNumberAttribute();

			// Act
			var isValid = validator.IsValid("221212121212");

			// Assert
			Assert.IsFalse(isValid);
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
