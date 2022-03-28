namespace UpstreamFeedWithPaket
{
    public class Class1
    {
        public double Foobar { get; }
        public int Foo { get; private set; }
        public string Bar { get; private set; }

        public Class1(double foobar)
        {
            Foobar = foobar;
        }

        public static Class1 Create(int i, string s)
        {
            return new Class1(1.0){Bar = "bar", Foo = 1};
        }

    }

    public class Class2
    {
        public int I { get; }
        public string S { get; private set; }

        public Class2(int i, string s)
        {
            I = i;
            S = s;
        }
    }
}
