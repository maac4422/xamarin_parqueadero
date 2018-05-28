using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Test.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void CreateCar()
        {
            //Arrange
            app.Tap(x => x.Marked("Carros"));
            app.Tap("ButtonAddCar");
			app.WaitForElement(x => x.Marked("EntryLicencePlate"));
            app.EnterText("EntryLicencePlate", "XXX123");

            //Act
            app.Tap("CheckInVehicleButton");

            //Assert
            app.WaitForElement("Correcto");
            var alert = app.Query("Correcto");
            Assert.NotNull(alert);
        }

        [Test]
        public void CreateMotorcycle()
        {
            //Arrange
            app.Tap(x => x.Marked("Motos"));
            app.Tap("ButtonAddMotorcycle");
            app.WaitForElement(x => x.Marked("EntryLicencePlate"));
            app.EnterText("EntryLicencePlate", "ZZZ123");
            app.EnterText("EntryDisplacement", "200");

            //Act
            app.Tap("CheckInVehicleButton");

            //Assert
            app.WaitForElement("Correcto");
            var alert = app.Query("Correcto");
            Assert.NotNull(alert);
        }

        [Test]
        public void CheckOutCarFromVehicleListPage()
        {
            //Arrange
            app.Tap(x => x.Marked("Carros"));
            Thread.Sleep(1000);

            //Act
            app.Tap("CheckOutVehicleButton");

            //Assert
            app.WaitForElement("Retiro Correcto");
            var alert = app.Query("Retiro Correcto");
            Assert.NotNull(alert);
        }

        [Test]
        public void CheckOutMotorcycleFromVehicleListPage()
        {
            //Arrange
            app.Tap(x => x.Marked("Motos"));
            Thread.Sleep(1000);

            //Act
            app.Tap("CheckOutVehicleButton");

            //Assert
            app.WaitForElement("Retiro Correcto");
            var alert = app.Query("Retiro Correcto");
            Assert.NotNull(alert);
        }

        [Test]
        public void CheckOutMotorcycleFromVehiclePage()
        {
            //Arrange
            app.Tap(x => x.Marked("Motos"));
            Thread.Sleep(1000);

            //Act
            app.Tap(x => x.Marked("Placa: "));
            app.WaitForElement("CheckOutVehicleButton");
            app.Tap("CheckOutVehicleButton");

            //Assert
            app.WaitForElement("Correcto");
            var alert = app.Query("Correcto");
            Assert.NotNull(alert);
            
        }

        [Test]
        public void CheckOutCarFromVehiclePage()
        {
            //Arrange
            app.Tap(x => x.Marked("Carros"));
            Thread.Sleep(1000);

            //Act
            app.Tap(x => x.Marked("Placa: "));
            app.WaitForElement("CheckOutVehicleButton");
            app.Tap("CheckOutVehicleButton");

            //Assert
            app.WaitForElement("Correcto");
            var alert = app.Query("Correcto");
            Assert.NotNull(alert);

        }

    }
}
