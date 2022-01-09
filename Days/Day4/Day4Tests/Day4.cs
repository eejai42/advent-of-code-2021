using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            bool won = false;
            this.CalledNumbers.ForEach(calledNumber =>
            {
                if (!won)
                {
                    this.Boards.ForEach(board => board.MarkNumber(calledNumber));
                    var winningBoard = this.Boards.FirstOrDefault(board => board.HasBingo());
                    if (!(winningBoard is null))
                    {
                        var sumOfUnmarked = (int)winningBoard.SumOfUnmarkedNumbers();
                        var answer = sumOfUnmarked * calledNumber;
                        Assert.IsTrue(answer == 39984);
                        won = true;
                    }
                }
            });
            Assert.IsTrue(won);
        }

        [Test]
        public void Part2()
        {
            var boards = this.Boards.ToList();
            var index = 0;
            this.CalledNumbers.ForEach(calledNumber =>
            {
                boards.ForEach(board => board.MarkNumber(calledNumber));
                var winningBoards = boards.Where(board => board.HasBingo()).ToList();

                this.SaveBoards("in_play", boards, index++, calledNumber);
                if (winningBoards.Any())
                {
                    this.SaveBoards("winning", winningBoards, index, calledNumber);
                }
                winningBoards.ForEach(winningBoard =>
                {
                    boards.Remove(winningBoard);
                    if (boards.Count == 0)
                    {
                        var sumOfUnmarked = winningBoard.SumOfUnmarkedNumbers();
                        var answer = sumOfUnmarked * calledNumber;
                        Assert.IsTrue(answer == 8468);
                    }
                });
            });

            Assert.IsTrue(boards.Count == 1);
        }

        private void SaveBoards(string name, List<Board> boards, int index, int calledNumber)
        {
            var sb = new StringBuilder();
            String fileName = $"../../../{name}_{String.Format("{0:0000}", index)}_{calledNumber}.txt";
            boards.ForEach(board => sb.AppendLine(board.ToString()));
            File.WriteAllText(fileName, sb.ToString());
        }
    }
}