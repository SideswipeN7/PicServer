using System;
using Microsoft.AspNetCore.Components;

namespace Pic.Settings.Client.Shared.Modal
{
    public partial class SimpleModalComponent
    {
        [Parameter]
        public string Title { get { return ModalLocale.Title; } set { ModalLocale.Title = value; } }

        [Parameter]
        public string Content { get { return ModalLocale.Content; } set { ModalLocale.Content = value; } }

        [Parameter]
        public string CloseText { get { return ModalLocale.CloseText; } set { ModalLocale.CloseText = value; } }

        [Parameter]
        public string OkText { get { return ModalLocale.OkText; } set { ModalLocale.OkText = value; } }

        [Parameter]
        public bool ShouldCloseAfterOkAction { get; set; }

        [Parameter]
        public Action ActionOk { get; set; }

        public ModalLocale ModalLocale { get; set; } = new ModalLocale();

        private bool isOpen;


        public void Open() => isOpen = true;

        private void Close() => isOpen = false;

        private void Ok()
        {
            ActionOk();
            if (ShouldCloseAfterOkAction)
            {
                Close();
            }
        }
    }
}