using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4Tests
{
    public class Tests
    {
        public List<Int32> Values { get; private set; }
        public List<int> CalledNumbers { get; private set; }
        internal List<Board> Boards { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.SetupInput();
        }

        private void SetupInput()
        {
            var readings = File.ReadAllText("../../../Input.txt")
                               .Split(Environment.NewLine)
                               .ToList();
            this.CalledNumbers = readings[0].Split(",").Select(number => Int32.Parse(number)).ToList();
            this.Boards = this.ReadBoards(readings.Skip(2).ToList());
        }

        private List<Board> ReadBoards(List<string> readings)
        {
            var boards = new List<Board>();
            while (readings.Any())
            {
                var board = new Board(readings);
                boards.Add(board);
            }
            return boards;
        }

        [Test]
        public void Part1()
        {
            this.CalledNumbers.ForEach(calledNumber =>
            {
                var winningBoard = this.Boards.FirstOrDefault(board => board.WinsWith(calledNumber));
                if (!(winningBoard is null))
                {
                    var sumOfUnmarked = (int)winningBoard.SumOfUnmarkedNumbers();
                    var answer = sumOfUnmarked * calledNumber;
                    Assert.IsTrue(answer == 39984);
                }
            });
            Assert.Pass();
        }
    }
}