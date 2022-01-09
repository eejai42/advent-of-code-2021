using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14Tests
{
    internal class Parser
    {
        public List<Symbol> Symbols { get; }
        public char LastExpected { get; private set; }
        public char LastFound { get; private set; }
        public char UnexpectedChar { get; private set; }

        public Parser()
        {
            this.Symbols = new List<Symbol>(new Symbol[]
                {
                    new Symbol() { Opening = '(', Closing = ')', Points = 3, ClosingPoints = 1 },
                    new Symbol() { Opening = '[', Closing = ']', Points = 57, ClosingPoints = 2 },
                    new Symbol() { Opening = '{', Closing = '}', Points = 1197, ClosingPoints = 3 },
                    new Symbol() { Opening = '<', Closing = '>', Points = 25137, ClosingPoints = 4 }
                });
        }

        internal bool IsInvalid(string message)
        {
            (var unexpectedChar, var stack) = this.Parse(message);
            return unexpectedChar != '\0';
        }

        private (char, Stack<char>) Parse(string message)
        {
            var message2 = message;
            var stack = new Stack<Char>();
            this.UnexpectedChar = '\0';
            foreach (char chr in message)
            {
                this.LastFound = chr;
                if (this.IsOpening(chr)) stack.Push(chr);
                else if (this.IsClosing(chr))
                {
                    this.LastExpected = this.GetClosing(stack.Pop());
                    if (this.LastExpected != chr) 
                    {
                        this.UnexpectedChar = this.LastFound;
                        break;
                    }
                }
                else
                {
                    this.UnexpectedChar = this.LastFound;
                    break;
                }
                object o = 1;
            };
            return (this.UnexpectedChar, stack);            
        }

        internal bool IsIncomplete(string message)
        {
            (var unexpectedChar, var stack) = this.Parse(message);
            return unexpectedChar == '\0';
        }

        internal long CompleteScore(string message)
        {
            (var unexpectedChar, var stack) = this.Parse(message);
            long closingPoints = 0;
            while (stack.Count > 0)
            {
                char next = stack.Pop();
                var symbol = this.Symbols.First(symbol => symbol.Opening == next);
                closingPoints = (closingPoints * 5) + symbol.ClosingPoints;
            }
            if (closingPoints < 0)
            {
                object o = 1;
            }
            return closingPoints;
        }

        private char GetClosing(char openingChar)
        {
            var symbol = this.Symbols.First(symbol => symbol.Opening == openingChar);
            return symbol.Closing;
        }

        private bool IsClosing(char chr)
        {
            return this.Symbols.Any(any => any.Closing == chr);
        }

        private bool IsOpening(char chr)
        {
            return this.Symbols.Any(any => any.Opening == chr);
        }

        internal int GetErrorScore(string message)
        {
            (var unexpectedChar, var stack) = this.Parse(message);
            var symbol = this.Symbols.First(symbol => symbol.Closing == unexpectedChar);
            return symbol.Points;
        }
    }
}