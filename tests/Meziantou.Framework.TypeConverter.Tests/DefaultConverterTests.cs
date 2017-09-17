﻿using System;
using System.Globalization;
using Meziantou.Framework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.Framework.Tests.Utilities
{
    [TestClass]
    public class DefaultConverterTests
    {
        [Flags]
        private enum SampleEnum
        {
            None = 0x0,
            Option1 = 0x1,
            Option2 = 0x2,
            Option3 = 0x4
        }

        [TestMethod]
        public void TryConvert_StringToInt32_01()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("42", cultureInfo, out int value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(42, value);
        }

        [TestMethod]
        public void TryConvert_StringToInt32_02()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("", cultureInfo, out int value);

            Assert.AreEqual(false, converted);
        }

        [TestMethod]
        public void TryConvert_StringToNullableInt32_01()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("42", cultureInfo, out int? value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(42, value);
        }

        [TestMethod]
        public void TryConvert_StringToNullableInt32_02()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("", cultureInfo, out int? value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(null, value);
        }
        [TestMethod]
        public void TryConvert_StringToEnum_01()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("2", cultureInfo, out SampleEnum value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(SampleEnum.Option2, value);
        }

        [TestMethod]
        public void TryConvert_StringToEnum_02()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("Option1, Option2", cultureInfo, out SampleEnum value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(SampleEnum.Option1 | SampleEnum.Option2, value);
        }

        [TestMethod]
        public void TryConvert_StringToGuid_01()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("afa523e478df4b2da8c86d6b43c48e3e", cultureInfo, out Guid value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(Guid.Parse("afa523e478df4b2da8c86d6b43c48e3e"), value);
        }

        [TestMethod]
        public void TryConvert_StringToNullableLong_01()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("3000000000", cultureInfo, out long? value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(3000000000L, value);
        }

        [TestMethod]
        public void TryConvert_CultureInfo_01()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("fr-FR", cultureInfo, out CultureInfo value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual("fr-FR", value.Name);
        }

        [TestMethod]
        public void TryConvert_CultureInfo_02()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("es", cultureInfo, out CultureInfo value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual("es", value.Name);
        }

        [TestMethod]
        public void TryConvert_CultureInfo_03()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("dfgnksdfklgfg", cultureInfo, out CultureInfo value);

            Assert.AreEqual(false, converted);
        }

        [TestMethod]
        public void TryConvert_CultureInfo_04()
        {
            var converter = new DefaultConverter();
            var cultureInfo = CultureInfo.InvariantCulture;
            var converted = converter.TryChangeType("", cultureInfo, out CultureInfo value);

            Assert.AreEqual(true, converted);
            Assert.AreEqual(CultureInfo.InvariantCulture, value);
        }
    }
}