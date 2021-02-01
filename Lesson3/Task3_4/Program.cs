using System;
using System.Collections;

namespace Task3_4
{
    class Program
    {
        static bool CanPlaceShip(int ShipSize, ref ArrayList Fields, bool isVert, string StartPoint) {
            bool RetVal = false;
            int X = 0;
            int Y = 0;
            ParceCoordinates(ref X, ref Y, StartPoint);

            int CurX = X;
            int CurY = Y;

            for (int i = 0; i < ShipSize; i++) {
                if (isVert)
                {
                    CurY = Y + i;
                }
                else 
                {
                    CurX = X + i;
                }
                RetVal = Fields.Contains($"{CurX},{CurY}");
                if (!RetVal)
                    return (RetVal);
            }
            return (RetVal);
        }
        static void RemoveUsedFields(int ShipSize, ref ArrayList Fields, bool isVert, string StartPoint) {
            int X = 0;
            int Y = 0;
            ParceCoordinates(ref X, ref Y, StartPoint);

            //Начать с прилегающей точки, если не у границы
            int CurX = X; 
            int CurY = Y; 
            if (isVert)
            {
                if (Y - 1 >= 0)
                {
                    Y = Y - 1;
                    ShipSize += 1;
                }
            }
            else 
            {
                if (X - 1 >= 0) 
                {
                    X = X - 1;
                    ShipSize += 1;
                }
            }

            //Уберем поля занятые кораблем и окружением
            for (int i = 0; i < ShipSize + 1; i++) {
                if (isVert)
                {
                    CurY = Y + i;
                    Fields.Remove($"{CurX - 1},{CurY}");
                    Fields.Remove($"{CurX + 1},{CurY}");
                }
                else 
                {
                    CurX = X + i;
                    Fields.Remove($"{CurX},{CurY - 1}");
                    Fields.Remove($"{CurX},{CurY + 1}");
                }
                Fields.Remove($"{CurX},{CurY}");
            }

        }
        static void PlaceShip(int ShipSize, ref char[,] BattleField, bool isVert, string StartPoint) {
            int X = 0;
            int Y = 0;
            ParceCoordinates(ref X, ref Y, StartPoint);

            int CurX = X;
            int CurY = Y;

            for (int i = 0; i < ShipSize; i++) {
                if (isVert)
                {
                    CurY = Y + i;
                }
                else 
                {
                    CurX = X + i;
                }
                BattleField[CurX, CurY] = 'X';
            }
        }
        static void ParceCoordinates(ref int X, ref int Y, string Coord) {
            string[] tmpStr = Coord.Split(',');
            X = int.Parse(tmpStr[0]);
            Y = int.Parse(tmpStr[1]);
        }
        static void Main(string[] args)
        {
            char[,] BattleField = new char[10, 10];
            ArrayList Fields = new ArrayList();

            //Создадим пустое поле и список координат
            for (int i = 0; i < BattleField.GetLength(0); i++) {
                for (int j = 0; j < BattleField.GetLength(1); j++) {
                    BattleField[i, j] = 'O';
                    Fields.Add($"{ i },{ j }");
                }                    
            }
            //Создадим список кораблей (размер, кол-во)
            int[,] Ships = new int[4, 2];
            {
                int j = 4;
                for (int i = 0; i < 4; i++)
                {
                    Ships[i, 0] = j;
                    Ships[i, 1] = i + 1;
                    j--;
                }
            }

            //Разместим корабли на поле
            for (int i = 0; i < Ships.GetLength(0); i++) {
                bool ShipPlaced = false;
                Random rand = new Random();

                for (int j = 0; j < Ships[i, 1]; j++)
                {
                    ShipPlaced = false;
                    while (!ShipPlaced)
                    {
                        bool isVert = rand.Next(100) % 2 == 1;
                        string StartPoint = (string)Fields[rand.Next(0, Fields.Count - 1)];
                        if (CanPlaceShip(Ships[i, 0], ref Fields, isVert, StartPoint))
                        {
                            PlaceShip(Ships[i, 0], ref BattleField, isVert, StartPoint);
                            RemoveUsedFields(Ships[i, 0], ref Fields, isVert, StartPoint);
                            ShipPlaced = true;
                        }
                    }
                }
            }

            //Нарисуем итоговую доску
            for (int j = 0; j < BattleField.GetLength(1); j++) {
                for (int i = 0; i < BattleField.GetLength(0); i++) {
                    if (BattleField[i, j] == 'X')
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{BattleField[i, j]} ");
                    Console.ResetColor();
                }
                Console.Write('\n');
            }
        }
    }
}
