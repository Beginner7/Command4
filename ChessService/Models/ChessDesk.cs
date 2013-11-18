using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessService.Models
{
    public class ChessDesk
    {
        public enum Figure
        {
            pawn,
            rook,
            knight,
            bishop,
            queen,
            king
        }  // possible values of figure from 0 (pawn) to 5 (king)
        public struct Cell
        {
            public bool figureHave;
            public int figureType;
            public bool figureColor;
        } // figureHave - having in the cell; figureType - type of figure; color - color figure;
        public static bool GameUserColor = true; // if true, move the white player. else - black player
        public static int CellToInt(string cell)
        {
            char letter = cell[0];                       // get letter from cell (ex. B2)
            letter = System.Char.ToUpper(letter);        // raise an uppercase letter, because someone can break the system

            int y, x = Convert.ToInt32(cell[1]) - 48;    // convert number from char to int

            switch (letter)                              // letter - second class of value, number - first class
            {
                case 'A': { y = 0; break; }
                case 'B': { y = 1; break; }
                case 'C': { y = 2; break; }
                case 'D': { y = 3; break; }
                case 'E': { y = 4; break; }
                case 'F': { y = 5; break; }
                case 'G': { y = 6; break; }
                case 'H': { y = 7; break; }
                default: { y = 0; break; }
            }
            y = y * 8 + --x;  // --x, for desk from 0 to 63
            return y;
        }  // Convert cell from A1 to H8 in number from 0 to 63.

        public static Cell[] SetInitialStateDesk()
        {
            Cell[] Desk = new Cell[64];

            for (int i = 0; i < 64; i++)
            {
                if ((i >= 0 && i < 16) || (i > 47 && i < 64)) Desk[i].figureHave = true;
                else Desk[i].figureHave = false;

                if (i >= 0 && i < 16) Desk[i].figureColor = true;      // color: white - black (true, false)
                else if (i > 47 && i < 64) Desk[i].figureColor = false;
                else Desk[i].figureColor = false;

                if (i == 0 || i == 7 || i == 56 || i == 63) Desk[i].figureType = (int)Figure.rook; // set rook
                else if (i == 1 || i == 6 || i == 57 || i == 62) Desk[i].figureType = (int)Figure.knight;  // set knight
                else if (i == 2 || i == 5 || i == 58 || i == 61) Desk[i].figureType = (int)Figure.bishop; // set bishop
                else if (i == 3 || i == 59) Desk[i].figureType = (int)Figure.king; // set king
                else if (i == 4 || i == 60) Desk[i].figureType = (int)Figure.queen; // set queen
                else if ((i > 7 && i < 16) || (i > 47 && i < 56)) Desk[i].figureType = (int)Figure.pawn; // set pawn
                else Desk[i].figureType = 0;
            }
            return Desk;
        } // setting initial state of desk

        public static bool CheckPawnBeginCell(int kd)
        {
            if (GameUserColor)
            {
                if (kd >= 8 && kd <= 15) return true;
                else return false;
            }
            else
            {
                if (kd >= 48 && kd <= 55) return true;
                else return false;
            }
        } // checking: pawn in the initial cell or not

        public static bool CheckFreeCell(Cell cell)
        {
            if (cell.figureHave == true)
            {
                if (cell.figureColor!= GameUserColor) return true;
                else return false;
            }
            else return true;
        }   // checking cell: if cell free or in cell figure of opponent - return true

        // Checks moves different figures. kd - cell before move, kp - cell after move (from 0 to 63)
        public static bool CheckMovePawn(int kd, int kp, Cell[] Desk)
        {
            if (GameUserColor)                              // move of white player
            {
                if (CheckPawnBeginCell(kd) == true)          // if pawn in initial cell
                {
                    if (kp == kd + 16)
                    {
                        if (Desk[kd + 8].figureHave == true) return false;// if a player wants to go into two cells forward but someone standing between cells - false
                        else return true;
                    }
                    else if (kp == kd + 8) return true;
                    else return false;
                }
                else if (kp == kd + 8) return true;
                else return false;
            }
            else
            {
                if (CheckPawnBeginCell(kd) == true)               // if pawn in initial cell
                {
                    if (kp == kd - 16)
                    {
                        if (Desk[kd - 8].figureHave == true) return false;
                        else return true;
                    }
                    else if (kp == kd - 8) return true;
                    else return false;
                }
                else if (kp == kd - 8) return true;
                else return false;
            }
        } // checking move pawn
        public static bool CheckMoveRook(int kd, int kp, Cell[] Desk)
        {
            if (kp % 8 == kd % 8)
            {
                // check whether there is between the cells kd and kp other figures. if yes - fall into false
                if (kd < kp) { for (int i = kd + 8; i < kp; i += 8) { if (Desk[i].figureHave == true) return false; } return true; }
                else { for (int i = kd - 8; i > kp; i -= 8) { if (Desk[i].figureHave == true) return false; } return true; }
            }
            else if (kp / 8 == kd / 8)
            {
                if (kd < kp) { for (int i = ++kd; i < kp; i++) { if (Desk[i].figureHave == true) return false; } return true; }
                else { for (int i = --kd; i > kp; i--) { if (Desk[i].figureHave == true) return false; } return true; }
            }
            else return false;
        } // checking move rook
        public static bool CheckMoveKnight(int kd, int kp, Cell[] Desk)
        {
            if ((kp == kd - 17) || (kp == kd - 15) || (kp == kd - 10) || (kp == kd - 6) || (kp == kd + 17) || (kp == kd + 15) || (kp == kd + 10) || (kp == kd + 6))
            {
                if ((Desk[kd].figureHave == true) && (GameUserColor != Desk[kd].figureColor)) return true;
                else return false;
            }
            else return false;
        } // checking move knight
        public static bool CheckMoveBishop(int kd, int kp, Cell[] Desk)
        {
            if (kp % 7 == kd % 7)
            {
                // check whether there is between the cells kd and kp other figures. if yes - fall into false
                if (kd < kp) { for (int i = kd + 7; i < kp; i += 7) { if (Desk[i].figureHave == true) return false; } return true; }
                else { for (int i = kd - 7; i > kp; i -= 7) { if (Desk[i].figureHave == true) return false; } return true; }
            }
            else if (kp % 9 == kd % 9)
            {
                if (kd < kp) { for (int i = kd + 9; i < kp; i += 9) { if (Desk[i].figureHave == true) return false; } return true; }
                else { for (int i = kd - 9; i > kp; i -= 9) { if (Desk[i].figureHave == true) return false; } return true; }
            }
            else return false;
        } // checking move bishop
        public static bool CheckMoveQueen(int kd, int kp, Cell[] Desk)
        {
            if (CheckMoveRook(kd, kp, Desk) == true || CheckMoveBishop(kd, kp, Desk) == true) return true;
            else return false;
        } // checking move queen
        public static bool CheckMoveKing(int kd, int kp, Cell[] Desk)
        {
            if ((kp == kd - 9) || (kp == kd - 8) || (kp == kd - 7) || (kp == kd - 1) || (kp == kd + 1) || (kp == kd + 7) || (kp == kd + 8) || (kp == kd + 9)) return true;
            else return false;
        } // checking move king

        public static bool CheckMove(int figure, int cellBefore, int cellAfter, Cell[] Desk)
        {
            if (CheckFreeCell(Desk[cellAfter]) == true)
            {
                if (GameUserColor == Desk[cellBefore].figureColor)  // if the player does take not their figure - false
                {
                    switch (figure)
                    {
                        case (int)Figure.pawn: { return CheckMovePawn(cellBefore, cellAfter, Desk); }
                        case (int)Figure.rook: { return CheckMoveRook(cellBefore, cellAfter, Desk); }
                        case (int)Figure.knight: { return CheckMoveKnight(cellBefore, cellAfter, Desk); }
                        case (int)Figure.bishop: { return CheckMoveBishop(cellBefore, cellAfter, Desk); }
                        case (int)Figure.queen: { return CheckMoveQueen(cellBefore, cellAfter, Desk); }
                        case (int)Figure.king: { return CheckMoveKing(cellBefore, cellAfter, Desk); }
                        default: return false;
                    }
                }
                else return false;
            }
            else return false;
        }  // the main function of checking move, she started all other checkings

        static void DoMove(int kd, int kp, Cell[] Desk)
        {
            Desk[kp].figureType = Desk[kd].figureType;
            Desk[kp].figureColor = Desk[kd].figureColor;
            Desk[kp].figureHave = Desk[kd].figureHave;

            Desk[kd].figureHave = false;
            Desk[kd].figureColor = false;
            Desk[kd].figureType = 0;

            if (GameUserColor) GameUserColor = false; // switch color of current player
            else GameUserColor = true;
        } // do move
    }
}