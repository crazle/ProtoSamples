using System;
using System.Collections.Generic;

namespace SpdUniTradeServiceBase.OnInitialized
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var workbench = new Mainworkbench();
            Console.WriteLine("if cca");
            workbench.OnInitialized("CCA");
            Console.WriteLine("if MenuTree");
            workbench.OnInitialized("MenuTree");

            Console.WriteLine("if Auth");
            workbench.OnInitialized("Auth");
            Console.ReadLine();
        }
    }

    internal abstract class SpdTradeServiceBase
    {
        private readonly Dictionary<string, Action> _lookup = new Dictionary<string, Action>();

        public SpdTradeServiceBase()
        {
            _lookup.Add("CCA", InvokeByCCA);
            _lookup.Add("MenuTree", InvokeByMenu);
            _lookup.Add("Auth", InvokeByAuth);
        }

        private void InvokeByAuth()
        {
            InvokeByElse();
        }

        public virtual void InvokeByCCA()
        {
            InvokeByElse();
        }

        public virtual void InvokeByMenu()
        {
            InvokeByElse();
        }

        public virtual void InvokeByElse()
        {
            Console.WriteLine("Else");
        }

        public virtual void OnInitialized(string openpagestyle)
        {
            Action action;
            if (_lookup.TryGetValue(openpagestyle, out action))
            {
                action.Invoke();
            }
        }
    }

    internal class Mainworkbench : SpdTradeServiceBase
    {
        public override void InvokeByCCA()
        {
            Console.WriteLine("Invoke by cca");
        }

        public override void InvokeByElse()
        {
            Console.WriteLine("Else...");
        }
    }
}