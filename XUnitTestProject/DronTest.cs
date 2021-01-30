using Domain;
using System.Drawing;
using Xunit;

namespace XUnitTestProject
{
    /// <summary>
    /// Defines the <see cref="DronTest" />.
    /// </summary>
    public class DronTest
    {
        /// <summary>
        /// The Dron_Run_Succesfull.
        /// </summary>
        [Fact]
        public void Dron_Run_Succesfull()
        {
            string line = "DDDDDDD";
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.Run(line);
            Assert.Equal(new Point(0, 0), dron.Point);
            Assert.Equal(Orientation.West, dron.Orientation);
        }

        /// <summary>
        /// The Dron_Run_Failure.
        /// </summary>
        [Fact]
        public void Dron_Run_Failure()
        {
            string line = "IIIIIII";
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.Run(line);
            Assert.Equal(new Point(0, 0), dron.Point);
            Assert.NotEqual(Orientation.West, dron.Orientation);
        }

        /// <summary>
        /// The Dron_Run_Succesfull_Position_OK.
        /// </summary>
        [Fact]
        public void Dron_Run_Succesfull_Position_OK()
        {
            string line = "DDDAIAD";
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.Run(line);
            Assert.Equal(new Point(-1, -1), dron.Point);
            Assert.Equal(Orientation.West, dron.Orientation);
        }

        /// <summary>
        /// The Dron_Run_Succesfull_Position_Fail.
        /// </summary>
        [Fact]
        public void Dron_Run_Succesfull_Position_Fail()
        {
            string line = "AAAAIAA";
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.Run(line);
            Assert.NotEqual(new Point(0, 0), dron.Point);
            Assert.NotEqual(Orientation.South, dron.Orientation);
        }

        /// <summary>
        /// The Dron_Move_Succesfull.
        /// </summary>
        [Fact]
        public void Dron_Move_Succesfull()
        {
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.Move();
            Assert.Equal(new Point(0, 1), dron.Point);
            Assert.Equal(Orientation.North, dron.Orientation);
        }

        /// <summary>
        /// The Dron_Move_Failure.
        /// </summary>
        [Fact]
        public void Dron_Move_Failure()
        {
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.Move();
            Assert.NotEqual(new Point(1, 0), dron.Point);
            Assert.Equal(Orientation.North, dron.Orientation);
        }

        /// <summary>
        /// The Dron_SetOrientation_Succesfull.
        /// </summary>
        [Fact]
        public void Dron_SetOrientation_Succesfull()
        {
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.SetOrientation(Directions.Left);
            Assert.Equal(new Point(0, 0), dron.Point);
            Assert.Equal(Orientation.West, dron.Orientation);
        }

        /// <summary>
        /// The Dron_SetOrientation_Failure.
        /// </summary>
        [Fact]
        public void Dron_SetOrientation_Failure()
        {
            Dron dron = new Dron(new Point(0, 0), Orientation.North);
            dron.SetOrientation(Directions.Right);
            Assert.Equal(new Point(0, 0), dron.Point);
            Assert.NotEqual(Orientation.West, dron.Orientation);
        }
    }
}
