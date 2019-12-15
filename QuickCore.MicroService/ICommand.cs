using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.MicroService
{
    public interface ICommand
    {
        int Run();
    }
    public interface ICommand<TOption>:ICommand
    { 
        TOption Option { get; }
    }
}
