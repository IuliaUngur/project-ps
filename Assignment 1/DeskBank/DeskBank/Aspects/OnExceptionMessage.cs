using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBank.Aspects
{
    [Serializable]
    public class OnExceptionMessage : OnExceptionAspect 
    {
        private Dictionary<Type, string> messages;

        public OnExceptionMessage(Type[] exceptions, string[] messages)
        {
            // Convert the two arrays in a associative array (dictionary)
            this.messages = exceptions.Zip(messages, (s, i) => new { s, i }).ToDictionary(item => item.s, item => item.i);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            bool wasCatched = false;
            foreach (var message in messages)
            {
                if (args.Exception.GetType() == message.Key)
                {
                    wasCatched = true;
                    System.Windows.Forms.MessageBox.Show(message.Value);
                }
            }
            if(wasCatched)
                args.FlowBehavior = FlowBehavior.Return;
        }
    }

}
