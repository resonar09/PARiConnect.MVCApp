using System;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Settings
    {
        public LayoutType Layout { get; set; }

        public String Columns { get; set; }
        public String DefaultClass { get; set; }


        public ContainerType Container { get; set; }

        public Boolean Labels { get; set; }

        public String FormController { get; set; }
        public String FormAction { get; set; }

    }

    public enum LayoutType { Stacked, TwoColumn, Responsive, Custom };
    public enum ContainerType { Page, Modal };

    public enum ColumnType { OneColumn = 1, TwoColumn = 2, ThreeColumn = 3 };


}