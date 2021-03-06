﻿using System.Collections.Generic;
using System.Threading;
using EscapeMines.Game.ReadModels;

namespace EscapeMines.Game.Models
{
    public class Game
    {
        private Point _turtleStartPoint;
        private FileReader _fileReader;
        private AdvancedSettingsModel _advancedSettings;
        private SimpleSettingsModel _simpleSettings;
        private Grid _grid;
        private Observer _observer;

        #region Factory method

        /// <summary>
        /// Factory method implementation 
        /// </summary>
        private Game()
        {
            _fileReader = FileReader.Instance();
            _advancedSettings = _fileReader.GetAdvanceSettings();
            _simpleSettings = _fileReader.GetSimpleSettings();
            _turtleStartPoint = _advancedSettings.StartPoint;
            _grid = new Grid(_advancedSettings.Size.Y, _advancedSettings.Size.X);
            _observer = new Observer(_grid);
            Initialize();
        }

        public static Game CreateNewGame()
        {
            return new Game();
        } 
        #endregion


        /// <summary>
        /// Start game from start position
        /// </summary>
        public void Start()
        {
            var moves = _simpleSettings.Moves;
            var turtle = _grid[_turtleStartPoint] as EscapeMines.Game.Models.Turtle;
            if (System.Enum.TryParse<Directions>(_advancedSettings.Direction, out var dir)) turtle.Direction = dir;
            Printer.Print(turtle); //tirar
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == "r") turtle.Rotate();
                else if (moves[i] == "m") turtle.Move();
                Thread.Sleep(1000);
                var situation = _observer.Observe(turtle.Position);
                if (situation == State.IsDead)
                {
                    Printer.Print(Printer.Dead);
                    break;
                }
                else if (situation == State.IsExit)
                {
                    Printer.Print(Printer.Success);
                    break;
                }
                else if (situation == State.IsOutOfBounds)
                {
                    Printer.Print(Printer.Out);
                }
            }
        }

        private void Initialize()
        {
            SetTurtle(_turtleStartPoint);
            SetExit(_advancedSettings.ExitPoint);
            SetMines(_advancedSettings.MinePoints);
        }


        /// <summary>
        /// setting mines in the grid
        /// </summary>
        /// <param name="mines"></param>
        private void SetMines(List<Point> mines)
        {
            foreach (var minePosition in mines)
            {
                try
                {
                    _grid[minePosition] = new Mine() { Position = minePosition };
                }
                catch
                {/*ignore*/ }
            }
        }

        /// <summary>
        /// setting exit point in the grid
        /// </summary>
        /// <param name="exitPosition"></param>
        private void SetExit(Point exitPosition)
        {
            try
            {
                _grid[exitPosition] = new Exit() { Position = exitPosition };
            }
            catch
            {/*ignore*/}
        }


        /// <summary>
        /// setting turtle in the grid
        /// </summary>
        /// <param name="turtlePosition"></param>
        private void SetTurtle(Point turtlePosition)
        {
            try
            {
                _grid[turtlePosition] = EscapeMines.Game.Models.Turtle.Instance(turtlePosition);
            }
            catch
            {/*ignore*/}
        }
    }
}
