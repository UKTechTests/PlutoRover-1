using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRoverAPI
{

    public class Core
    {

        public Core()
        {
            _roverX = 0;
            _roverY = 0;
            _roverDirection = DirectionEnum.N;

            _obstacles = new bool[_maxX, _maxY];

            _obstacles[2, 1] = true;

            _obstaclePosition = string.Empty;
        }

        private const int _maxX = 100;

        private const int _maxY = 100;

        private bool[,] _obstacles;

        private string _obstaclePosition;

        private enum DirectionEnum
        {
            N,
            E,
            S,
            W
        }

        private int _roverX;

        private int _roverY;

        private DirectionEnum _roverDirection;

        public String Move(string command)
        {
            _obstaclePosition = string.Empty;

            foreach (Char singleCommand in command)
            {
                if (string.IsNullOrEmpty(_obstaclePosition))
                {
                    ProcessCommand(singleCommand);
                }
            }


            if (string.IsNullOrEmpty(_obstaclePosition))
                return "OK";
            else
                return _obstaclePosition;
        }

        private bool IsObstacle(int x, int y)
        {
            if (_obstacles[x, y])
                _obstaclePosition = string.Format("Obstacle at {0}, {1}", x, y);

            return _obstacles[x, y];
        }

        private void ProcessCommand(Char singleCommand)
        {

            switch (singleCommand)
            {
                case 'F':
                    {

                        if (_roverDirection == DirectionEnum.N)
                        {
                            if (!IsObstacle(_roverX, WrapY(_roverY + 1)))
                                _roverY++;
                        }

                        if (_roverDirection == DirectionEnum.S)
                            if (!IsObstacle(_roverX, WrapY(_roverY - 1)))
                                _roverY--;

                        if (_roverDirection == DirectionEnum.E)
                            if (!IsObstacle(WrapX(_roverX + 1), _roverY))
                                _roverX++;

                        if (_roverDirection == DirectionEnum.W)
                            if (!IsObstacle(WrapX(_roverX - 1), _roverY))
                                _roverX--;

                        break;
                    }
                case 'B':
                    {

                        if (_roverDirection == DirectionEnum.N)
                            if (!IsObstacle(_roverX, WrapY(_roverY - 1)))
                                _roverY--;

                        if (_roverDirection == DirectionEnum.S)
                            if (!IsObstacle(_roverX, WrapY(_roverY + 1)))
                                _roverY++;

                        if (_roverDirection == DirectionEnum.E)
                            if (!IsObstacle(WrapX(_roverX - 1), _roverY))
                                _roverX--;

                        if (_roverDirection == DirectionEnum.W)
                            if (!IsObstacle(WrapX(_roverX + 1), _roverY))
                                _roverX++;

                        break;
                    }
                case 'R':
                    {

                        if (_roverDirection == DirectionEnum.N)
                            _roverDirection = DirectionEnum.E;

                        else if (_roverDirection == DirectionEnum.S)
                            _roverDirection = DirectionEnum.W;

                        else if (_roverDirection == DirectionEnum.E)
                            _roverDirection = DirectionEnum.S;

                        else if (_roverDirection == DirectionEnum.W)
                            _roverDirection = DirectionEnum.N;

                        break;
                    }
                case 'L':
                    {

                        if (_roverDirection == DirectionEnum.N)
                            _roverDirection = DirectionEnum.W;

                        else if (_roverDirection == DirectionEnum.S)
                            _roverDirection = DirectionEnum.E;

                        else if (_roverDirection == DirectionEnum.E)
                            _roverDirection = DirectionEnum.N;

                        else if (_roverDirection == DirectionEnum.W)
                            _roverDirection = DirectionEnum.S;

                        break;
                    }
            }


            _roverX = WrapX(_roverX);

            _roverY = WrapY(_roverY);

        }

        private int WrapX(int x)
        {
            if (x >= _maxX)
                return 0;
            else if (x < 0)
                return _maxX - 1;
            else
                return x;
        }

        private int WrapY(int y)
        {
            if (y >= _maxY)
                return 0;
            else if (y < 0)
                return _maxY - 1;
            else
                return y;
        }

        public string GetPosition()
        {

            return string.Format("{0}, {1}, {2}",
                                 _roverX,
                                 _roverY,
                                 _roverDirection);

        }

    }

}
