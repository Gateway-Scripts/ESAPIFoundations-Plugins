using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using DoseReview;

[assembly: AssemblyVersion("1.0.0.1")]

namespace VMS.TPS
{
  public class Script
  {
    public Script()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Execute(ScriptContext context, System.Windows.Window window, ScriptEnvironment environment)
    {
            // TODO : Add here the code that is called when the script is launched from Eclipse.
            //System.Windows.MessageBox.Show("Hello ESAPI!");
            if(context.PlanSetup == null)
            {
                MessageBox.Show("No Plan loaded in context.");
            }
            StructureSet structureSet = context.PlanSetup.StructureSet;
            string message = String.Empty;
            
            //MessageBox.Show(message);
            var structureView = new StructureView(context.Course);
            window.Content = structureView;
    }
  }
}
