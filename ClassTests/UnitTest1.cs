using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork09;
using System;
using System.IO;

namespace ClassTests
{
    [TestClass]
    public class GeoCoordinatesTests
    {
        [TestMethod]
        public void GetObjectCount_ShouldReturnCorrectCount()
        {
            // Arrange
            GeoCoordinates geoCoordinates1 = new GeoCoordinates();
            GeoCoordinates geoCoordinates2 = new GeoCoordinates();

            // Act
            int loc = GeoCoordinates.GetObjectCount();

            // Assert
            Assert.AreEqual(loc, 22);
        }
        Random rnd = new Random();
        // Тестирование конструктора без параметра 
        [TestMethod]
        public void ConstructorWithoutParameter()
        {
            // arrange
            GeoCoordinates loc1 = new GeoCoordinates();

            // assert
            Assert.AreEqual(0.01, loc1.Latitude);
            Assert.AreEqual(0.01, loc1.Longitude);
        }
        // Тестирование конструктора с параметрами
        [TestMethod]
        public void ConstructorWithParameter()
        {
            // arrange
            GeoCoordinates loc1 = new GeoCoordinates(2.12, 89.99);

            // assert
            Assert.AreEqual(2.12, loc1.Latitude);
            Assert.AreEqual(89.99, loc1.Longitude);
        }
        // Тестирование конструктора с параметрами ДЧС
        [TestMethod]
        public void ConstructorWithParameterRnd()
        {
            // arrange
            GeoCoordinates loc1 = new GeoCoordinates(rnd);

            // assert
            Assert.IsTrue(loc1.Latitude >= -90);
            Assert.IsTrue(loc1.Latitude <= 90);
            Assert.IsTrue(loc1.Longitude <= 180);
            Assert.IsTrue(loc1.Longitude >= -180);
        }
        // Тестирование конструктора копирования
        [TestMethod]
        public void ConstructorWithParameterCopy()
        {
            // arrange
            GeoCoordinates loc1 = new GeoCoordinates(rnd);
            // art
            GeoCoordinates loc2 = new GeoCoordinates(loc1);
            // assert
            Assert.AreEqual(loc1.Latitude, loc2.Latitude);
            Assert.AreEqual(loc1.Longitude, loc2.Longitude);
        }

        // Тестирование Широты
        [TestMethod]
        public void ShouldSetLatitude()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Act
            geoCoordinates.Latitude = 45.0;

            // Assert
            Assert.AreEqual(45.0, geoCoordinates.Latitude, "Широта должна быть установлена в 45.0");
        }
        // Тестирование Широты
        [TestMethod]
        public void LatitudeShouldThrowException()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => geoCoordinates.Latitude = 100.0, "Должно быть выброшено исключение для недопустимого значения широты");
            Assert.ThrowsException<Exception>(() => geoCoordinates.Latitude = -100.0, "Должно быть выброшено исключение для недопустимого значения широты");
        }
        // Тестирование Долготы
        [TestMethod]
        public void ShouldSetLongitude()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Act
            geoCoordinates.Longitude = 120.0;

            // Assert
            Assert.AreEqual(120.0, geoCoordinates.Longitude, "Долгота должна быть установлена в 120.0");
        }
        // Тестирование Долготы
        [TestMethod]
        public void LongitudeShouldThrowException()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => geoCoordinates.Longitude = 190.0, "Должно быть выброшено исключение для недопустимого значения долготы");
            Assert.ThrowsException<Exception>(() => geoCoordinates.Longitude = -190.0, "Должно быть выброшено исключение для недопустимого значения долготы");
        }
        // Тестирование вывода координат
        [TestMethod]
        public void ShouldPrintCoordinates()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();
            geoCoordinates.Latitude = 45.0;
            geoCoordinates.Longitude = 120.0;

            // Capture console output
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Act
                geoCoordinates.Print();

                // Assert
                var expectedOutput = $"Широта: {geoCoordinates.Latitude}, Долгота: {geoCoordinates.Longitude}{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, consoleOutput.ToString(), "Вывод в консоль должен быть корректным");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Должно быть выброшено исключение для некорректной широты")]
        public void CreateFromUserInput_InvalidLatitude_ShouldThrowException()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Подменяем стандартный ввод
            var input = new StringReader("invalid\n");
            Console.SetIn(input);

            // Act & Assert
            geoCoordinates.CreateFromUserInput();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Должно быть выброшено исключение для некорректной долготы")]
        public void CreateFromUserInput_InvalidLongitude_ShouldThrowException()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Подменяем стандартный ввод
            var input = new StringReader("45.0\ninvalid\n");
            Console.SetIn(input);

            // Act & Assert
            geoCoordinates.CreateFromUserInput();
        }
        [TestMethod]
        public void DistanceSt_ShouldReturnCorrectDistance()
        {
            // Arrange
            var location1 = new GeoCoordinates { Latitude = 40.7128, Longitude = -74.0060 }; // Нью-Йорк
            var location2 = new GeoCoordinates { Latitude = 34.0522, Longitude = -118.2437 }; // Лос-Анджелес

            // Act
            var distance = GeoCoordinates.DistanceSt(location1, location2);

            // Assert
            // Определите ожидаемое расстояние между Нью-Йорком и Лос-Анджелесом, используя известные значения
            // Пожалуйста, учтите, что значения могут немного отличаться из-за точности вычислений.
            var expectedDistance = 3935.74; // Примерное расстояние между Нью-Йорком и Лос-Анджелесом в километрах
            Assert.AreEqual(expectedDistance, distance, 0.01, "Расстояние должно быть приблизительно равным ожидаемому");
        }

        [TestMethod]
        public void DegreesToRadiansSt_ShouldConvertDegreesToRadians()
        {
            // Arrange
            double degrees = 180.0;

            // Act
            var radians = GeoCoordinates.DegreesToRadiansSt(degrees);

            // Assert
            // 180 градусов должны преобразоваться в π радиан
            Assert.AreEqual(Math.PI, radians, 0.0001, "180 градусов должны быть преобразованы в π радиан");
        }
        private const double EarthRadius = 6371; // Радиус Земли в километрах

        [TestMethod]
        public void Distance_ShouldReturnCorrectDistance()
        {
            // Arrange
            var location1 = new GeoCoordinates { Latitude = 40.7128, Longitude = -74.0060 }; // Нью-Йорк
            var location2 = new GeoCoordinates { Latitude = 34.0522, Longitude = -118.2437 }; // Лос-Анджелес

            // Act
            var distance = location1.Distance(location2);

            // Assert
            // Определите ожидаемое расстояние между Нью-Йорком и Лос-Анджелесом, используя известные значения
            // Пожалуйста, учтите, что значения могут немного отличаться из-за точности вычислений.
            var expectedDistance = 3935.74; // Примерное расстояние между Нью-Йорком и Лос-Анджелесом в километрах
            Assert.AreEqual(expectedDistance, distance, 0.01, "Расстояние должно быть приблизительно равным ожидаемому");
        }

        [TestMethod]
        public void DegreesToRadians_ShouldConvertDegreesToRadians()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates();

            // Act
            var radians = geoCoordinates.DegreesToRadians(180.0);

            // Assert
            // 180 градусов должны преобразоваться в π радиан
            Assert.AreEqual(Math.PI, radians, 0.0001, "180 градусов должны быть преобразованы в π радиан");
        }
        [TestMethod]
        public void IncrementOperator_ShouldIncrementCoordinates()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates(40.0, -75.0);

            // Act
            geoCoordinates++;

            // Assert
            Assert.AreEqual(40.01, geoCoordinates.Latitude, 0.0001, "Широта должна быть увеличена на 0.01");
            Assert.AreEqual(-74.99, geoCoordinates.Longitude, 0.0001, "Долгота должна быть увеличена на 0.01");
        }

        [TestMethod]
        public void NegationOperator_ShouldNegateCoordinates()
        {
            // Arrange
            var geoCoordinates = new GeoCoordinates(40.0, -75.0);

            // Act
            var negatedCoordinates = -geoCoordinates;

            // Assert
            Assert.AreEqual(-40.0, negatedCoordinates.Latitude, 0.0001, "Широта должна быть отрицательной");
            Assert.AreEqual(75.0, negatedCoordinates.Longitude, 0.0001, "Долгота должна быть отрицательной");
        }

        [TestMethod]
        public void BoolConversionOperator_ShouldReturnTrueForEquator()
        {
            // Arrange
            var equatorCoordinates = new GeoCoordinates(0.0, -75.0);
            var nonEquatorCoordinates = new GeoCoordinates(40.0, -75.0);

            // Act & Assert
            Assert.IsTrue((bool)equatorCoordinates, "Должно возвращаться true для координат на экваторе");
            Assert.IsFalse((bool)nonEquatorCoordinates, "Должно возвращаться false для неэкваториальных координат");
        }

        [TestMethod]
        public void StringConversionOperator_ShouldReturnCorrectString()
        {
            // Arrange
            var easternCoordinates = new GeoCoordinates(40.0, 75.0);
            var westernCoordinates = new GeoCoordinates(40.0, -75.0);
            var zeroMeridianCoordinates = new GeoCoordinates(40.0, 0.0);

            // Act & Assert
            Assert.AreEqual("Восточная долгота", (string)easternCoordinates, "Должно возвращаться 'Восточная долгота'");
            Assert.AreEqual("Западная долгота", (string)westernCoordinates, "Должно возвращаться 'Западная долгота'");
            Assert.AreEqual("Нулевой меридиан", (string)zeroMeridianCoordinates, "Должно возвращаться 'Нулевой меридиан'");
        }
        [TestMethod]
        public void EqualityOperator_ShouldReturnTrueForEqualLatitude()
        {
            // Arrange
            var location1 = new GeoCoordinates { Latitude = 40.0, Longitude = -75.0 };
            var location2 = new GeoCoordinates { Latitude = 40.0, Longitude = 120.0 }; // Различный меридиан

            // Act & Assert
            Assert.IsTrue(location1 == location2, "Должно возвращаться true для равных широт");
        }

        [TestMethod]
        public void InequalityOperator_ShouldReturnTrueForDifferentLongitude()
        {
            // Arrange
            var location1 = new GeoCoordinates { Latitude = 40.0, Longitude = -75.0 };
            var location2 = new GeoCoordinates { Latitude = 35.0, Longitude = -76.0 }; // Равный меридиан

            // Act & Assert
            Assert.IsTrue(location1 != location2, "Должно возвращаться true для различных меридианов");
        }

        [TestMethod]
        public void EqualsMethod_ShouldReturnTrueForEqualCoordinates()
        {
            // Arrange
            var location1 = new GeoCoordinates { Latitude = 40.0, Longitude = -75.0 };
            var location2 = new GeoCoordinates { Latitude = 40.0, Longitude = -75.0 };

            // Act & Assert
            Assert.IsTrue(location1.Equals(location2), "Метод Equals должен возвращать true для равных координат");
        }

        [TestMethod]
        public void EqualsMethod_ShouldReturnFalseForDifferentCoordinates()
        {
            // Arrange
            var location1 = new GeoCoordinates { Latitude = 40.0, Longitude = -75.0 };
            var location2 = new GeoCoordinates { Latitude = 35.0, Longitude = -75.0 };

            // Act & Assert
            Assert.IsFalse(location1.Equals(location2), "Метод Equals должен возвращать false для разных координат");
        }
    }
    [TestClass]
    public class GeoCoordinatesTestsArray
    {
        [TestMethod]
        public void DefaultConstructor_ShouldInitializeEmptyArray()
        {
            // Arrange & Act
            GeoCoordinatesArray geoCoordinatesArray = new GeoCoordinatesArray();

            // Assert
            Assert.AreEqual(0, geoCoordinatesArray.Length, "Длина массива должна быть равна 0");
        }

        [TestMethod]
        public void ParameterizedConstructor_ShouldInitializeArrayWithRandomCoordinates()
        {
            // Arrange
            var count = 5;
            var rnd = new Random();

            // Act
            var geoCoordinatesArray = new GeoCoordinatesArray(count, rnd);

            // Assert
            Assert.AreEqual(count, geoCoordinatesArray.Length, $"Длина массива должна быть равна {count}");

            for (int i = 0; i < count; i++)
            {
                Assert.IsTrue(geoCoordinatesArray[i].Latitude >= -90 && geoCoordinatesArray[i].Latitude < 90, "Широта должна быть в пределах [-90, 90)");
                Assert.IsTrue(geoCoordinatesArray[i].Longitude >= -180 && geoCoordinatesArray[i].Longitude < 180, "Долгота должна быть в пределах [-180, 180)");
            }
        }

        [TestMethod]
        public void CopyConstructor_ShouldCreateDeepCopyOfArray()
        {
            // Arrange
            var originalArray = new GeoCoordinatesArray(3, new Random());

            // Act
            var copiedArray = new GeoCoordinatesArray(originalArray);

            // Assert
            Assert.AreEqual(originalArray.Length, copiedArray.Length, "Длины массивов должны быть равны");
            for (int i = 0; i < originalArray.Length; i++)
            {
                Assert.AreNotSame(originalArray[i], copiedArray[i], "Элементы массива должны быть разными объектами");
                Assert.AreEqual(originalArray[i], copiedArray[i], "Элементы массива должны иметь одинаковые значения");
            }
        }
        [TestMethod]
        public void ParameterizedConstructor_ShouldFillArrayWithUserInput()
        {
            // Arrange
            var count = 2;
            var expectedCoordinates = new GeoCoordinates[]
            {
            new GeoCoordinates { Latitude = 40.0, Longitude = -75.0 },
            new GeoCoordinates { Latitude = 35.0, Longitude = -80.0 }
            };

            using (var consoleInput = new StringReader("40\n-75\n35\n-80\n"))
            {
                Console.SetIn(consoleInput);

                // Act
                var geoCoordinatesArray = new GeoCoordinatesArray((uint)count);

                // Assert
                Assert.AreEqual(count, geoCoordinatesArray.Length, $"Длина массива должна быть равна {count}");
                for (int i = 0; i < count; i++)
                {
                    Assert.AreEqual(expectedCoordinates[i], geoCoordinatesArray[i], "Элементы массива должны иметь ожидаемые значения");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_Get_WithInvalidIndex_ShouldThrowException()
        {
            // Arrange
            var geoCoordinatesArray = new GeoCoordinatesArray();

            // Act & Assert
            var invalidCoordinate = geoCoordinatesArray[1]; // Должен выбросить исключение IndexOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_Set_WithInvalidIndex_ShouldThrowException()
        {
            // Arrange
            var geoCoordinatesArray = new GeoCoordinatesArray();

            // Act & Assert
            geoCoordinatesArray[1] = new GeoCoordinates(); // Должен выбросить исключение IndexOutOfRangeException
        }
    }
}