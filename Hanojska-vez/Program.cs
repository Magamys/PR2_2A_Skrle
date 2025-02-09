namespace _03_Data_02_hanojska_vez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int discCount = 6;

            Puzzle p = new Puzzle(discCount);
            p.Solve();

            //    Stack<int> LeftPin = new Stack<int>();
            //    Stack<int> MiddlePin = new Stack<int>();
            //    Stack<int> RightPin = new Stack<int>();

            //    for (int i = discCount; i > 0; i--)
            //    {
            //        LeftPin.Push(i);
            //    }

            //    Render(LeftPin, MiddlePin, RightPin);
            //    Transfer(discCount, LeftPin, RightPin, MiddlePin);
            //    Render(LeftPin, MiddlePin, RightPin);


            //    //Move(LeftPin, RightPin);
            //    //Render(LeftPin, MiddlePin, RightPin);
            //    //Move(LeftPin, MiddlePin);
            //    //Render(LeftPin, MiddlePin, RightPin);
            //    //Move(RightPin, MiddlePin);
            //    //Render(LeftPin, MiddlePin, RightPin);
            //    //Move(LeftPin, RightPin);
            //    //Render(LeftPin, MiddlePin, RightPin);
            //}

            //static void Move(Stack<int> from, Stack<int> to)
            //{
            //    //je co brat?
            //    if (from.Count < 1)
            //        return;

            //    //jde to?
            //    if (to.Count > 0)
            //    {
            //        int fromDisc = from.Peek();
            //        int toDisc = to.Peek();
            //        if (toDisc < fromDisc)
            //            return;
            //    }
            //    //pohnout
            //    int disc = from.Pop();
            //    to.Push(disc);
            //}

            //static void Transfer(int howMany, Stack<int> from, Stack<int> to, Stack<int> tmp)
            //{
            //    if (howMany == 0)
            //        return;

            //    Transfer(howMany - 1, from, tmp, to);
            //    Move(from, to);
            //    Transfer(howMany - 1, tmp, to, from);

            //}

            //static void Render(Stack<int> left, Stack<int> middle, Stack<int> right)
            //{
            //    Console.WriteLine("----------");
            //    RenderPin(left);
            //    RenderPin(middle);
            //    RenderPin(right);
            //}

            //private static void RenderPin(Stack<int> pin)
            //{
            //    int[] cisla = pin.ToArray();
            //    cisla = cisla.Reverse().ToArray();
            //    Console.WriteLine(string.Join("|", cisla));
            //}
        }
    }

    class Puzzle
    {
        public int DiscCount { get; private set; }

        Stack<int> LeftPin = new Stack<int>();
        Stack<int> MiddlePin = new Stack<int>();
        Stack<int> RightPin = new Stack<int>();

        public Puzzle(int discCount)
        {
            DiscCount = discCount;
            for (int i = discCount; i > 0; i--)
            {
                LeftPin.Push(i);
            }
        }

        public void Solve()
        {
            Transfer(DiscCount, LeftPin, RightPin, MiddlePin);
        }

        void Move(Stack<int> from, Stack<int> to)
        {
            //je co brat?
            if (from.Count < 1)
                return;

            //jde to?
            if (to.Count > 0)
            {
                int fromDisc = from.Peek();
                int toDisc = to.Peek();
                if (toDisc < fromDisc)
                    return;
            }
            //pohnout
            int disc = from.Pop();
            to.Push(disc);
            Render();
        }

        void Transfer(int howMany, Stack<int> from, Stack<int> to, Stack<int> tmp)
        {
            if (howMany == 0)
                return;

            Transfer(howMany - 1, from, tmp, to);
            Move(from, to);
            System.Threading.Thread.Sleep(500);
            Transfer(howMany - 1, tmp, to, from);

        }

        void Render()
        {
            //Console.WriteLine("----------");
            Console.Clear();
            RenderPin(LeftPin);
            RenderPin(MiddlePin);
            RenderPin(RightPin);
        }

        void RenderPin(Stack<int> pin)
        {
            int[] cisla = pin.ToArray();
            cisla = cisla.Reverse().ToArray();
            Console.WriteLine(string.Join("|", cisla));
        }
    }
}