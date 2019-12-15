using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.MicroService.Commands
{
    public class DeployCommand : ICommand<DeployOption>
    {
        public DeployCommand(DeployOption option)
        {
            this.Option = option;
        }
        public DeployOption Option { get; private set; }

        public int Run()
        {
            return 0;
        }
    }
}
