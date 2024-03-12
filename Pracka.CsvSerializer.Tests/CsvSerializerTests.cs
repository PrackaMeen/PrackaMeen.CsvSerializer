using Pracka.CsvSerializer.Abstractions;

namespace Pracka.CsvSerializer.Tests
{
    public class CsvSerializerTests
    {
        [Fact]
        public void Not_Null_Entity_Without_Properties_Has_Empty_Content()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithoutProperties = new EntityWithoutProperties();
            var content = csvSerializer.GetCsvContentFrom(entityWithoutProperties);

            Assert.NotNull(entityWithoutProperties);
            Assert.Equal(string.Empty, content);
        }

        [Fact]
        public void Not_Null_Entity_With_Properties_Has_Not_Empty_Content()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithProperties = new EntityWithExactOneProperty();
            var content = csvSerializer.GetCsvContentFrom(entityWithProperties);

            Assert.NotNull(content);
            Assert.NotEqual(string.Empty, content);
        }

        [Fact]
        public void Entity_With_Exact_One_Property_Has_Content()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithOneProperty = new EntityWithExactOneProperty();
            var content = csvSerializer.GetCsvContentFrom(entityWithOneProperty);

            var lines = content.Split(Environment.NewLine);

            int numberOfExpectedLines = 2;
            Assert.Equal(numberOfExpectedLines, lines.Length);
        }

        [Fact]
        public void Entity_With_Multiple_Properties_Has_Content()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithMultipleProperties = new EntityWithMultipleProperties();
            var content = csvSerializer.GetCsvContentFrom(entityWithMultipleProperties);

            var lines = content.Split(Environment.NewLine);

            int numberOfExpectedLines = 2;
            Assert.Equal(numberOfExpectedLines, lines.Length);
        }

        [Fact]
        public void Entity_With_Exact_One_Default_Property_Content_Header_Is_Valid()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithExactOneProperty = new EntityWithExactOneProperty();

            var content = csvSerializer.GetCsvContentFrom(entityWithExactOneProperty);

            var expectedContentHeader = $"Property{Environment.NewLine}";

            Assert.NotNull(content);
            Assert.Equal(expectedContentHeader, content);
        }

        [Fact]
        public void Entity_With_Exact_One_Initialized_Property_Content_Header_Is_Valid()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithExactOneProperty = new EntityWithExactOneProperty()
            {
                Property = "PropertyValue"
            };

            var content = csvSerializer.GetCsvContentFrom(entityWithExactOneProperty);

            var expectedContentHeader = $"Property{Environment.NewLine}PropertyValue";

            Assert.NotNull(content);
            Assert.Equal(expectedContentHeader, content);
        }

        [Fact]
        public void Entity_With_Multiple_Default_Properties_Content_Header_Is_Valid()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithMultipleProperties = new EntityWithMultipleProperties();

            var content = csvSerializer.GetCsvContentFrom(entityWithMultipleProperties);

            var expectedContentHeader = $"Property1,Property2,Property3{Environment.NewLine},,";

            Assert.NotNull(content);
            Assert.Equal(expectedContentHeader, content);
        }

        [Fact]
        public void Entity_With_Multiple_Initialized_Properties_Content_Header_Is_Valid()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithMultipleProperties = new EntityWithMultipleProperties()
            {
                Property1 = "Property1Value",
                Property2 = "Property2Value",
                Property3 = "Property3Value"
            };

            var content = csvSerializer.GetCsvContentFrom(entityWithMultipleProperties);

            var expectedContentHeader = $"Property1,Property2,Property3{Environment.NewLine}Property1Value,Property2Value,Property3Value";

            Assert.NotNull(content);
            Assert.Equal(expectedContentHeader, content);
        }

        [Fact]
        public void Entity_With_Exact_One_Initialized_Property_Content_Is_Valid()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithExactOneProperty = new EntityWithExactOneProperty()
            {
                Property = "PropertyValue"
            };

            var content = csvSerializer.GetCsvContentFrom(entityWithExactOneProperty);

            var expectedContent = $"Property{Environment.NewLine}PropertyValue";

            Assert.NotNull(content);
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void Entity_With_Multiple_Initialized_Properties_Content_Is_Valid()
        {
            ICsvSerializer csvSerializer = new CsvSerializer();

            var entityWithMultipleProperties = new EntityWithMultipleProperties()
            {
                Property1 = "Property1Value",
                Property2 = "Property2Value",
                Property3 = "Property3Value"
            };

            var content = csvSerializer.GetCsvContentFrom(entityWithMultipleProperties);

            var expectedContent = $"Property1,Property2,Property3{Environment.NewLine}Property1Value,Property2Value,Property3Value";

            Assert.NotNull(content);
            Assert.Equal(expectedContent, content);
        }

        private class EntityWithoutProperties
        {

        }

        private class EntityWithExactOneProperty
        {
            public string Property { get; set; }
        }

        private class EntityWithMultipleProperties
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
        }
    }
}