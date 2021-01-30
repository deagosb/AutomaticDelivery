using System;
using System.Drawing;

namespace Domain
{
    /// <summary>
    /// Defines the <see cref="Dron" />.
    /// </summary>
    public class Dron
    {
        /// <summary>
        /// Defines the _point.
        /// </summary>
        private Point _point;

        /// <summary>
        /// Defines the _orientation.
        /// </summary>
        private Orientation _orientation;

        /// <summary>
        /// Gets or sets the Point.
        /// </summary>
        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        /// <summary>
        /// Gets or sets the Orientation.
        /// </summary>
        public Orientation Orientation
        {
            get { return _orientation; }
            set { _orientation = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dron"/> class.
        /// </summary>
        /// <param name="point">The point<see cref="Point"/>.</param>
        /// <param name="orientation">The orientation<see cref="Orientation"/>.</param>
        public Dron(Point point, Orientation orientation)
        {
            _point = point;
            _orientation = orientation;
        }

        /// <summary>
        /// The Run.
        /// </summary>
        /// <param name="instructions">The instructions<see cref="string"/>.</param>
        public void Run(string instructions)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction.ToString())
                {
                    case "A":
                        Move();
                        break;
                    case "I":
                        SetOrientation(Directions.Left);
                        break;
                    case "D":
                        SetOrientation(Directions.Right);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// The Move.
        /// </summary>
        public void Move()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _point.Y = _point.Y + 1;
                    break;
                case Orientation.South:
                    _point.Y = _point.Y - 1;
                    break;
                case Orientation.East:
                    _point.X = _point.X + 1;
                    break;
                case Orientation.West:
                    _point.X = _point.X - 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The SetOrientation.
        /// </summary>
        /// <param name="direction">The direction<see cref="Directions"/>.</param>
        public void SetOrientation(Directions direction)
        {
            var _orientation = direction switch
            {
                Directions.Right => TurnRight(),
                Directions.Left => TurnLeft(),
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        /// The TurnRight.
        /// </summary>
        /// <returns>The <see cref="Orientation"/>.</returns>
        private Orientation TurnRight()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _orientation = Orientation.East;
                    break;
                case Orientation.South:
                    _orientation = Orientation.West;
                    break;
                case Orientation.East:
                    _orientation = Orientation.South;
                    break;
                case Orientation.West:
                    _orientation = Orientation.North;
                    break;
                default:
                    break;
            }

            return _orientation;
        }

        /// <summary>
        /// The TurnLeft.
        /// </summary>
        /// <returns>The <see cref="Orientation"/>.</returns>
        private Orientation TurnLeft()
        {
            switch (_orientation)
            {
                case Orientation.North:
                    _orientation = Orientation.West;
                    break;
                case Orientation.South:
                    _orientation = Orientation.East;
                    break;
                case Orientation.East:
                    _orientation = Orientation.North;
                    break;
                case Orientation.West:
                    _orientation = Orientation.South;
                    break;
                default:
                    break;
            }

            return _orientation;
        }
    }
}
