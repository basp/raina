namespace Raina.Cmd
{
    using System;
    using PowerArgs;
    
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    class Program
    {
        [HelpHook]
        public static bool Help { get; set; }

        public static void Scan() =>
            throw new NotImplementedException();

        static void Main(string[] args)
        {
            Args.InvokeAction<Program>(args);
        }
    }
}
