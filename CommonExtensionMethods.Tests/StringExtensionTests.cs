using System;
using NUnit.Framework;

namespace CommonExtensionMethods.Tests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void IsNullOrEmpty_WhenActualString_ShouldReturnFalse()
        {
            var test = "asdf123";
            Assert.That(test.IsNullOrEmpty(), Is.False);
        }

        [Test]
        public void IsNullOrEmpty_WhenEmptyString_ShouldReturnTrue()
        {
            var test = string.Empty;
            Assert.That(test.IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void IsNullOrEmpty_WhenNullString_ShouldReturnTrue()
        {
            string test = null;
            Assert.That(test.IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void IsNullOrEmpty_WhenWhiteSpace_ShouldReturnFalse()
        {
            var test = "   ";
            Assert.That(test.IsNullOrEmpty(), Is.False);
        }

        [Test]
        public void OnlyDigits_WhenDigitsAndLetters_ReturnsOnlyDigits()
        {
            var testInput = "123-456-7890";

            var result = testInput.OnlyDigits();
            Assert.That(result, Is.EqualTo("1234567890"));
        }

        [Test]
        public void OnlyDigits_WhenOnlyLetters_ReturnsEmptyString()
        {
            var testInput = "This is only letters";

            var result = testInput.OnlyDigits();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ReduceForDisplay_WhenInputIsTooSmallToReduce_ShouldNotIncludeEnding()
        {
            var testString = "TooSmall";
            //Notice the 17 here, this is because we have to incorporate size of ...
            var result = testString.ReduceForDisplay(17, "...");

            Assert.That(result, Is.EqualTo("TooSmall"));
        }

        [Test]
        public void ReduceForDisplay_WhenInputIsTooSmallToReduce_ShouldNotTruncate()
        {
            var testString = "TooSmall";
            //Notice the 17 here, this is because we have to incorporate size of ...
            var result = testString.ReduceForDisplay(17, string.Empty);

            Assert.That(result, Is.EqualTo("TooSmall"));
        }

        [Test]
        public void ReduceForDisplay_WhenNoStringForDisplay_ShouldTruncateString()
        {
            var testString = "Reduce to here, but this shouldn't be included";
            var result = testString.ReduceForDisplay(14, string.Empty);

            Assert.That(result, Is.EqualTo("Reduce to here"));
        }

        [Test]
        public void ReduceForDisplay_WhenStringForDisplay_ShouldTruncateStringAndAppendStringForDisplay()
        {
            var testString = "Reduce to here, but this shouldn't be included";
            //Notice the 17 here, this is because we have to incorporate size of ...
            var result = testString.ReduceForDisplay(17, "...");

            Assert.That(result, Is.EqualTo("Reduce to here..."));
        }

        [Test]
        public void ReduceForDisplay_WhenTryingToReduceCharactersBelowCountOfEndings_ShouldThrowException()
        {
            var testString = "This";
            Assert.Throws<ArgumentException>(() => testString.ReduceForDisplay(1, "..."));
        }

        [Test]
        public void StripHtml_WhenComplicatedInlineHtml_ShouldReturnNonHtmlResult()
        {
            var test = "This <b>text</b> <img alt='test' height='42' width='23'/> does have html";
            var result = test.StripHtml();

            //Notice the double space here that is due to space after image
            Assert.That("This text  does have html", Is.EqualTo(result));
        }

        [Test]
        public void StripHtml_WhenHtml_ShouldReturnNonHtmlResult()
        {
            var test = "This <b>text</b> does have html";
            var result = test.StripHtml();

            Assert.That("This text does have html", Is.EqualTo(result));
        }

        [Test]
        public void StripHtml_WhenInlineHtml_ShouldReturnNonHtmlResult()
        {
            var test = "This <b>text</b> <img/> does have html";
            var result = test.StripHtml();

            //Notice the double space here that is due to space after image
            Assert.That("This text  does have html", Is.EqualTo(result));
        }

        [Test]
        public void StripHtml_WhenNoHtml_ShouldNotModifyTheString()
        {
            var test = "This text does not have any html";
            var result = test.StripHtml();

            Assert.That(test, Is.EqualTo(result));
        }

        [Test]
        public void StripXml_WhenComplicatedXml_ShouldModifyTheString()
        {
            var test = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><!--Anagrafica del clienti del mercato-->" +
                       "<anagrafica>Test<testata>Data</testata></angrafica>";
            var result = test.StripXml();

            Assert.That("TestData", Is.EqualTo(result));
        }

        [Test]
        public void StripXml_WhenNoXml_ShouldNotModifyTheString()
        {
            var test = "This text does not have any xml";
            var result = test.StripXml();

            Assert.That(test, Is.EqualTo(result));
        }

        [Test]
        public void StripXml_WhenXml_ShouldModifyTheString()
        {
            var test = "<xml>This is encased in xml</xml>";
            var result = test.StripXml();

            Assert.That("This is encased in xml", Is.EqualTo(result));
        }

        [Test]
        public void ToStringOrDefaultFormattableStruct_WhenNotNullValue_ShouldReturnDefaultString()
        {
            DateTime? test = DateTime.Parse("03-15-2016");
            var result = test.ToStringOrDefault("dd-MM-yyyy", "N/A");

            Assert.That(result, Is.EqualTo("15-03-2016"));
        }

        [Test]
        public void ToStringOrDefaultFormattableStruct_WhenNullValue_ShouldReturnDefaultString()
        {
            DateTime? test = null;
            var result = test.ToStringOrDefault("dd-mm-yyyy", "N/A");

            Assert.That(result, Is.EqualTo("N/A"));
        }

        [Test]
        public void ToStringOrDefaultStuct_WhenNotNullValue_ShouldReturnDefaultString()
        {
            int? test = 3819;
            var result = test.ToStringOrDefault("N/A");

            Assert.That(result, Is.EqualTo("3819"));
        }

        [Test]
        public void ToStringOrDefaultStuct_WhenNullValue_ShouldReturnDefaultString()
        {
            int? test = null;
            var result = test.ToStringOrDefault("N/A");

            Assert.That(result, Is.EqualTo("N/A"));
        }
    }
}