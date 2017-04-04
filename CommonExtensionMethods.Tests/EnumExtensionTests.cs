using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonExtensionMethods.Tests
{
    [TestFixture]
    public class EnumExtensionTests
    {
        #region EnumToList Tests

        [Test]
        public void EnumToList_WhenEnumerationHasNoValues_ShouldReturnEmptyList()
        {
            var result = typeof(EmptyEnum).EnumToList<EmptyEnum>();

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnumToList_WhenEmumerationHasNoValues_ShouldThrowExceptionIfTypesDoNotMatch()
        {
            Assert.Throws<InvalidCastException>(() => typeof(EmptyEnum).EnumToList<string>());
        }

        [Test]
        public void EnumToList_WhenEnumerationHasNoValues_ShouldReturnEmptyListOfEnum()
        {
            var result = typeof(EmptyEnum).EnumToList<EmptyEnum>();

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<List<EmptyEnum>>());
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_AndCastingToDifferentType()
        {
            Assert.Throws<InvalidCastException>(() => typeof(EnumWithValues).EnumToList<string>());
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_ShouldReturnListTypeOfEnum()
        {
            var result = typeof(EnumWithValues).EnumToList<EnumWithValues>();

            Assert.IsNotNull(result);
            Assert.That(typeof(List<EnumWithValues>), Is.EqualTo(result.GetType()));
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_ShouldReturnListWithCorrectCount()
        {
            var result = typeof(EnumWithValues).EnumToList<EnumWithValues>();

            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_ShouldReturnListWithCorrectFirstElement()
        {
            var result = typeof(EnumWithValues).EnumToList<EnumWithValues>();

            Assert.That(EnumWithValues.Test, Is.EqualTo(result[0]));
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_ShouldReturnListWithCorrectSecondElement()
        {
            var result = typeof(EnumWithValues).EnumToList<EnumWithValues>();

            Assert.That(EnumWithValues.Blank, Is.EqualTo(result[1]));
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_ShouldReturnListWithCorrectThirdElement()
        {
            var result = typeof(EnumWithValues).EnumToList<EnumWithValues>();

            Assert.That(EnumWithValues.Value, Is.EqualTo(result[2]));
        }

        [Test]
        public void EnumToList_WhenEnumerationHasValues_ShouldReturnListWithCorrectForthElement()
        {
            var result = typeof(EnumWithValues).EnumToList<EnumWithValues>();

            Assert.That(EnumWithValues.MyFail, Is.EqualTo(result[3]));
        }

        #endregion

        #region EnumToDictionary Tests

        [Test]
        public void EnumToDictionary_EnumWithValues_ShouldNotReturnNull()
        {
            var result = typeof(EnumWithValues).EnumToDictionary();

            Assert.IsNotNull(result);
        }

        [Test]
        public void EnumToDictionary_EnumWithValues_ShouldReturnCorrectCount()
        {
            var result = typeof(EnumWithValues).EnumToDictionary();

            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        public void EnumToDictionary_EnumWithValues_ShouldReturnCorrectFirstElement()
        {
            var result = typeof(EnumWithValues).EnumToDictionary();

            Assert.That(result["Test"], Is.EqualTo(1));
        }

        [Test]
        public void EnumToDictionary_EnumWithValues_ShouldReturnCorrectSecondElement()
        {
            var result = typeof(EnumWithValues).EnumToDictionary();

            Assert.That(result["Blank"], Is.EqualTo(2));
        }

        [Test]
        public void EnumToDictionary_EnumWithValues_ShouldReturnCorrectThirdElement()
        {
            var result = typeof(EnumWithValues).EnumToDictionary();

            Assert.That(result["Value"], Is.EqualTo(3));
        }

        [Test]
        public void EnumToDictionary_EnumWithValues_ShouldReturnCorrectForthElement()
        {
            var result = typeof(EnumWithValues).EnumToDictionary();

            Assert.That(result["MyFail"], Is.EqualTo(4));
        }

        #endregion

        #region SetupEnums

        internal enum EmptyEnum
        { }

        internal enum EnumWithValues
        {
            Test = 1,
            Blank = 2,
            Value = 3,
            MyFail = 4
        }



        #endregion
    }
}
