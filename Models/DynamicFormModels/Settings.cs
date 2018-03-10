using System;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Settings
    {
        public LayoutType Layout { get; set; }

        public ContainerType Container { get; set; }

        public Boolean Labels { get; set; }

    }

    public enum LayoutType { Stacked, TwoColumn, Responsive };
    public enum ContainerType { Page, Modal };


}