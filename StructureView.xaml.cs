using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace DoseReview
{
    /// <summary>
    /// Interaction logic for StructureView.xaml
    /// </summary>
    public partial class StructureView : UserControl
    {
        private Course _course;

        public StructureView(Course course)
        {
            InitializeComponent();
            foreach(var plan in course.PlanSetups)
            {
                PlanBox.Items.Add(plan.Id);
            }
            _course = course;
            
        }

        private void PlanBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlanSetup plan = _course.PlanSetups.FirstOrDefault(ps => ps.Id == PlanBox.SelectedItem.ToString());
            StructureSet structureSet = plan.StructureSet;
            List<StructureInfo> structureInfos = new List<StructureInfo>();
            foreach (var structure in structureSet.Structures)
            {
                DVHData dvh = plan.GetDVHCumulativeData(structure,
                    DoseValuePresentation.Absolute, VolumePresentation.Relative, 0.1);
                //message += String.Format("Structure: {0}; Maximum Dose = {1}\n", structure.Id, dvh.MaxDose);
                structureInfos.Add(new StructureInfo() { Id = structure.Id, MaxDose = dvh.MaxDose.ToString(), Volume = dvh.Volume });
            }
            StructureDataGrid.ItemsSource = structureInfos;
        }
    }
}
