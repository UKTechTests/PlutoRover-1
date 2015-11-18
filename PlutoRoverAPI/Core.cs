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
        }

        private const int _maxX = 100;

        private const int _maxY = 100;

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

        public void Move(string command)
        {

            foreach (Char singleCommand in command)
            {
                ProcessCommand(singleCommand);
            }

        }

        private void ProcessCommand(Char singleCommand)
        {
            switch (singleCommand)
            {
                case 'F':
                    {

                        if (_roverDirection == DirectionEnum.N)
                            _roverY++;

                        if (_roverDirection == DirectionEnum.S)
                            _roverY--;

                        if (_roverDirection == DirectionEnum.E)
                            _roverX++;

                        if (_roverDirection == DirectionEnum.W)
                            _roverX--;

                        break;
                    }
                case 'B':
                    {

                        if (_roverDirection == DirectionEnum.N)
                            _roverY--;

                        if (_roverDirection == DirectionEnum.S)
                            _roverY++;

                        if (_roverDirection == DirectionEnum.E)
                            _roverX--;

                        if (_roverDirection == DirectionEnum.W)
                            _roverX++;

                        break;
                    }
            }
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
